using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace CosumoPrueba.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public List<object> Usuario_Rol { get; set; } 
    }    
    public class Root    {
        public List<UsuarioModel> MyArray { get; set; } 

    }

}


