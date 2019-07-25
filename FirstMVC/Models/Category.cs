using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name="Kategori Adı")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}