namespace Kanq.ItcastOA.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class R_UserInfo_ActionInfo
    {
        public int ID { get; set; }

        public int UserInfoID { get; set; }

        public int ActionInfoID { get; set; }

        public bool IsPass { get; set; }

        public virtual ActionInfo ActionInfo { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
