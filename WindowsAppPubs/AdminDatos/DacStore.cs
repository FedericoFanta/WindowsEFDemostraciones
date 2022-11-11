using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsAppPubs.Models;
using WindowsAppPubs.AdminDatos;


namespace WindowsAppPubs.AdminDatos
{
   
    public static class DacStore
    {
        private static int filasAfectadas;
        private static object txtId;

        public static List<Store> Stores { get; set; }
       
        public static object StoreNuevo { get; private set; }


        public static PubsContext context = new PubsContext();
        public static List<Store> Lista()
        {
            List<Store> lista = new List<Store>() { };
            lista = context.stores.ToList();
            return lista;
        }

            public static int Nuevo(Store stores)
        {
            PubsContext context = new PubsContext();
            context.stores.Add(stores);
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;


        }
        public static int Modificar(Store StoreNuevo)
        {
            PubsContext context = new PubsContext();
            Store Store = context.stores.Find(StoreNuevo.stor_id);
            StoreNuevo=Store;
            int filasAfectadas = context.SaveChanges();
            return filasAfectadas;
        }
        public static int Eliminar(Store store)
        {
           

                string idabuscar = store.stor_id;
                Store storeabuscar = context.stores.Find(idabuscar);

                if (storeabuscar != null)
                {

                    context.stores.Remove(storeabuscar);


                }
                int filasafectadas = context.SaveChanges();
                return filasafectadas;

            }
        }

       
    }


