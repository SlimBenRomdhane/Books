﻿using Books.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public int DeleteBook(BookModel bookModel)
        {
            throw new NotImplementedException();
        }

        public BookModel DetailBook(int idBook)
        {
            throw new NotImplementedException();
        }

        public List<BookModel> FoundBooks(string searchParam)
        {
            throw new NotImplementedException();
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
                                Price = (double)Convert.ToDecimal( MyReader["Price"])
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