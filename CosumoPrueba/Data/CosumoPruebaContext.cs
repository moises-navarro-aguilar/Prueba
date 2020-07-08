using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CosumoPrueba.Data
{
    public class CosumoPruebaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CosumoPruebaContext() : base("name=CosumoPruebaContext")
        {
        }

        public System.Data.Entity.DbSet<CosumoPrueba.Models.RolModel> RolModels { get; set; }

        public System.Data.Entity.DbSet<CosumoPrueba.Models.Usuario_RolModel> Usuario_RolModel { get; set; }

        public System.Data.Entity.DbSet<CosumoPrueba.Models.UsuarioModel> UsuarioModels { get; set; }

        public System.Data.Entity.DbSet<ConectarDatos.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<ConectarDatos.Rol> Rols { get; set; }
    }
}
