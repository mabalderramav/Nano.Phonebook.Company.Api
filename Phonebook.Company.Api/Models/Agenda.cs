//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nano.Phonebook.Company.Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agenda
    {
        public int IdAgenda { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; }
        public string ImagenRuta { get; set; }
        public string LineaDirecta { get; set; }
        public string Interno { get; set; }
        public string Corporativo { get; set; }
        public short IdCargo { get; set; }
        public short IdUbicacion { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
    }
}
