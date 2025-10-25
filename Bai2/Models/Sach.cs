namespace Bai2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            VietSach = new HashSet<VietSach>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Required]
        [StringLength(30)]
        public string TenSach { get; set; }

        public double? Giaban { get; set; }

        [StringLength(100)]
        public string Mota { get; set; }

        [StringLength(100)]
        public string Anhbia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaycapnhat { get; set; }

        [StringLength(10)]
        public string MaCD { get; set; }

        [StringLength(10)]
        public string MaNXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual ChuDe ChuDe { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VietSach> VietSach { get; set; }
    }
}
