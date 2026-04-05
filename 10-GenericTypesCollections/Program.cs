using _10_GenericTypesCollections.Models;

namespace _10_GenericTypesCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book()
            {
                Id = 1,
                Title = "Martin Eden",
                Author = "Jack London",
                Year = 1909,
                PageCount = 400
            };
            Book book2 = new Book()
            {
                Id = 2,
                Title = "1984",
                Author = "George Orwell",
                Year = 1949,
                PageCount = 328
            };
            Book book3 = new Book()
            {
                Id = 3,
                Title = "Animal Farm",
                Author = "George Orwell",
                Year = 1945,
                PageCount = 112
            };
            Book book4 = new Book()
            {
                Id = 4,
                Title = "Ağ Gemi",
                Author = "Cingiz Aytmatov",
                Year = 1970,
                PageCount = 200
            };
            Book book5 = new Book()
            {
                Id = 5,
                Title = "Qırıq Budaq",
                Author = "Elçin",
                Year = 1998,
                PageCount = 350
            };

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();

            Console.WriteLine("________________________");
            Console.WriteLine();

            Member member = new Member();

            member.BorrowBook(book1);
            member.BorrowBook(book2);
            member.BorrowBook(book3);
            member.BorrowBook(book4);
            member.BorrowBook(book5);

            member.ReturnBook(2);

            member.DisplayBorrowedBooks();

            Console.WriteLine("________________________");
            Console.WriteLine();

            Library<Book> library = new Library<Book>("Milli Kitabxana");

            Console.WriteLine("Milli Kitabxana:");

            library.Add(book1);
            library.Add(book2);
            library.Add(book3);
            library.Add(book4);
            library.Add(book5);

            Console.WriteLine($"Kitab Sayi: {library.Count()}");
            
            var indexedbook = library.FindByIndex(0);
            if (indexedbook != null ) Console.WriteLine($"IndexedBook0: {indexedbook.Title}");
            else Console.WriteLine("Bele bir element yoxdur");

            var indexedbook1 = library.FindByIndex(2);
            if (indexedbook != null ) Console.WriteLine($"IndexedBook2: {indexedbook1.Title}");
            else Console.WriteLine("Bele bir element yoxdur");

            foreach (var book in library.GetAll())
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine("________________________");
            Console.WriteLine();

            List<Member> members = new List<Member>();

            Member members1 = new Member()
            {
                Id = 1,
                Name = "Ali Məmmədov",
                Email = "ali@mail.com"
            };

            Member members2 = new Member()
            {
                Id = 2,
                Name = "Leyla Həsənova",
                Email = "leyla@mail.com"
            };

            Member members3 = new Member()
            {
                Id = 3,
                Name = "Vüqar Əliyev",
                Email = "vuqar@mail.com"
            };

            members.Add(members1);
            members.Add(members2);
            members.Add(members3);

            members2.BorrowBook(book1);
            members2.BorrowBook(book2);
            members2.DisplayBorrowedBooks();
            members2.ReturnBook(1);
            members2.DisplayBorrowedBooks();
            members3.BorrowBook(book3);
            members3.BorrowBook(book4);
            members3.BorrowBook(book5);
            members3.BorrowBook(book2);


            Console.WriteLine("________________________");
            Console.WriteLine();

            BookManager bookManager = new BookManager();

            bookManager.AddBook(book1);
            bookManager.AddBook(book2);
            bookManager.AddBook(book3);
            bookManager.AddBook(book4);
            bookManager.AddBook(book5);


            var books = bookManager.GetBooksByAuthor("George Orwell");

            foreach(var book in books)
            {
                Console.WriteLine(book.Title);
            }

            var books2 = bookManager.GetBooksByAuthor("Cingiz Aytmatov");
            foreach(var book in books2)
            {
                bookManager.AddToWaitingQueue(book.Author);
            }

            var books3 = bookManager.GetBooksByAuthor("Jack London");

            foreach (var book in books3)
            {
                bookManager.AddToWaitingQueue(book.Author);
            }

            var books4 = bookManager.GetBooksByAuthor("Dostoyevski");
            if (books4.Count == 0)
            {
                Console.WriteLine("0 kitab tapildi");
            }

            Console.WriteLine("________________________");
            Console.WriteLine();

            bookManager.WaitingQueue.Clear();

            bookManager.AddToWaitingQueue("Nigar");
            bookManager.AddToWaitingQueue("Reşad");
            bookManager.AddToWaitingQueue("Sebine");

            Console.WriteLine($"Novbede {bookManager.WaitingQueue.Count} nefer var");
            string servedPerson = bookManager.ServeNextInQueue();
            Console.WriteLine($"Xidmet edilir: {servedPerson}");

            Console.WriteLine($"Novbede {bookManager.WaitingQueue.Count} nefer var");
            string servedPerson1 = bookManager.ServeNextInQueue();
            Console.WriteLine($"Xidmet edilir: {servedPerson1}");

            Console.WriteLine($"Novbede {bookManager.WaitingQueue.Count} nefer var");
            string servedPerson2 = bookManager.ServeNextInQueue();
            Console.WriteLine($"Xidmet edilir: {servedPerson2}");

            Console.WriteLine($"Novbede {bookManager.WaitingQueue.Count} nefer var");

            Console.WriteLine("________________________");
            Console.WriteLine();

            bookManager.ReturnBook(book1);
            bookManager.ReturnBook(book2);
            bookManager.ReturnBook(book3);

            Console.WriteLine($"Stackde {bookManager.RecentlyReturned.Count} kitab var");

            Book lastReturnedBook = bookManager.GetLastReturnedBook();
            Console.WriteLine($"book3: {lastReturnedBook.Title}");

            bookManager.RecentlyReturned.Pop();
            Console.WriteLine($"Stackde {bookManager.RecentlyReturned.Count} kitab var");

            Book lastReturnedBook1 = bookManager.GetLastReturnedBook();
            Console.WriteLine($"book2: {lastReturnedBook1.Title}");

            Console.WriteLine("________________________");
            Console.WriteLine();

            Book searchedBook = bookManager.SearchByTitle("1984");

            if (searchedBook != null)
            {
                Console.WriteLine($"Tapilan kitab: {searchedBook.Title}");
            }
            else
            {
                Console.WriteLine("Kitab Tapilmadi");
            }

            Book searchedBook1 = bookManager.SearchByTitle("Harry Potter");

            if (searchedBook1 != null)
            {
                Console.WriteLine($"Tapilan kitab: {searchedBook1.Title}");
            }
            else
            {
                Console.WriteLine("Kitab Tapilmadi");
            }

            Console.WriteLine("________________________");
            Console.WriteLine();

            Console.WriteLine($"Ümumi kitab sayı: {books.Count}");
            Console.WriteLine($"Ümumi üzv sayı: {members.Count}");
            Console.WriteLine($"Növbede nefer sayı: {bookManager.WaitingQueue.Count}");
            Console.WriteLine($"Stack-de kitab sayı: {bookManager.RecentlyReturned.Count}");

            int minYear = int.MaxValue;

            foreach (var book in bookManager.Books)
            {
                if(book.Year < minYear) minYear = book.Year;
            }

            Console.WriteLine($"En kohne kitabin ili: {minYear}");

            int maxYear = int.MinValue;

            foreach(var book in bookManager.Books)
            {
                if (book.Year > maxYear) maxYear = book.Year;
            }

            Console.WriteLine($"En yeni kitabin ili: {maxYear}");
        }
    }
}
