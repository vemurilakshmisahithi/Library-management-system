using System;
using System.Collections.Generic;

namespace LMS
{
    internal class Library
    {
        class Details
        {
            public int BookId;
            public string BookName;
            public string BookAuthor;
            public string BookPublisher;
            public int BookCount;

            public Details(int bookId, string bookName, string bookAuthor, string bookPublisher, int bookCount)
            {
                this.BookId = bookId;
                this.BookName = bookName;
                this.BookAuthor = bookAuthor;
                this.BookPublisher = bookPublisher;
                this.BookCount = bookCount;
            }
        }

        class LibrarySystem
        {
            private static int lastBookId = 0;
            List<Details> detailslist = new List<Details>();

            public void AddBook()
            {
                Console.WriteLine();
                Console.WriteLine("********************* ADD BOOK DETAILS BELOW ************************");

                Console.WriteLine();

                int bookId = ++lastBookId;

                Console.WriteLine($"Book ID: {bookId}");

                Console.Write("Enter Book Name: ");
                string bookName = Console.ReadLine();

                Console.Write("Enter Book Author: ");
                string bookAuthor = Console.ReadLine();

                Console.Write("Enter Book Publisher: ");
                string bookPublisher = Console.ReadLine();

                Console.Write("Enter No of Books: ");
                int bookCount = Convert.ToInt32(Console.ReadLine());

                Details newBook = new Details(bookId, bookName, bookAuthor, bookPublisher, bookCount);

                detailslist.Add(newBook);

                Console.WriteLine();
                Console.WriteLine("Added Book Details Successfully");
                Console.WriteLine();
            }

            public void DeleteBook()
            {
                Console.WriteLine();
                Console.WriteLine("************************ DELETE BOOK ******************************");

                Console.WriteLine();

                Console.Write("Enter Book ID: ");
                int bookId = Convert.ToInt32(Console.ReadLine());

                Details bookToRemove = detailslist.Find(book => book.BookId == bookId);

                if (bookToRemove != null)
                {
                    detailslist.Remove(bookToRemove);
                    Console.WriteLine($"Deleted Book Id {bookId} Successfully");
                }
                else
                {
                    Console.WriteLine("Book Id not Found");
                }
            }

            public void SearchBook()
            {
                Console.WriteLine();
                Console.WriteLine("********************** Search Book ************************");

                Console.WriteLine();

                Console.Write("Search by BookId : ");
                int searchbookId = Convert.ToInt32(Console.ReadLine());

                Details foundBook = detailslist.Find(book => book.BookId == searchbookId);

                if (foundBook != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Book Found. Below are the details for book id {searchbookId} ");
                    Console.WriteLine($"Book ID :{foundBook.BookId}");
                    Console.WriteLine($"Book Name :{foundBook.BookName}");
                    Console.WriteLine($"Book Author :{foundBook.BookAuthor}");
                    Console.WriteLine($"Book Publisher :{foundBook.BookPublisher}");
                    Console.WriteLine($"Book Count :{foundBook.BookCount}");
                }
                else
                {
                    Console.WriteLine("Book not Found");
                }
            }

            public void BorrowBooks()
            {
                Console.WriteLine();
                Console.WriteLine("***************************** Borrow Book *******************************");

                Console.WriteLine();

                Console.Write("Enter BookId : ");
                int BorrowBookId = Convert.ToInt32(Console.ReadLine());

                Details Borrowbook = detailslist.Find(book => book.BookId == BorrowBookId);

                if (Borrowbook != null)
                {
                    if (Borrowbook.BookCount > 0)
                    {
                        Borrowbook.BookCount--;
                        Console.WriteLine($"Book '{Borrowbook.BookName}' borrowed successfully! \nRemaining copies: {Borrowbook.BookCount}");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, all copies of '{Borrowbook.BookName}' are currently borrowed.");
                    }
                }
                else
                {
                    Console.WriteLine("Book ID not found.");
                }
            }

            public void ReturnBook()
            {
                Console.WriteLine();
                Console.WriteLine("************************* Return Book **************************");

                Console.WriteLine();

                Console.Write("Enter Book ID : ");
                int ReturnBookId = Convert.ToInt32(Console.ReadLine());

                Details returnBookbyId = detailslist.Find(book => book.BookId == ReturnBookId);
                if (returnBookbyId != null)
                {
                    Console.Write("Enter How many books you want to Return : ");
                    int ReturnBookCount = Convert.ToInt32(Console.ReadLine());

                    returnBookbyId.BookCount -= ReturnBookCount;
                    Console.WriteLine($"Book {returnBookbyId.BookName} returned successfully! Updated copies: {returnBookbyId.BookCount}");
                }
                else
                {
                    Console.WriteLine("Book ID not found.");
                }
            }

