using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WindowsEF.Models;
namespace WindowsEF.Data

{
    public class DBProductionContext:DbContext
    {
        public DBProductionContext() : base("keyDBProduction") { }

        //por cada modelo una propiedad DBSET

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }


    }
}
