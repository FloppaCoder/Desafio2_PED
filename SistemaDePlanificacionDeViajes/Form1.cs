using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SistemaDePlanificacionDeViajes
{
    public partial class Form1 : Form
    {

        private GrafoTransporte grafoTechopolis;

        // --- VARIABLES PARA GRAFICAR EL MAPA ---
        private Image mapaOriginal;
        private Dictionary<string, Point> ubicacionesEstaciones;
        private Dictionary<string, List<Point>> rutasVisualesCurvas;

        public Form1()
        {
            InitializeComponent();
            InicializarMapa();
            InicializarVisuales();
        }

        private void InicializarMapa()
        {
            grafoTechopolis = new GrafoTransporte();

            grafoTechopolis.AgregarRuta("Loto 3944", "Paseo Venecia", 5);
            grafoTechopolis.AgregarRuta("Paseo Venecia", "Loto 3944", 5);
            grafoTechopolis.AgregarRuta("Puente San José", "Paseo Venecia", 5);

            grafoTechopolis.AgregarRuta("Loto 3944", "Dulces Postres", 8);
            grafoTechopolis.AgregarRuta("Dulces Postres", "Loto 3944", 9);

            grafoTechopolis.AgregarRuta("Complejo Deportivo Diana", "Dulces Postres", 10);
            grafoTechopolis.AgregarRuta("Dulces Postres", "Complejo Deportivo Diana", 10);

            grafoTechopolis.AgregarRuta("Complejo Deportivo Diana", "Soyapango", 7);
            grafoTechopolis.AgregarRuta("Soyapango", "Complejo Deportivo Diana", 7);

            grafoTechopolis.AgregarRuta("Soyapango", "Dulces Postres", 5);
            grafoTechopolis.AgregarRuta("Dulces Postres", "Soyapango", 5);

            grafoTechopolis.AgregarRuta("Soyapango", "Puente San José", 12);
            grafoTechopolis.AgregarRuta("Puente San José", "Soyapango", 14);
            grafoTechopolis.AgregarRuta("Paseo Venecia", "Puente San José", 5);

            CargarCombos();
        }

        // Configuración de Coordenadas para el Dibujo
        private void InicializarVisuales()
        {
            if (pictureBox1.Image != null)
            {
                mapaOriginal = pictureBox1.Image.Clone() as Image;
            }
            else
            {
                MessageBox.Show("Error: No hay imagen cargada en el PictureBox1.");
                return;
            }

            ubicacionesEstaciones = new Dictionary<string, Point>();
            rutasVisualesCurvas = new Dictionary<string, List<Point>>();

            ubicacionesEstaciones.Add("Loto 3944", new Point(210, 245));
            ubicacionesEstaciones.Add("Paseo Venecia", new Point(440, 100));
            ubicacionesEstaciones.Add("Soyapango", new Point(645, 325));
            ubicacionesEstaciones.Add("Dulces Postres", new Point(285, 495));
            ubicacionesEstaciones.Add("Complejo Deportivo Diana", new Point(643, 700));
            ubicacionesEstaciones.Add("Puente San José", new Point(1030, 75));

            rutasVisualesCurvas.Add("Paseo Venecia-Puente San José", new List<Point> {
                ubicacionesEstaciones["Paseo Venecia"],
                new Point(530, 90),
                new Point(530, 150),
                new Point(795, 65),
                ubicacionesEstaciones["Puente San José"]
            });

            rutasVisualesCurvas.Add("Loto 3944-Paseo Venecia", new List<Point> {
                ubicacionesEstaciones["Loto 3944"],
                new Point(525, 170),
                new Point(530, 100),
                new Point(530, 100),
                ubicacionesEstaciones["Paseo Venecia"]
            });

            rutasVisualesCurvas.Add("Complejo Deportivo Diana-Dulces Postres", new List<Point> {
                ubicacionesEstaciones["Complejo Deportivo Diana"],
                new Point(285, 585),
                ubicacionesEstaciones["Dulces Postres"]
            });

            rutasVisualesCurvas.Add("Soyapango-Dulces Postres", new List<Point> {
                ubicacionesEstaciones["Soyapango"],
                new Point(625, 310),
                new Point(625, 245),
                new Point(500, 285),
                new Point(465, 370),
                new Point(460, 400),
                ubicacionesEstaciones["Dulces Postres"]
            });

            rutasVisualesCurvas.Add("Loto 3944-Dulces Postres", new List<Point> {
                ubicacionesEstaciones["Loto 3944"],
                new Point(235, 320),
                new Point(230, 375),
                new Point(200, 375),
                new Point(155, 585),
                new Point(250, 600),
                ubicacionesEstaciones["Dulces Postres"]
            });

            rutasVisualesCurvas.Add("Complejo Deportivo Diana-Soyapango", new List<Point> {
                ubicacionesEstaciones["Complejo Deportivo Diana"],
                new Point(730, 745),
                new Point(800, 530),
                new Point(570, 430),
                new Point(625, 320),
                ubicacionesEstaciones["Soyapango"]
            });

            rutasVisualesCurvas.Add("Soyapango-Puente San José", new List<Point> {
                ubicacionesEstaciones["Soyapango"],
                new Point(850, 380),
                new Point(855, 325),
                new Point(760, 270),
                new Point(760, 210),
                new Point(800, 70),
                ubicacionesEstaciones["Puente San José"]
            });

            DibujarEstacionesEnMapa();
        }

        private void CargarCombos()
        {
            var estaciones = grafoTechopolis.ObtenerEstaciones();
            cmbOrigen.DataSource = new List<string>(estaciones);
            cmbDestino.DataSource = new List<string>(estaciones);
        }

        // --- MÉTODO PARA DIBUJAR LA RUTA ---
        private void DibujarRutaEnMapa(List<string> camino)
        {
            if (camino == null || camino.Count < 2 || mapaOriginal == null) return;

            pictureBox1.Image = mapaOriginal.Clone() as Image;

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {

                Pen lapizRuta = new Pen(Color.FromArgb(255, 29, 209, 161), 6);
                lapizRuta.StartCap = LineCap.Round;
                lapizRuta.EndCap = LineCap.ArrowAnchor;
                lapizRuta.LineJoin = LineJoin.Round;

                g.SmoothingMode = SmoothingMode.AntiAlias;

                for (int i = 0; i < camino.Count - 1; i++)
                {
                    string origen = camino[i];
                    string destino = camino[i + 1];
                    string claveIda = $"{origen}-{destino}";
                    string claveVuelta = $"{destino}-{origen}";

                    List<Point> puntosRuta = new List<Point>();

                    if (ubicacionesEstaciones.ContainsKey(origen))
                        puntosRuta.Add(ubicacionesEstaciones[origen]);

                    if (rutasVisualesCurvas.ContainsKey(claveIda))
                    {
                        puntosRuta.AddRange(rutasVisualesCurvas[claveIda]);
                    }
                    else if (rutasVisualesCurvas.ContainsKey(claveVuelta))
                    {
                        var puntosInvertidos = Enumerable.Reverse(rutasVisualesCurvas[claveVuelta]).ToList();
                        puntosRuta.AddRange(puntosInvertidos);
                    }

                    if (ubicacionesEstaciones.ContainsKey(destino))
                        puntosRuta.Add(ubicacionesEstaciones[destino]);

                    // --- DIBUJAR LA LÍNEA ---
                    if (puntosRuta.Count > 1)
                    {
                        g.DrawLines(lapizRuta, puntosRuta.ToArray());
                    }
                }
            }
            pictureBox1.Refresh();
        }

        // --- BOTÓN: BÚSQUEDA EN AMPLITUD (BFS) ---
        private void btnBusquedaAmplitud_Click(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedItem == null) return;
            string origen = cmbOrigen.SelectedItem.ToString();
            string recorrido = grafoTechopolis.BFS(origen);
            txtResultados.Text = "Recorrido BFS (Niveles):\r\n" + recorrido;
        }

        // --- BOTÓN: BÚSQUEDA EN PROFUNDIDAD (DFS) ---
        private void btnBusquedaProfundidad_Click(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedItem == null) return;
            string origen = cmbOrigen.SelectedItem.ToString();
            string recorrido = grafoTechopolis.DFS(origen);
            txtResultados.Text = "Recorrido DFS (Ramas):\r\n" + recorrido;
        }

        // --- BOTÓN: RUTA MÁS CORTA (DIJKSTRA) ---
        private void btnRutaCorta_Click(object sender, EventArgs e)
        {
            txtResultados.Clear();
            txtTiempoTotal.Clear();
            Application.DoEvents();

            if (cmbOrigen.SelectedItem == null || cmbDestino.SelectedItem == null) return;

            string origen = cmbOrigen.SelectedItem.ToString();
            string destino = cmbDestino.SelectedItem.ToString();

            if (origen == destino)
            {
                MessageBox.Show("El origen y el destino son iguales.");
                return;
            }

            var resultado = grafoTechopolis.RutaMasCorta(origen, destino);

            if (resultado.tiempoTotal == -1)
            {
                txtTiempoTotal.Text = "Inaccesible";
                txtResultados.Text = "No existe una ruta entre estas estaciones.";
                // Si falla, limpiamos el mapa
                if (mapaOriginal != null) pictureBox1.Image = mapaOriginal.Clone() as Image;
            }
            else
            {
                txtTiempoTotal.Text = resultado.tiempoTotal.ToString() + " min";
                txtResultados.Text = "Ruta Óptima Calculada:\r\n" + string.Join(" -> ", resultado.camino);

                // DIBUJAR LA RUTA EN EL MAPA
                DibujarRutaEnMapa(resultado.camino);
            }

            ActualizarInfoPeso(origen, destino);
        }

        private void cmbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedItem != null && cmbDestino.SelectedItem != null)
            {
                ActualizarInfoPeso(cmbOrigen.SelectedItem.ToString(), cmbDestino.SelectedItem.ToString());
            }
        }

        private void ActualizarInfoPeso(string origen, string destino)
        {
            int peso = grafoTechopolis.ObtenerPeso(origen, destino);
            if (peso != -1)
            {
                txtPeso.Text = peso.ToString();
                txtNuevoPeso.Enabled = true;
            }
            else
            {
                txtPeso.Text = "N/A";
                txtNuevoPeso.Enabled = false;
            }
            txtNuevoPeso.Text = "";
        }

        private void txtNuevoPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evitar sonido beep
                if (cmbOrigen.SelectedItem == null || cmbDestino.SelectedItem == null) return;

                if (int.TryParse(txtNuevoPeso.Text, out int nuevoPeso))
                {
                    string origen = cmbOrigen.SelectedItem.ToString();
                    string destino = cmbDestino.SelectedItem.ToString();

                    // Actualizar IDA
                    grafoTechopolis.AgregarRuta(origen, destino, nuevoPeso);

                    // Actualizar VUELTA (si existe) para consistencia en tráfico
                    if (grafoTechopolis.ObtenerPeso(destino, origen) != -1)
                    {
                        grafoTechopolis.AgregarRuta(destino, origen, nuevoPeso);
                    }

                    txtPeso.Text = nuevoPeso.ToString();
                    MessageBox.Show($"Peso actualizado: De {origen} a {destino} (y viceversa) ahora toma {nuevoPeso} min.");
                    txtNuevoPeso.Text = "";
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un número válido.");
                }
            }
        }

        private void DibujarEstacionesEnMapa()
        {
            if (mapaOriginal == null) return;

            using (Graphics g = Graphics.FromImage(mapaOriginal))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Image iconoEstacion = Properties.Resources.bus_icon;

                int ancho = 30;
                int alto = 30;

                foreach (var estacion in ubicacionesEstaciones)
                {
                    Point centro = estacion.Value;
                    int x = centro.X - (ancho / 2);
                    int y = centro.Y - (alto / 2);

                    // Dibujar la imagen
                    g.DrawImage(iconoEstacion, x, y, ancho, alto);
                }
            }

            // Refrescar el mapa
            pictureBox1.Image = mapaOriginal.Clone() as Image;
        }
    }
}