﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MUAI_personal_cabinet
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MUAI_DBEntities4 : DbContext
    {
        public MUAI_DBEntities4()
            : base("name=MUAI_DBEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<договор> договор { get; set; }
        public virtual DbSet<клиент> клиент { get; set; }
        public virtual DbSet<личн_услуги> личн_услуги { get; set; }
        public virtual DbSet<личный_кабинет> личный_кабинет { get; set; }
        public virtual DbSet<пользователь> пользователь { get; set; }
        public virtual DbSet<тариф> тариф { get; set; }
        public virtual DbSet<услуга> услуга { get; set; }
    }
}
