using System;
using System.Collections.Generic;

namespace BookStorage
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Book> bookList = new()
            {
            };

            BookService bookService = new(bookList);
            Console.WriteLine("Choose the number of function");
            Console.WriteLine("1 - Create a new book");
            Console.WriteLine("2 - Read from file");
            Console.WriteLine("3 - Update by index");
            Console.WriteLine("4 - Delete by index");

            int numOfFunc = Convert.ToInt32(Console.ReadLine());

            switch (numOfFunc)
            {
                case 1:
                    bookService.Create();

                    break;
                case 2:
                    bookService.Read();
                    break;
                case 3:
                    bookService.Update();
                    break;
                case 4:
                    bookService.Delete();
                    break;
            }
            
        }
    }
}
