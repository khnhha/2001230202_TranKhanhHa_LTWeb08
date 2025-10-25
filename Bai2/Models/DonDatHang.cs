namespace Bai2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaDonHang { get; set; }

        [Required]
        [StringLength(20)]
        public string Dathanhtoan { get; set; }

        [StringLength(20)]
        public string Tinhtranggiaohang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaydat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaygiao { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
