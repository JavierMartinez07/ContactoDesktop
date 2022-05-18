using ContactoDesktop.Models;
using ContactoDesktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContactoDesktop
{
    public partial class PrincipalDetalle : Form
    {
        public PrincipalDetalle()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Hay campos vacios");
            }
            else
            {
                var model = new Contacto();
                model.Email = txtEmail.Text.Trim();
                model.Nombre = txtNombre.Text.Trim();
                model.Apellido = txtApellido.Text.Trim();
                model.Telefono = txtTelefono.Text.Trim();

                bool verifyEmail = ContactoServices.VerifyEmailContacto(model);
                if (verifyEmail)
                {
                    var response = ContactoServices.InsertContacto(model);
                    if (response.OK)
                    {
                        MessageBox.Show("Contacto Guardado");
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("El correo que intenta, ya esta en uso.");
                }


            }
           
        }
    }
}
