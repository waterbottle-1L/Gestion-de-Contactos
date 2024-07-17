using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Contactos.Contacto
{
    class Contacto
    {
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }

        public Contacto(int id,string nombre, int telefono, string email)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
        }           
    }
}
