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

            getData();

            DataGridViewButtonColumn ButtonColumn = new DataGridViewButtonColumn();
            ButtonColumn.Name = "Opciones";
            ButtonColumn.Text = "Eliminar";
            ButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex = 5;
            if (tableData.Columns["Eliminar"] == null)
            {
                tableData.Columns.Insert(columnIndex, ButtonColumn);
            }
            tableData.CellClick += tableData_CellClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var detalle = new PrincipalDetalle();
            detalle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void tableData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tableData.Columns["Eliminar"].Index)
            {
               int indexRow =  tableData.CurrentCell.RowIndex;
               var model = tableData.Rows[indexRow].DataBoundItem as Contacto;
                ContactoServices.DeleteContacto(model.Id);
                getData();
            }
        }

        public void getData()
        {
            var contactos = ContactoServices.GetContactos();
            tableData.DataSource = contactos;
        }
    }
}
