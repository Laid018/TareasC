using Datos.Entidades;
using Modelo;
using Presentacion.Interfaces;
using Presentacion.Presentador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Vistas
{
    public partial class Login : Form,IPresentadorLogin
    {
        private presentadorLogin _presentador;

        public string usuario { get => txtUsuario.Text; set => value.ToString(); }
        public string clave { get => txtClave.Text; set => value.ToString(); }

        public Login()
        {
            InitializeComponent();
            _presentador = new presentadorLogin(this);
            txtUsuario.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Acceder();
        }

        public void MostrarMensaje(string mje)
        {
            MessageBox.Show(mje);
        }

        private void Logout (object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
            this.Show();
            txtUsuario.Focus();
        }

        public void Acceder()
        {
            if (_presentador.Acceder())
            {
                Usuario usu = _presentador.ObtenerUsuario();
                Principal vp = new Principal();
                vp.lblUsuario.Text = usuario.ToUpper();
                vp.txtId.Text = usu.Id.ToString();
                vp.Show();
                vp.FormClosed += Logout;
                this.Hide();
            }
            else
                MostrarMensaje("Usuario y/o clave incorrectos. Intente nuevamente.");
        }

        private void linkRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro vista_Registro = new Registro();
            vista_Registro.Show();
            vista_Registro.txtNombre.Focus();
            vista_Registro.FormClosed += Logout;
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
