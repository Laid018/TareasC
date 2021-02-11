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
    public partial class VisualizarTareas : Form,IPresentadorVisualizarTareas  
    {
        private PresentadorVisualizarTareas _presenter;

        public VisualizarTareas()
        {
            InitializeComponent();
            _presenter = new PresentadorVisualizarTareas(this);
        }

        public void BuscarTareasCompletadas()
        {
           dataGridView1.DataSource = _presenter.BuscarTareasCompletadas(txtBusqueda.Text, Convert.ToInt32(txtIdUsuario.Text)).Tables[0].DefaultView;
           dataGridView1.Refresh();
        }

        public void BuscarTareasPendientes()
        {
           dataGridView1.DataSource = _presenter.BuscarTareasPendientes(txtBusqueda.Text, Convert.ToInt32(txtIdUsuario.Text)).Tables[0].DefaultView;
           dataGridView1.Refresh();
        }

        public void BuscarTareasSinComenzar()
        {
           dataGridView1.DataSource = _presenter.BuscarTareasSinComenzar(txtBusqueda.Text, Convert.ToInt32(txtIdUsuario.Text)).Tables[0].DefaultView;
           dataGridView1.Refresh();
        }

        // Metodos de la interfaz
        public void CargarTabla()
        {
          dataGridView1.DataSource = _presenter.CargarTabla();  
        }

        // Metodos de la vista
        private void VisualizarTareas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tareaDS.tareas' Puede moverla o quitarla según sea necesario.
            //this.tareasTableAdapter.Fill(this.tareaDS.tareas);
            //CargarTabla();
        }

        private void txtBusqueda_Enter(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "REALIZAR BUSQUEDA")
            {
                txtBusqueda.Text = "";
            }
        }

        private void txtBusqueda_Leave(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                txtBusqueda.Text = "REALIZAR BUSQUEDA";
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "REALIZAR BUSQUEDA" && txtBusqueda.Text != "")
            {
                if (lblTitulo.Text == "Visualización tareas completadas")
                {
                   dataGridView1.DataSource = _presenter.BuscarTareasCompletadas(txtBusqueda.Text, Convert.ToInt32(txtIdUsuario.Text)).Tables[0].DefaultView; 
                   dataGridView1.Refresh();
                }
                else if (lblTitulo.Text == "Visualización tareas pendientes")
                {
                   dataGridView1.DataSource = _presenter.BuscarTareasPendientes(txtBusqueda.Text, Convert.ToInt32(txtIdUsuario.Text)).Tables[0].DefaultView; 
                   dataGridView1.Refresh();
                }
                else if (lblTitulo.Text == "Visualización tareas sin comenzar")
                {
                   dataGridView1.DataSource = _presenter.BuscarTareasSinComenzar(txtBusqueda.Text, Convert.ToInt32(txtIdUsuario.Text)).Tables[0].DefaultView; 
                   dataGridView1.Refresh();
                }
            }
            else
            {
                if (lblTitulo.Text == "Visualización tareas completadas")
                {
                   dataGridView1.DataSource = _presenter.MostrarTareasCompletadas(Convert.ToInt32(txtIdUsuario.Text)).Tables[0].DefaultView; 
                   dataGridView1.Refresh();
                }
                else if (lblTitulo.Text == "Visualización tareas pendientes")
                {
                   dataGridView1.DataSource = _presenter.MostrarTareasPendientes(Convert.ToInt32(txtIdUsuario.Text)).Tables[0].DefaultView; 
                   dataGridView1.Refresh();
                }
                else if (lblTitulo.Text == "Visualización tareas sin comenzar")
                {
                   dataGridView1.DataSource = _presenter.MostrarTareasSinComenzar(Convert.ToInt32(txtIdUsuario.Text)).Tables[0].DefaultView; 
                   dataGridView1.Refresh();
                }
            }
        }
    }
}
