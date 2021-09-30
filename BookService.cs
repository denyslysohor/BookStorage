using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BookStorage
{
    public class BookService
    {
        public List<Book> BookList { get; set; }

        public BookService(List<Book> books)
        {
            BookList = books;
        }

        public void Create()
        {
            Console.WriteLine("Creating a new book...");
            Console.WriteLine($"Title: ");
            Console.WriteLine($"Description: ");
            Console.WriteLine($"Author: ");
            Console.WriteLine($"Price: ");
            Console.WriteLine($"Year: ");

            Book newBook = new()
            {
                Title = Console.ReadLine().ToString(),
                Description = Console.ReadLine().ToString(),
                Author = Console.ReadLine().ToString(),
                Price = Convert.ToDecimal(Console.ReadLine()),
                Year = Convert.ToInt32(Console.ReadLine())
            };

            Console.WriteLine($"New book: {newBook.Title} has been created!");

            if (!BookList.Contains(newBook))
            BookList.Add(newBook);

            using StreamWriter streamWriter = new("BookFile.txt", append: true);

            for (int i = 0; i < BookList.Count; i++)
            {
                streamWriter.Write($"{BookList[i].Title} {BookList[i].Description} {BookList[i].Author} {BookList[i].Price} {BookList[i].Year}");;
                streamWriter.WriteLine();

            }
        }

        internal void Update()
        {
            try
            {
                Console.WriteLine("Choose a index of book");
                int index = Convert.ToInt32(Console.ReadLine());

                List<string> booksfile = File.ReadAllLines("BookFile.txt", Encoding.Default).ToList();

                Console.WriteLine($"This book - {booksfile[index - 1]}");
                Console.WriteLine("-------------------");
                Console.WriteLine("Enter new data: ");

                Console.WriteLine($"Title: ");
                Console.WriteLine($"Description: ");
                Console.WriteLine($"Author: ");
                Console.WriteLine($"Price: ");
                Console.WriteLine($"Year: ");

                Book newBook = new()
                {
                    Title = Console.ReadLine().ToString(),
                    Description = Console.ReadLine().ToString(),
                    Author = Console.ReadLine().ToString(),
                    Price = Convert.ToDecimal(Console.ReadLine()),
                    Year = Convert.ToInt32(Console.ReadLine())
                };

                booksfile[index - 1] = newBook.ToString();

                File.WriteAllLines("BookFile.txt", booksfile, Encoding.Default);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid index");
            }
        }

        public void Delete()
        {
            try
            {
                Console.WriteLine("Choose a index of book");
                int index = Convert.ToInt32(Console.ReadLine());

                List<string> booksfile = File.ReadAllLines("BookFile.txt", Encoding.Default).ToList();
                booksfile.RemoveAt(index);

                File.WriteAllLines("BookFile.txt", booksfile, Encoding.Default);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid index");
            }
        }

        public void Read()
        {
            try
            {
                const int CAPACITY = 5;

                Console.WriteLine("Choose a page (from 0)");
                int page = Convert.ToInt32(Console.ReadLine());

                int count = CAPACITY * page;

                var lines = File.ReadLines("BookFile.txt").Skip(count).Take(CAPACITY);

                foreach (var item in lines)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
