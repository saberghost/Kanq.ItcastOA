namespace Kanq.ItcastOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        public int ID { get; set; }

        [Required]
        [StringLength(32)]
        public string DepName { get; set; }

        public int ParentId { get; set; }

        [Required]
        [StringLength(128)]
        public string TreePath { get; set; }

        public int Level { get; set; }

        public bool IsLeaf { get; set; }
    }
}