            public void UpdateBookQuantity()
            {
                Console.Write("Enter the BookId : ");
                int bookId = Convert.ToInt32(Console.ReadLine());

                Details BookToUpdate = detailslist.Find(book => book.BookId == bookId);

                if (BookToUpdate != null)
                {
                    Console.Write("Enter Book Count : ");
                    int newCount = Convert.ToInt32(Console.ReadLine());

                    BookToUpdate.BookCount += newCount;
                    Console.WriteLine($"Updated quantity of book ID {bookId} to {newCount}");
                }
                else
                {
                    Console.WriteLine("Book Quantity not updated");
                }
            }

            public void ViewAllBooks()
            {
                Console.WriteLine("*********************** View All Books ************************");

                Console.WriteLine();

                if (detailslist.Count == 0)
                {
                    Console.WriteLine("No Books Added in Library");
                }
                else
                {
                    foreach (var item in detailslist)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"BookId :  {item.BookId}");
                        Console.WriteLine($"BookName :  {item.BookName}");
                        Console.WriteLine($"BookAuthor :  {item.BookAuthor}");
                        Console.WriteLine($"BookPublisher :  {item.BookPublisher}");
                        Console.WriteLine($"BookCount :  {item.BookCount}");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }

            public void Close()
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for visiting E-library");
            }

            public bool AdminLogin()
            {
                Console.WriteLine("********************* ADMIN LOGIN ************************");
                Console.Write("Enter Admin Username: ");
                string adminUsername = Console.ReadLine();

                Console.Write("Enter Admin Password: ");
                string adminPassword = Console.ReadLine();

                if (adminUsername == "Admin@123" && adminPassword == "Admin@123")
                {
                    Console.WriteLine("Admin Login Successful");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Admin Credentials");
                    return false;
                }
            }

            public bool UserLogin()
            {
                Console.WriteLine("********************* USER LOGIN ************************");
                Console.Write("Enter Username: ");
                string userUsername = Console.ReadLine();

                Console.Write("Enter Password: ");
                string userPassword = Console.ReadLine();

                if (userUsername == "User@123" && userPassword == "User@123")
                {
                    Console.WriteLine("User Login Successful");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid User Credentials");
                    return false;
                }
            }

            public void AdminMenu()
            {
                bool select = true;

                while (select)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Add Book ");
                    Console.WriteLine("2. Delete Book ");
                    Console.WriteLine("3. Update Book Quantity ");
                    Console.WriteLine("4. View All Books ");
                    Console.WriteLine("5. Close ");

                    Console.WriteLine();

                    Console.Write("Select your Option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddBook();
                            break;
                        case "2":
                            DeleteBook();
                            break;
                        case "3":
                            UpdateBookQuantity();
                            break;
                        case "4":
                            ViewAllBooks();
                            break;
                        case "5":
                            Close();
                            select = false;
                            break;
                        default:
                            Console.WriteLine("Select only from 1-5");
                            break;
                    }
                }
            }

            public void UserMenu()
            {
                bool select = true;

                while (select)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Search Book ");
                    Console.WriteLine("2. Borrow Book ");
                    Console.WriteLine("3. Return Book ");
                    Console.WriteLine("4. View All Books ");
                    Console.WriteLine("5. Close ");

                    Console.WriteLine();

                    Console.Write("Select your Option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            SearchBook();
                            break;
                        case "2":
                            BorrowBooks();
                            break;
                        case "3":
                            ReturnBook();
                            break;
                        case "4":
                            ViewAllBooks();
                            break;
                        case "5":
                            Close();
                            select = false;
                            break;
                        default:
                            Console.WriteLine("Select only from 1-5");
                            break;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            LibrarySystem librarySystem = new LibrarySystem();

            Console.WriteLine("********************* WELCOME TO E-LIBRARY ************************");
            Console.WriteLine();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Exit");

                Console.WriteLine();
                Console.Write("Select your Option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (librarySystem.AdminLogin())
                        {
                            librarySystem.AdminMenu();
                        }
                        break;
                    case "2":
                        if (librarySystem.UserLogin())
                        {
                            librarySystem.UserMenu();
                        }
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Select only from 1-3");
                        break;
                }
            }

            Console.WriteLine("Exiting the application...");
            Console.ReadLine();
        }
    }
}
