using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stockstoreApi.Domains
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal? Price { get; set; }
    }
}
