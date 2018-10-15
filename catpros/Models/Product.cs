using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace catpros.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        [Range(0.0,int.MaxValue)]

        public decimal Price {get;set;}
        [Required]
        public string Description {get;set;}
        [Required]
        public DateTime CreatedAt {get;set;}
        [Required]
        public DateTime UpdatedAt {get;set;}

        public List<Association> Associations {get;set;}
    }
}