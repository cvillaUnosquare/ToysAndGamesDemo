using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysAndGames.Entities.Entities
{
    [Table("Product")]
    public class Product
    {
        #region properties
        [Key]
<<<<<<< HEAD
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
=======
>>>>>>> 0aaa84207e6491bd2412b80bd7b243f04156015b
        public int Id { get; set; }

        [Display(Name = "Name", Order = 1)]
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Display(Name = "Description", Order = 2)]
        [MaxLength(100)]
        public string? Description { get; set; }

        [Display(Name = "Age restriction", Order = 3)]
        [Range(0, 100, ErrorMessage = "The value must be in {0} to {1}")]
        public int AgeRestriction { get; set; }

        [Display(Name = "Company name", Order = 4)]
        [Required]
        [MaxLength(50)]
        public string? Company { get; set; }

        [Display(Name = "Price", Order = 5)]
        [Required]
        [Range(0, 1000, ErrorMessage = "The value must be in {0} to {1}")]
        [DataType(DataType.Currency)]
<<<<<<< HEAD
        [Column(TypeName = "decimal(18,2)")]
=======
>>>>>>> 0aaa84207e6491bd2412b80bd7b243f04156015b
        public decimal Price { get; set; }
        #endregion

        #region relations
        #endregion
    }
}
