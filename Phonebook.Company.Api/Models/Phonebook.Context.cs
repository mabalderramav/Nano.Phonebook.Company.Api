﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbPhonebookCompanyEntities : DbContext
    {
        public dbPhonebookCompanyEntities()
            : base("name=dbPhonebookCompanyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
    }
}
