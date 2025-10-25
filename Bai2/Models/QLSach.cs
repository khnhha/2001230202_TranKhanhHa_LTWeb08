using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bai2.Models
{
    public class QLSach : DbContext
    {
        public QLSach() : base("name=Sach")
        {
        }

        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<ChuDe> ChuDe { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBan { get; set; }
        public virtual DbSet<VietSach> VietSach { get; set; }
    }
}