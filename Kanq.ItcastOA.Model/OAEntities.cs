namespace Kanq.ItcastOA.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OAEntities : DbContext
    {
        public OAEntities()
            : base("name=OAEntities")
        {
        }

        public virtual DbSet<ActionInfo> ActionInfo { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<KeyWordsRank> KeyWordsRank { get; set; }
        public virtual DbSet<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        public virtual DbSet<RoleInfo> RoleInfo { get; set; }
        public virtual DbSet<SearchDetails> SearchDetails { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionInfo>()
                .Property(e => e.MenuIcon)
                .IsUnicode(false);

            modelBuilder.Entity<ActionInfo>()
                .HasMany(e => e.R_UserInfo_ActionInfo)
                .WithRequired(e => e.ActionInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<UserInfo>()
                .HasMany(e => e.R_UserInfo_ActionInfo)
                .WithRequired(e => e.UserInfo)
                .WillCascadeOnDelete(false);
        }
    }
}
