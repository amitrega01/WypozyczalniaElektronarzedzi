﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelBazy
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
        public virtual DbSet<Klienci> Klienci { get; set; }
        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
        public virtual DbSet<Produkty> Produkty { get; set; }
        public virtual DbSet<ProduktySz> ProduktySz { get; set; }
        public virtual DbSet<PunktyObslugi> PunktyObslugi { get; set; }
        public virtual DbSet<Rezerwacje> Rezerwacje { get; set; }
        public virtual DbSet<RezerwacjeSz> RezerwacjeSz { get; set; }
        public virtual DbSet<Wypozyczenie> Wypozyczenie { get; set; }
        public virtual DbSet<WypozyczenieSz> WypozyczenieSz { get; set; }
        public virtual DbSet<PelnyProdukt> PelnyProdukt { get; set; }
    }
}
