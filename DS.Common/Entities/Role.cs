using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using DS.Common.Models;

namespace DS.Common.Entities
{
    [Table("Roles")]
    public class Role : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleID { get; set; }

        public int RoleCode { get; set; }

        public string RoleName { get; set; }

        public string GroupCode { get; set; }

        public override void ModelBuilder(ModelBuilder modelBuilder)
        {

        }

    }
}