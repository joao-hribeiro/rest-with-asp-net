using Microsoft.EntityFrameworkCore;
using RestWithAspNet.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace RestWithAspNet.Model
{
    [Table("book")]
    public class Book : BaseEntity
    {
        [Column("title", TypeName="text")]
        public string? Title { get; set; }

        [Column("author", TypeName = "text")]
        public string? Author { get; set; }

        [Required]
        [Column("price")]
        [Precision(18,2)]
        public decimal Price { get; set; }

        [Required]
        [Column("launch_date", TypeName = "timestamp without time zone")]
        public DateTime LaunchDate { get; set; }
    }
}

