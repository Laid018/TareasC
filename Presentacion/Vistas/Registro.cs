using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Presentador;
using Presentacion.Interfaces;
using Datos.Entidades;

namespace Presentacion.Vistas
{
    public partial class Registro : Form, IPresentadorRegistrar
    {
        private PresentadorRegistrarUsuario _presenter;
        public Registro()
        {
            InitializeComponent();
            _presenter = new PresentadorRegistrarUsuario(this);
        }

        public string nombre { get => txtNombre.Text; set => txtNombre.Text = value; }
        public string apellido { get => txtApellido.Text; set => txtApellido.Text = value; }
        public int dni { get => Convert.ToInt32(txtDni.Text); set => txtDni.Text = Convert.ToString(value); }
        public int telefono { get => Convert.ToInt32(txtTelefono.Text); set => txtTelefono.Text = Convert.ToString(value); }
        public string direccion { get => txtDireccion.Text; set => txtDireccion.Text = value; }
        public string nick { get => txtNick.Text; set => txtNick.Text = value; }
        public string clave { get => txtClave.Text; set => txtClave.Text = value; }
        
        public void RegistrarUsuario()
        {
            _presenter.RegistrarUsuario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarUsuario();
        }
    }
}
