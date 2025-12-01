using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaDePlanificacionDeViajes
{
    public class Ruta
    {
        public string Destino { get; set; }
        public int Tiempo { get; set; }

        public Ruta(string destino, int tiempo)
        {
            Destino = destino;
            Tiempo = tiempo;
        }
    }

    public class GrafoTransporte
    {
        private Dictionary<string, List<Ruta>> adyacencia;

        public GrafoTransporte()
        {
            adyacencia = new Dictionary<string, List<Ruta>>();
        }

        public void AgregarEstacion(string nombre)
        {
            if (!adyacencia.ContainsKey(nombre))
            {
                adyacencia[nombre] = new List<Ruta>();
            }
        }

        public void AgregarRuta(string origen, string destino, int tiempo)
        {
            AgregarEstacion(origen);
            AgregarEstacion(destino);

            var rutaExistente = adyacencia[origen].FirstOrDefault(r => r.Destino == destino);

            if (rutaExistente != null)
            {
                rutaExistente.Tiempo = tiempo;
            }
            else
            {
                adyacencia[origen].Add(new Ruta(destino, tiempo));
            }
        }

        public int ObtenerPeso(string origen, string destino)
        {
            if (adyacencia.ContainsKey(origen))
            {
                var ruta = adyacencia[origen].FirstOrDefault(r => r.Destino == destino);
                if (ruta != null) return ruta.Tiempo;
            }
            return -1;
        }

        public List<string> ObtenerEstaciones()
        {
            return adyacencia.Keys.OrderBy(x => x).ToList();
        }

        // --- ALGORITMOS ---

        // 1. BFS (Amplitud)
        public string BFS(string inicio)
        {
            if (!adyacencia.ContainsKey(inicio)) return "Estación no válida.";

            var visitados = new HashSet<string>();
            var cola = new Queue<(string nombre, int tiempo)>();
            var resultado = new StringBuilder();

            cola.Enqueue((inicio, 0));
            visitados.Add(inicio);

            while (cola.Count > 0)
            {
                var (actual, tiempoActual) = cola.Dequeue();
                resultado.AppendLine($"-> {actual} (a {tiempoActual} min del origen)");

                if (adyacencia.ContainsKey(actual))
                {
                    foreach (var ruta in adyacencia[actual])
                    {
                        if (!visitados.Contains(ruta.Destino))
                        {
                            visitados.Add(ruta.Destino);
                            cola.Enqueue((ruta.Destino, tiempoActual + ruta.Tiempo));
                        }
                    }
                }
            }
            return resultado.ToString();
        }

        // 2. DFS (Profundidad)
        public string DFS(string inicio)
        {
            if (!adyacencia.ContainsKey(inicio)) return "Estación no válida.";

            var visitados = new HashSet<string>();
            var pila = new Stack<(string nombre, int tiempo)>();
            var resultado = new StringBuilder();

            pila.Push((inicio, 0));

            while (pila.Count > 0)
            {
                var (actual, tiempoActual) = pila.Pop();

                if (!visitados.Contains(actual))
                {
                    visitados.Add(actual);
                    resultado.AppendLine($"-> {actual} (a {tiempoActual} min del origen)");

                    if (adyacencia.ContainsKey(actual))
                    {
                        var vecinos = adyacencia[actual].AsEnumerable().Reverse();
                        foreach (var ruta in vecinos)
                        {
                            if (!visitados.Contains(ruta.Destino))
                            {
                                pila.Push((ruta.Destino, tiempoActual + ruta.Tiempo));
                            }
                        }
                    }
                }
            }
            return resultado.ToString();
        }

        // 3. Dijkstra (Ruta más corta)
        public (int tiempoTotal, List<string> camino) RutaMasCorta(string inicio, string fin)
        {
            var distancias = new Dictionary<string, int>();
            var previo = new Dictionary<string, string>();
            var nodosNoVisitados = new List<string>();

            foreach (var nodo in adyacencia.Keys)
            {
                distancias[nodo] = int.MaxValue;
                nodosNoVisitados.Add(nodo);
            }

            if (!distancias.ContainsKey(inicio)) return (-1, null);

            distancias[inicio] = 0;

            while (nodosNoVisitados.Count > 0)
            {
                nodosNoVisitados.Sort((x, y) => distancias[x].CompareTo(distancias[y]));
                var actual = nodosNoVisitados[0];
                nodosNoVisitados.RemoveAt(0);

                if (actual == fin) break;
                if (distancias[actual] == int.MaxValue) break;

                if (adyacencia.ContainsKey(actual))
                {
                    foreach (var ruta in adyacencia[actual])
                    {
                        int alt = distancias[actual] + ruta.Tiempo;
                        if (alt < distancias[ruta.Destino])
                        {
                            distancias[ruta.Destino] = alt;
                            previo[ruta.Destino] = actual;
                        }
                    }
                }
            }

            if (distancias[fin] == int.MaxValue) return (-1, null);

            var camino = new List<string>();
            var paso = fin;
            while (paso != null)
            {
                camino.Insert(0, paso);
                previo.TryGetValue(paso, out paso);
            }

            return (distancias[fin], camino);
        }
    }
}