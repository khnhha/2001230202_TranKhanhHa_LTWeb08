namespace Bai3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string EmployName { get; set; }

        [StringLength(5)]
        public string Gender { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        public int? DepId { get; set; }

        public virtual tbl_Deparment tbl_Deparment { get; set; }
    }
}
