﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyApp.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PropetyAppEntities : DbContext
    {
        public PropetyAppEntities()
            : base("name=PropetyAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Activity_Property> Activity_Property { get; set; }
        public virtual DbSet<Advert_Type> Advert_Type { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Constructor_Project> Constructor_Project { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Document_Type> Document_Type { get; set; }
        public virtual DbSet<Floor_Count> Floor_Count { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Indicator> Indicators { get; set; }
        public virtual DbSet<Indicators_Property> Indicators_Property { get; set; }
        public virtual DbSet<Metro> Metroes { get; set; }
        public virtual DbSet<Owner_Type> Owner_Type { get; set; }
        public virtual DbSet<Propert_Type> Propert_Type { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Repair_Type> Repair_Type { get; set; }
        public virtual DbSet<Room_Count> Room_Count { get; set; }
        public virtual DbSet<Sell_Type> Sell_Type { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
