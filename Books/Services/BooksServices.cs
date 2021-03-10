using Bogus;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Books.Services
{
    public class BooksServices : IBooksServices
    {
        private readonly string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=BooksManagement;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=False;
            TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";

        public int AddBook(BookModel bookModel)
        {
            int Result = 0;
            string Requete = "Insert into Books (Title,Author,NumberOfPages,Genre,Price) values (@titleParam,@authorParam,@numberParam,@genreParam,@priceParam)";
            using (SqlConnection MyConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand MyCommand = new SqlCommand(Requete, MyConnection);
                MyCommand.Parameters.AddWithValue("@titleParam",bookModel.Title);
                MyCommand.Parameters.AddWithValue("@authorParam", bookModel.Author);
                MyCommand.Parameters.AddWithValue("@numberParam", bookModel.NumberOfPages);
                MyCommand.Parameters.AddWithValue("@genreParam", bookModel.Genre);
                MyCommand.Parameters.AddWithValue("@priceParam", bookModel.Price);
                try
                {
                    MyConnection.Open();
                    Result= MyCommand.ExecuteNonQuery();
                    
                }
                catch (Exception)
                {

                    Console.Beep();
                }

                //// The code is not complete yet
                return Result;
            }
        }

        public int DeleteBook(BookModel bookModel)
        {
            throw new NotImplementedException();
        }

        public BookModel DetailBook(int idBook)
        {
            throw new NotImplementedException();
        }

        public List<BookModel> FoundBooks(string searchByTilte, string searchByAuthor, string searchByGenre)
        {
            List<BookModel> Books = new List<BookModel>();
            string Requete = "Select * from Books where Title like @titleParam AND Author like @authorParam AND Genre like @genreParam";
            using (SqlConnection MyConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand MyCommand = new SqlCommand(Requete, MyConnection);
                MyCommand.Parameters.AddWithValue("@titleParam", "%" + searchByTilte + "%");
                MyCommand.Parameters.AddWithValue("@authorParam", "%" + searchByAuthor + "%");
                MyCommand.Parameters.AddWithValue("@genreParam", "%" + searchByGenre + "%");
                try
                {
                    MyConnection.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            Books.Add(new BookModel
                            {
                                Id = (int)MyReader["Id"],
                                Title = (string)MyReader["Title"],
                                Author = (string)MyReader["Author"],
                                NumberOfPages = (int)MyReader["NumberOfPages"],
                                Genre = (string)MyReader["Genre"],
                                Price = (double)Convert.ToDecimal(MyReader["Price"])
                            });
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    Console.Beep();
                }
                return Books;
            }
        }

        public List<BookModel> GetAllBooks()
        {
            List<BookModel> Books = new List<BookModel>();
            string Requete = "Select * from Books";
            using (SqlConnection MyConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand MyCommand = new SqlCommand(Requete, MyConnection);
                try
                {
                    MyConnection.Open();
                    SqlDataReader MyReader = MyCommand.ExecuteReader();
                    if (MyReader.HasRows)
                    {
                        while (MyReader.Read())
                        {
                            Books.Add(new BookModel
                            {
                                Id = (int)MyReader["Id"],
                                Title = (string)MyReader["Title"],
                                Author = (string)MyReader["Author"],
                                NumberOfPages = (int)MyReader["NumberOfPages"],
                                Genre = (string)MyReader["Genre"],
                                Price = (double)Convert.ToDecimal(MyReader["Price"])
                            });
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    Console.Beep();
                }
                return Books;
            }
        }

        public int UpdateBook(BookModel bookModel)
        {
            throw new NotImplementedException();
        }
    }
}