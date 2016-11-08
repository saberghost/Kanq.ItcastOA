namespace Kanq.ItcastOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActionInfo")]
    public partial class ActionInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActionInfo()
        {
            R_UserInfo_ActionInfo = new HashSet<R_UserInfo_ActionInfo>();
        }

        public int ID { get; set; }

        public DateTime SubTime { get; set; }

        public short DelFlag { get; set; }

        [Required]
        public string ModifiedOn { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        [Required]
        [StringLength(512)]
        public string Url { get; set; }

        [Required]
        [StringLength(32)]
        public string HttpMethod { get; set; }

        [StringLength(32)]
        public string ActionMethodName { get; set; }

        [StringLength(128)]
        public string ControllerName { get; set; }

        [Required]
        [StringLength(32)]
        public string ActionInfoName { get; set; }

        public string Sort { get; set; }

        public short ActionTypeEnum { get; set; }

        [StringLength(512)]
        public string MenuIcon { get; set; }

        public int IconWidth { get; set; }

        public int IconHeight { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
    }
}
