namespace Kanq.ItcastOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleInfo")]
    public partial class RoleInfo
    {
        public RoleInfo()
        {
            UserInfo = new HashSet<UserInfo>();
            ActionInfo = new HashSet<ActionInfo>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(32)]
        public string RoleName { get; set; }

        public short DelFlag { get; set; }

        public DateTime SubTime { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string Sort { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }

        public virtual ICollection<ActionInfo> ActionInfo { get; set; }

    }
}
