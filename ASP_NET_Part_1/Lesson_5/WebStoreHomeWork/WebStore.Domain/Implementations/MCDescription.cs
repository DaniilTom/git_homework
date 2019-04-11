using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Interfaces;

namespace WebStore.Domain.Implementations
{
    [Table("MCDescriptions")]
    public class MCDescription : IProductDescription
    {
        [Key]
        public int ProductId { get; set; }
        public string[] DetailedDesriptionList { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Microcontroller Microcontroller { get; set; }
    }
}
