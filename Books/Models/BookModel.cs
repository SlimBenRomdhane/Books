using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class BookModel
    {
        [Display(Name = "The Book Reference :")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Title :")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Written By :")]
        public string Author { get; set; }

        [Display(Name = "Number Of Pages is :")]
        [Range(50, 1000)]
        public int NumberOfPages { get; set; }

        [Required]
        [Display(Name = "Genre/s is/are")]
        public string Genre { get; set; }

        [Display(Name = "Selling Price")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}