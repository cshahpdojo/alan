using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catpros.Models
{
    public class Association
    {
        [Key]
        public int AssociationId {get;set;}

        public int ProductId {get;set;}
        [ForeignKey("ProductId")]
        public Product Product {get;set;}
        public int CategoryId {get;set;}
        [ForeignKey("CategoryId")]
        public Category Category {get;set;}
    }
}