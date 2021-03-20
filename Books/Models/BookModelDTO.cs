using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class BookModelDTO
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

        public string PriceString { get; set; }
        public double Tax { get; set; }
        public int NumberOfChapters { get; set; }
        public string ShortDescription { get; set; }

        public BookModelDTO(int id, string title, string author, int numberOfPages, double price)
        {
            Id = id;
            Title = title;
            Author = author;
            NumberOfPages = numberOfPages;
            Price = price;
            PriceString = price.ToString() + "$";
            Tax = Price * 0.18;
            NumberOfChapters = numberOfPages / 20;
            ShortDescription = "This book is an " + Genre + " one";
        }

        public BookModelDTO(BookModel book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            NumberOfPages = book.NumberOfPages;
            Genre = book.Genre;
            Price = book.Price;
            PriceString = Price.ToString() + "$";
            Tax = (Price * 0.18);
            NumberOfChapters = NumberOfPages / 20;
            ShortDescription = "This book is an " + Genre + " one";
        }
    }
}