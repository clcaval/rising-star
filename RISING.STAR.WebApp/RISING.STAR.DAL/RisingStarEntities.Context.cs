﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RISING.STAR.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RISINGSTAREntities : DbContext
    {
        public RISINGSTAREntities()
            : base("name=RISINGSTAREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Acquisitions_Table> Acquisitions_Table { get; set; }
        public virtual DbSet<Exams_Table> Exams_Table { get; set; }
        public virtual DbSet<ExamType> ExamTypes { get; set; }
        public virtual DbSet<InterventionCategory> InterventionCategories { get; set; }
        public virtual DbSet<InterventionEvent> InterventionEvents { get; set; }
        public virtual DbSet<InterventionIcon> InterventionIcons { get; set; }
        public virtual DbSet<InterventionType> InterventionTypes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Patients_Table> Patients_Table { get; set; }
        public virtual DbSet<PatientsComment> PatientsComments { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<UserTest> UserTests { get; set; }
        public virtual DbSet<UserTestQ> UserTestQs { get; set; }
        public virtual DbSet<UserTestP> UserTestPs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ETDRSNearVA> ETDRSNearVAs { get; set; }
        public virtual DbSet<JaegerNearVA> JaegerNearVAs { get; set; }
        public virtual DbSet<SnellenVA> SnellenVAs { get; set; }
    }
}
