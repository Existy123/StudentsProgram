﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentsProgramOrganisation.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StudentsOrgEntities : DbContext
    {
        public StudentsOrgEntities()
            : base("name=StudentsOrgEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<LearningDays> LearningDays { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
    }
}
