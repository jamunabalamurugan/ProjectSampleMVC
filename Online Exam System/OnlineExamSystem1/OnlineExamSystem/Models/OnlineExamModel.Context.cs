﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExamSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnlineExamSystemEntities2 : DbContext
    {
        public OnlineExamSystemEntities2()
            : base("name=OnlineExamSystemEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<QUESTION> QUESTIONs { get; set; }
        public virtual DbSet<REPORT> REPORTs { get; set; }
        public virtual DbSet<TECHNOLOGY> TECHNOLOGies { get; set; }
        public virtual DbSet<USER_DETAIL> USER_DETAIL { get; set; }

        public System.Data.Entity.DbSet<OnlineExamSystem.Models.ViewModel1> ViewModel1 { get; set; }
    }
}
