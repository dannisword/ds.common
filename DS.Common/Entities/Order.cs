using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using DS.Common.Models;

namespace DS.Common.Entities
{
    [Table("Orders")]
    public class Order : ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<OrderDetail> Details { get; set; }

        public override void ModelBuilder(ModelBuilder modelBuilder)
        {

        }
    }
}