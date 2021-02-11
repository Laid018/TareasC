using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Interfaces;
using Presentacion.Presentador;

namespace Presentacion.Vistas
{
    public partial class CargarTareas : Form, IPresentadorCargarTareas
    {
        private PresentadorCargarTareas _presenter;
        public CargarTareas()
        {
            InitializeComponent();
            _presenter = new PresentadorCargarTareas(this);
        }

#region Metoodos de la interfaz
        // Metoodos de la interfaz
        public string titulo { get => txtTitulo.Text; set => txtTitulo.Text = value; }
        public string descripcion { get => txtDescripcion.Text; set => txtDescripcion.Text = value; }
        public string color { get => txtColor.Text; set => txtColor.Text = value; }
        public DateTime fechaInicio { get => dateInicio.Value; set => dateInicio.Value = value; }
        public DateTime fechaFin { get => dateFin.Value; set => dateFin.Value = value; }
        public int id { get => Convert.ToInt32(txtId.Text); set => txtId.Text = value.ToString(); }
        public int porcentaje { get => Convert.ToInt32(txtPorcentaje.Text); set => txtPorcentaje.Text = value.ToString(); }
        
        public int idTarea { get => Convert.ToInt32(txtIdTarea.Text); set => txtIdTarea.Text = value.ToString(); }

        public void RegistrarTarea()
        {
            _presenter.RegistrarTarea();
        }

        public void MostrarMensaje(string mje)
        {
            MessageBox.Show(mje); 
        }
#endregion

#region Metodos de la vista
        // Metodos de la vista
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_presenter.ObtenerId(idTarea) == null)
            {
                RegistrarTarea();
                MostrarMensaje("Tarea agregada satisfactoriamente.");
                this.Close();
            }
            else
            {
                this.lblFormTitle.Text = "Actualizar Tarea";
                var tarea = _presenter.ObtenerId(idTarea);
                _presenter.ActualizarTarea(tarea);
                MostrarMensaje("Tarea actualizada satisfactoriamente.");
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void CargarTareas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tareaDS.tareas' Puede moverla o quitarla según sea necesario.
            //tareasTableAdapter.Fill(this.tareasDS.tareas);

        }
       
    }
}
