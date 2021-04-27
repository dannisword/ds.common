using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using DS.Common.Models;
namespace DS.Common.Entities
{
    [Table("AppStores")]
    public class AppStore : AuditEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppID { get; set; }

        public int AppCode { get; set; }

        public string AppName { get; set; }

        public int ParentCode { get; set; }

        public string AppColor { get; set; }

        public string AppIcon { get; set; }

        public string AppUrl { get; set; }

        public override void ModelBuilder(ModelBuilder modelBuilder)
        {

        }
    }
}