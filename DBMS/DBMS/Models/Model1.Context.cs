//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBMSEntities2 : DbContext
    {
        public DBMSEntities2()
            : base("name=DBMSEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Seek> Seek { get; set; }
    }
}
