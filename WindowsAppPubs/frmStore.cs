using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppPubs.AdminDatos;
using WindowsAppPubs.Models;
using static System.Windows.Forms.AxHost;

namespace WindowsAppPubs
{
    public partial class frmStore : Form
    {
        PubsContext context = new PubsContext();
        public frmStore()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e, Store store)
        {
            //creamos la instancia
            Store stores = new Store() { stor_id="4444", stor_name="Pepito 123",stor_address ="pepe@gmail.com",city="Mar del plata",state="MA",zip="12345"};


            //DBset
            context.stores.Add(store);

            //Guardar en la tabla

            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("OK");
            }




        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
          

            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("OK");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string id = "4444";
            Store storeDb = context.stores.Find(id);

            //Modificación del objeto
            if (storeDb != null)
            {

                storeDb.stor_name = "Eleado";
                storeDb.city = "Mar del Sur";
                storeDb.state ="YY";
                storeDb.stor_address="Italia@hotmail.com";
                storeDb.zip="88888";

            }

            //Guadar en la DB
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("OK");
            }

        }

        private void btnTraerTodos_Click(object sender, EventArgs e)
        {

        }
    }
}
