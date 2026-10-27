using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Deber3.Figuras;

namespace Deber3
{
    public partial class Hexagonofrm : Form
    {
        private Hexagono figura;
        private bool hayClic;
        private bool mostrarDetalles;
        private string detalleClic = "";
        private Vector2D p, a, b, q;

        public Hexagonofrm()
        {
            InitializeComponent();
            figura = new Hexagono((double)nudLado.Value);
            Actualizar();
            SimplificarInterfaz(new Control[] { lblLado, nudLado });
        }

        // Conserva los controles del diseñador y deja las opciones avanzadas plegadas.
        // Se agregan los controles adicionales que se quieran mostrar en la parte derecha del formulario.
        private void SimplificarInterfaz(Control[] basicos, params Control[] adicionales)
        {
            SuspendLayout();
            Control[] transformaciones = {
                Controls["lblX"], nudX, Controls["lblY"], nudY,
                Controls["lblAngulo"], nudAngulo, Controls["lblEscala"], nudEscala
            };
            var camposAvanzados = new Control[transformaciones.Length + adicionales.Length];
            transformaciones.CopyTo(camposAvanzados, 0);
            adicionales.CopyTo(camposAvanzados, transformaciones.Length);

            Control etiquetaColor = Controls["lblParte"];
            Control botonColor = Controls["btnColor"];
            Controls.Clear();
            AutoScroll = true;
            ClientSize = new Size(1080, 620);
            MinimumSize = new Size(720, 480);
            // Se crea un TableLayoutPanel para organizar el lienzo y las opciones en dos columnas
            var distribucion = new TableLayoutPanel
            {
                Name = "distribucion",
                Location = Point.Empty,
                Size = new Size(1060, 600),
                ColumnCount = 2,
                RowCount = 1,
                Margin = Padding.Empty
            };
            distribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 800));
            distribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260));
            distribucion.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            // Se crea un FlowLayoutPanel para organizar los controles de opciones en una columna
            var opciones = new FlowLayoutPanel
            {
                Name = "opciones",
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(12),
                Margin = Padding.Empty
            };
            opciones.Controls.Add(TablaCampos(basicos));
            etiquetaColor.Text = "Color por parte";
            etiquetaColor.AutoSize = false;
            etiquetaColor.Size = new Size(220, 24);
            etiquetaColor.Margin = new Padding(0, 10, 0, 0);
            opciones.Controls.Add(etiquetaColor);
            botonColor.Text = "Color...";
            opciones.Controls.Add(TablaCampos(new[] { (Control)cmbParte, botonColor }));

            // Se crea un TableLayoutPanel para organizar los controles de opciones avanzadas en dos columnas
            var avanzadas = TablaCampos(camposAvanzados);
            avanzadas.Name = "opcionesAvanzadas";
            avanzadas.Visible = false;
          
                mostrarDetalles = !mostrarDetalles;
                avanzadas.Visible = mostrarDetalles;
              
                txtInfo.Height = mostrarDetalles ? 310 : 150;
                ActualizarInformacion();
                picLienzo.Invalidate();
            
        
            opciones.Controls.Add(avanzadas);

            txtInfo.Size = new Size(220, 150);
            txtInfo.Margin = new Padding(0, 12, 0, 0);
            txtInfo.Font = Font;
            txtInfo.BorderStyle = BorderStyle.None;
            txtInfo.BackColor = SystemColors.Control;
            opciones.Controls.Add(txtInfo);

            picLienzo.Dock = DockStyle.Fill;
            picLienzo.BorderStyle = BorderStyle.None;
            picLienzo.MinimumSize = new Size(800, 600);
            picLienzo.Margin = Padding.Empty;
            picLienzo.Resize += delegate { picLienzo.Invalidate(); };
            distribucion.Controls.Add(picLienzo, 0, 0);
            distribucion.Controls.Add(opciones, 1, 0);
            Controls.Add(distribucion);
            ResumeLayout(true);
        }
        // Crea un TableLayoutPanel para organizar los controles en dos columnas
        private static TableLayoutPanel TablaCampos(Control[] campos)
        {
            var tabla = new TableLayoutPanel
            {
                Width = 220,
                Height = campos.Length / 2 * 34,
                ColumnCount = 2,
                RowCount = campos.Length / 2,
                Margin = Padding.Empty
            };
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            for (int i = 0; i < campos.Length; i++)
            {
                campos[i].Dock = DockStyle.Fill;
                campos[i].Margin = new Padding(0, 5, 4, 5);
                var etiqueta = campos[i] as Label;
                if (etiqueta != null)
                {
                    etiqueta.AutoSize = false;
                    etiqueta.TextAlign = ContentAlignment.MiddleLeft;
                }
                tabla.Controls.Add(campos[i], i % 2, i / 2);
                if (i % 2 == 0) tabla.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            }
            return tabla;
        }
        // Actualiza la figura con los valores de los controles y maneja las excepciones de validacion
        private void Cambio(object sender, EventArgs e)
        {
            if (figura == null) return;
            try
            {
                figura.Lado = (double)nudLado.Value;
                figura.X = (double)nudX.Value; figura.Y = (double)nudY.Value;
                figura.AnguloGrados = (double)nudAngulo.Value; figura.Escala = (double)nudEscala.Value;
                Actualizar();
            }
            catch (ArgumentException error) { MessageBox.Show(error.Message, "Valor no valido"); }
        }
        // Cambia el color de la parte seleccionada de la figura usando un ColorDialog
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (figura == null || cmbParte.SelectedIndex < 0) return;
            using (var dialogo = new ColorDialog { Color = figura.ColorParte(cmbParte.SelectedIndex) })
                if (dialogo.ShowDialog() == DialogResult.OK) { figura.CambiarColor(cmbParte.SelectedIndex, dialogo.Color); picLienzo.Invalidate(); }
        }
        // Muestra u oculta los detalles del clic y actualiza la informacion y el lienzo
        private void picLienzo_Paint(object sender, PaintEventArgs e)
        {
            if (figura == null) return;
            Graphics g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(Pens.LightGray, 0, picLienzo.Height / 2, picLienzo.Width, picLienzo.Height / 2);
            g.DrawLine(Pens.LightGray, picLienzo.Width / 2, 0, picLienzo.Width / 2, picLienzo.Height);
            foreach (Parte parte in figura.Partes()) Dibujar(g, parte);
            if (hayClic) Marca(g, p, Brushes.Blue);
            if (hayClic && mostrarDetalles)
            {
                // Borde blanco bajo la linea roja para que se vea tambien sobre figuras rojas.
                using (var blanco = new Pen(Color.White, 7)) g.DrawLine(blanco, Pantalla(a), Pantalla(b));
                using (var rojo = new Pen(Color.Red, 3)) g.DrawLine(rojo, Pantalla(a), Pantalla(b));
                g.DrawLine(Pens.Gray, Pantalla(p), Pantalla(q));
                Marca(g, q, Brushes.Green);
            }
        }
        // Maneja el evento MouseDown del lienzo para calcular el punto mas cercano al borde de la figura y actualizar la informacion
        private void picLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            if (figura == null) return;
            Vector2D[] borde = figura.Contorno();
            if (borde == null || borde.Length < 2) return;
            a = borde[0];
            b = borde[1];
            p = new Vector2D(e.X - picLienzo.Width / 2.0, picLienzo.Height / 2.0 - e.Y);
            q = Figura.PuntoMasCercano(a, b, p); hayClic = true;
            Vector2D u = p - a, s = b - a;
            detalleClic = string.Format(
                "\r\n\r\nP={0}\r\nA={1}, B={2}\r\n|u|={3:0.00}, direccion u={4:0.00}\r\n|s|={5:0.00}, direccion s={6:0.00}\r\nu.s={7:0.00}, det(s,u)={8:0.00}\r\nOrientacion: {9}\r\nQ={10}, distancia={11:0.00}\r\nDentro: {12}",
                p, a, b, u.Magnitud, u.Direccion, s.Magnitud, s.Direccion, Vector2D.Punto(u, s),
                Vector2D.Determinante(s, u), Figura.OrientacionPunto(a, b, p), q, Vector2D.Distancia(p, q), figura.Contiene(p) ? "SI" : "NO");
            ActualizarInformacion();
            picLienzo.Invalidate();
        }
        // Actualiza la lista de partes y el lienzo cuando cambia la figura o se selecciona otra parte
        private void Actualizar()
        {
            if (figura == null) return;
            if (cmbParte.Items.Count != figura.NumeroPartes)
            {
                cmbParte.Items.Clear();
                for (int i = 0; i < figura.NumeroPartes; i++) cmbParte.Items.Add("Parte " + (i + 1));
                if (cmbParte.Items.Count > 0) cmbParte.SelectedIndex = 0;
            }
            hayClic = false; ActualizarInformacion(); picLienzo.Invalidate();
        }
        private void ActualizarInformacion()
        {
            if (figura == null) return;
            txtInfo.Text = figura.Describir();
            if (hayClic)
                txtInfo.Text += mostrarDetalles ? detalleClic :
                    "\r\n\r\nPunto: " + (figura.Contiene(p) ? "dentro de la figura" : "fuera de la figura");
        }
        // Convierte un punto en coordenadas de la figura a coordenadas de pantalla para dibujar
        private PointF Pantalla(Vector2D v) { return new PointF(picLienzo.Width / 2f + (float)v.X, picLienzo.Height / 2f - (float)v.Y); }
        private void Dibujar(Graphics g, Parte parte)
        {
            var puntos = new PointF[parte.Vertices.Length];
            for (int i = 0; i < puntos.Length; i++) puntos[i] = Pantalla(parte.Vertices[i]);
            using (var pincel = new SolidBrush(parte.Color)) g.FillPolygon(pincel, puntos);
            g.DrawPolygon(Pens.Black, puntos);
        }
        private void Marca(Graphics g, Vector2D v, Brush color)
        {
            PointF punto = Pantalla(v); g.FillEllipse(color, punto.X - 4, punto.Y - 4, 8, 8);
        }

        // Conserva los metodos que puede tener enlazados el Designer.
        private void Hexagonofrm_Load(object sender, EventArgs e)
        {
        }

        private void picLienzo_Click(object sender, EventArgs e)
        {
        }
    }
}