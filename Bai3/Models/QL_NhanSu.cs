using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Bai3.Models
{
    public partial class QL_NhanSu : DbContext
    {
        public QL_NhanSu()
            : base("name=QL_NhanSu1")
        {
        }

        public virtual DbSet<tbl_Deparment> tbl_Deparment { get; set; }
        public virtual DbSet<tbl_Employee> tbl_Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
