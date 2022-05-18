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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

           var contactos =  ContactoServices.GetContactos();
            tableData.DataSource = contactos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var detalle = new PrincipalDetalle();
            detalle.ShowDialog();
        }
    }
}
