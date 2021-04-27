using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using DS.Common.Models;

namespace DS.Common.Entities
{
    [Table("RoleApps")] 
    public class RoleApp : AuditEntity
    {
        [Key]
        [Column(Order = 0)]
        public int RoleID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int AppID { get; set; }
        
        public bool CanApprove { get; set; }

        public bool CanInsert { get; set; }

        public bool CanDelete { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanPrint { get; set; }

        public override void ModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleApp>(config =>
            {
                config.HasKey(c => new { c.RoleID, c.AppID });
            });
        }
    }
}