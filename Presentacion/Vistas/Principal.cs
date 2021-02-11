using Presentacion.Vistas;
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

namespace Presentacion
{
    public partial class Principal : Form, IPresentadorPrincipal
    {
        private PresentadorPrincipal _presenter;
        public Principal()
        {
            InitializeComponent();
            _presenter = new PresentadorPrincipal(this);
        }

        #region Metodo de la interfaz
        // Metodo de la interfaz
        public DataTable CargarTareas()
        {
            return _presenter.CargarTareas();
        }
        #endregion

        #region Metodos de la vista
        // Metodos de la vista
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Usted desea salir del sistema?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //// TODO: esta línea de código carga datos en la tabla 'tareaDS1.tareas' Puede moverla o quitarla según sea necesario.
            //this.tareasTableAdapter.Fill(this.tareaDS.tareas);
            //// TODO: esta línea de código carga datos en la tabla 'tareaDataSet.tareas' Puede moverla o quitarla según sea necesario.
            //this.tareasTableAdapter.Fill(this.tareaDS.tareas);
            dataGridView1.DataSource = CargarTareas();
            TareasAVencer();
            if (_presenter.MostrarTareasCompletadas(Convert.ToInt32(txtId.Text)) == null)
                BarCompletada.Value = 0;
            else
                BarCompletada.Value = _presenter.MostrarTareasCompletadas(Convert.ToInt32(txtId.Text)).Tables[0].Rows.Count;
            if (_presenter.MostrarTareasPendientes(Convert.ToInt32(txtId.Text)) == null)
                BarPendiente.Value = 0;
            else
                BarPendiente.Value = _presenter.MostrarTareasPendientes(Convert.ToInt32(txtId.Text)).Tables[0].Rows.Count;
            if (_presenter.MostrarTareasSinComenzar(Convert.ToInt32(txtId.Text)) == null)
                BarSinComenzar.Value = 0;
            else
                BarSinComenzar.Value = _presenter.MostrarTareasSinComenzar(Convert.ToInt32(txtId.Text)).Tables[0].Rows.Count;
        }

        private void btnCargarTareas_Click(object sender, EventArgs e)
        {
            CargarTareas vista_tarea = new CargarTareas();
            vista_tarea.txtId.Text = this.txtId.Text;
            vista_tarea.Show();
            vista_tarea.txtTitulo.Focus();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "REALIZAR BUSQUEDA" && txtBusqueda.Text != "")
            {
                dataGridView1.DataSource = _presenter.BuscarTareas(txtBusqueda.Text).Tables[0].DefaultView;
                dataGridView1.Refresh();
            }
            else
            {
                dataGridView1.DataSource = CargarTareas();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CargarTareas vista_tarea = new CargarTareas();
            vista_tarea.txtId.Text = this.txtId.Text;
            vista_tarea.Show();
            vista_tarea.txtTitulo.Focus();
            vista_tarea.FormClosed += ActualizarGrid;
        }

        private void ActualizarGrid(object sender, FormClosedEventArgs e)
        {
            this.dataGridView1.DataSource = CargarTareas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                CargarTareas vista_tarea = new CargarTareas();
                vista_tarea.txtId.Text = this.txtId.Text;
                vista_tarea.txtIdTarea.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                vista_tarea.txtTitulo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                vista_tarea.txtDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                vista_tarea.txtColor.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                vista_tarea.dateInicio.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
                vista_tarea.dateFin.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
                vista_tarea.txtPorcentaje.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                vista_tarea.Show();
                vista_tarea.FormClosed += ActualizarGrid;
                vista_tarea.txtTitulo.Focus();
            }
            else { MessageBox.Show("Seleccionar una fila para editar."); }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("¿Estas seguro que deseas eliminar esta tarea?", "warning", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _presenter.EliminarTarea(id);
                    dataGridView1.DataSource = _presenter.CargarTareas();
                }
            }
            else { MessageBox.Show("Seleccionar una fila para borrar."); }
        }
        #endregion

        private void btnVisualizarTareas_Click(object sender, EventArgs e)
        {
            VisualizarTareas vista_tarea = new VisualizarTareas();
            vista_tarea.Show();
        }

        // Para establecer color filtro
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Color")
            {
                if (e.Value.ToString() == "azul")
                    e.CellStyle.ForeColor = Color.White;
                e.CellStyle.BackColor = Color.Blue;
            }
        }

        public void TareasAVencer()
        {
            if (_presenter.MostrarTareasProximasVencer(Convert.ToInt32(txtId.Text)).Count == 0)
            {
                 dataGridView2.DataSource = null;   
            }
            else
            {
                dataGridView2.DataSource = _presenter.MostrarTareasProximasVencer(Convert.ToInt32(txtId.Text));    
            }
        }

        private void btnVerTareasCompletadas_Click(object sender, EventArgs e)
        {
            if (_presenter.MostrarTareasCompletadas(Convert.ToInt32(txtId.Text)) == null)
                MessageBox.Show("No hay tareas completadas.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                VisualizarTareas vista = new VisualizarTareas();
                vista.dataGridView1.DataSource = _presenter.MostrarTareasCompletadas(Convert.ToInt32(txtId.Text)).Tables[0].DefaultView;
                vista.lblTitulo.Text = "Visualización tareas completadas";
                vista.txtIdUsuario.Text = txtId.Text;
                vista.Show();
            }
        }

        private void btnVerTareasPendientes_Click(object sender, EventArgs e)
        {
            if (_presenter.MostrarTareasPendientes(Convert.ToInt32(txtId.Text)) == null)
                MessageBox.Show("No hay tareas pendientes.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                VisualizarTareas vista = new VisualizarTareas();
                vista.dataGridView1.DataSource = _presenter.MostrarTareasPendientes(Convert.ToInt32(txtId.Text)).Tables[0].DefaultView;
                vista.lblTitulo.Text = "Visualización tareas pendientes";
                vista.txtIdUsuario.Text = txtId.Text;
                vista.Show();
            }
        }

        private void btnVerTareasSinComenzar_Click(object sender, EventArgs e)
        {
            if (_presenter.MostrarTareasSinComenzar(Convert.ToInt32(txtId.Text)) == null)
                MessageBox.Show("No hay tareas sin comenzar.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                VisualizarTareas vista = new VisualizarTareas();
                vista.dataGridView1.DataSource = _presenter.MostrarTareasSinComenzar(Convert.ToInt32(txtId.Text)).Tables[0].DefaultView;
                vista.lblTitulo.Text = "Visualización tareas sin comenzar";
                vista.txtIdUsuario.Text = txtId.Text;
                vista.Show();
            }
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
    }
}
