using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppPubs.Models;
using WindowsAppPubs.AdminDatos;

namespace WindowsAppPubs
{
    public partial class FormConMetodosAuthor : Form
    {
        public FormConMetodosAuthor()
        {
            InitializeComponent();

        }



        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            Author store_existente = DacAuthor.TraerUno(id);
            if (store_existente != null)
            {

                MessageBox.Show("No puede ingresar un Author con ese ID porque ya existe");

            }
            else
            {
                Author author = new Author();
                author.au_id = txtAuthorId.Text;
                author.au_fname = txtAuthorFirstName.Text;
                author.au_lname = txtLastName.Text;
                author.phone = txtAuthorPhone.Text;
                author.address = txtAuthorAddress.Text;
                author.city = txtCity.Text;
                author.state = txtState.Text;
                author.zip = txtZip.Text;
                author.contract = Convert.ToBoolean(txtContract.Text);

                int filasAfectadas = DacAuthor.Nuevo(author);


                if (filasAfectadas > 0) { MessageBox.Show("Nuevo Author Insertado: Id " + txtId.Text); };

            }



        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            //buscar store
            string id = txtId.Text;
            Author author = DacAuthor.TraerUno(id);

            if (author != null)
            {

                author.au_fname = txtAuthorFirstName.Text;
                author.au_lname = txtLastName.Text;
                author.phone = txtAuthorPhone.Text;
                author.address = txtAuthorAddress.Text;
                author.city = txtCity.Text;
                author.state = txtState.Text;
                author.zip = txtZip.Text;
                author.contract = Convert.ToBoolean(txtContract.Text);

                int filasAfectadas;
                //Modificación del objeto
                if (author != null)
                {
                    filasAfectadas = DacAuthor.Modificar(author);
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Author Modificado");
                    }

                }

            }
            else
            {

                MessageBox.Show("Ingrese un Author existente para modificar");

            }






        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            Author author = new Author();
            author.au_id = id;


            int filasafectadas = DacAuthor.Eliminar(author);
            if (filasafectadas > 0)
            {
                MessageBox.Show("Author Eliminado");
            }



        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            List<Author> lista = DacAuthor.Lista();
            gridAuthor.DataSource = lista; //Data Source solo se enlaza a colecciones

        }

        private void btnBuscarUno_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            Author author = DacAuthor.TraerUno(id);

            if (author != null)
            {
                txtAuthorId.Text = author.au_id;
                txtAuthorFirstName.Text = author.au_fname;

                txtLastName.Text = author.au_lname;
                txtAuthorPhone.Text = author.phone;
                txtAuthorAddress.Text = author.address;
                txtCity.Text = author.city;
                txtState.Text = author.state;
                txtZip.Text = author.zip;
                txtContract.Text = author.contract.ToString();


            }
            else
            {
                MessageBox.Show("No se encontró el Author solicitado");
            }
        }
    }
}
