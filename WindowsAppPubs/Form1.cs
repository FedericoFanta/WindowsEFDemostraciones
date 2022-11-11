using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppPubs.Models;

namespace WindowsAppPubs
{
    public partial class Form1 : Form
    {
        PubsContext context = new PubsContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //creamos la instancia
            Publisher publisher = new Publisher() { pub_id="2223",pub_name="New Moon Books", city="Boston", state="MA",country="USA"};

            //DBset
            context.Stores.Add(publisher);

            //Guardar en la tabla

            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("OK");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            string id = "2222";
            Publisher publisherDb = context.Stores.Find(id);

            //Modificación del objeto
            if (publisherDb != null)
            {
                
                publisherDb.pub_name = "Elemento Modificado";
                publisherDb.city = "Mar del Sur";
                publisherDb.state ="YY";
                publisherDb.country="Italia";

            }

            //Guadar en la DB
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("OK");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = (txtId.Text);

            //Buscar el objeto en la DB

            var publisherDB = context.Stores.Find(id);

            if (publisherDB != null)
            {
                // remover
                context.Stores.Remove(publisherDB);
                //guardar cambio en la DB
                //Guadar en la DB
                int filasAfectadas = context.SaveChanges();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Eliminar OK");
                }

            }
        }

        private void btnTraerTodos_Click(object sender, EventArgs e)
        {
            //declaramos una lista
            List<Publisher> ListaPublishers = context.Stores.ToList();
            gridPublisher.DataSource = ListaPublishers;
        }
    }
}
