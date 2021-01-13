using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using DS.Common.Models;

namespace DS.Common.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail : ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        [ForeignKey("OrderId")]   // if not specifed, Order_Id column will be used
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public override void ModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.OrderId);
                   Console.WriteLine("entity bulider");
            });
        }
    }
}