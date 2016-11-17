namespace Kanq.ItcastOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserInfo()
        {
            R_UserInfo_ActionInfo = new HashSet<R_UserInfo_ActionInfo>();
            RoleInfo = new HashSet<RoleInfo>();
        }

        public int ID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(64)]
        public string UName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(16)]
        public string UPwd { get; set; }


        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime SubTime { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public short DelFlag { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(256)]
        public string Remark { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }

        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
    }
}
