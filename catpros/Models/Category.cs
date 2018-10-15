using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace catpros.Models
{
    public class Category
    {
        [Key]
        public int CatergoryId {get;set;}

        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        public string Name {get;set;}

        [Required]
        public DateTime CreatedAt {get;set;}

        [Required]
        public DateTime UpdatedAt {get;set;}

        public List<Association> Associations {get;set;}

    }
}