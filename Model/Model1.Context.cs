﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WypozyczalniaEntities : DbContext
    {
        public WypozyczalniaEntities()
            : base("name=WypozyczalniaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kategorie> Kategorie { get; set; }
        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
        public virtual DbSet<Produkty> Produkty { get; set; }
        public virtual DbSet<PunktObslugi> PunktObslugi { get; set; }
        public virtual DbSet<ProduktySz> ProduktySz { get; set; }
    }
}
