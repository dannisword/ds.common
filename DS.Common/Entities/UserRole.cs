using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using DS.Common.Models;

namespace DS.Common.Entities
{
    [Table("UserRoles")]
    public class UserRole : EntityBase
    {
        [Key]
        [Column(Order = 0)]
        public int UserID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int RoleID { get; set; }

        public DateTime StartAt { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime EndAt { get; set; }

        public override void ModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(key => new { key.UserID, key.RoleID, key.EndAt });

        }
    }
}