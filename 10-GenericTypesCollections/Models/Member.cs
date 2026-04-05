using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_GenericTypesCollections.Models
{
    public class Member
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; } 

        public Member()
        {
            BorrowedBooks = new List<Book>();
        }

        public Member(int id, string name, string email):this()
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }




        public void BorrowBook(Book book)
        {
            if(BorrowedBooks.Count < 3)
            {
                BorrowedBooks.Add(book);
                Console.WriteLine($"Kitab Goturuldu {book.Title}");
            }
            else
            {
                Console.WriteLine("Maksimum 3 kitab götüre bilersiniz!");
            }
        }

        public void ReturnBook(int bookId)
        {
            foreach(var book in BorrowedBooks.ToList())
            {
                if (book.Id == bookId)
                {
                    BorrowedBooks.Remove(book);
                    Console.WriteLine($"Kitab qaytarıldı: {book.Title}");
                }
            }
        }

        public void DisplayBorrowedBooks()
        {
            if(BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Borc kitab yoxdur");
            }
            else
            {
                foreach (var book in BorrowedBooks)
                {
                    Console.WriteLine($"Borc goturulmus kitab: {book.Title}");
                }
            }
        }
    }
}
