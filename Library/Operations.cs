using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    class Operations
    {
		public System.Collections.ArrayList books;
		public Operations()
		{
			this.books = new ArrayList();
		}

		public void addBook(String bookName, int bookId, String bookType, String bookAuthour, int bookPages, String bookPublisher)
		{
			Book newBook = new Book(bookName, bookId, bookType, bookAuthour, bookPages, bookPublisher);
			books.Add(newBook);
			Console.WriteLine("Book is Successfully added..!");
		}

		public void deleteBook(String bookName)
		{
			foreach (Book book in books)
			{
				if (book.getBookName().Equals(bookName))
				{
					books.Remove(book);
					Console.WriteLine("Book is Successfully deleted..!");
					break;
				}
				else
				{
					Console.WriteLine("Invalid book Name");
					break;
				}

			}
			Console.WriteLine("No book is available in Library");
		}

		public void searchBook(String bookName)
		{
			foreach (Book book in books)
			{
				if (book.getBookName().Equals(bookName))
				{
					Console.WriteLine("Book is available..");
					int BID= book.getBookId();
					Console.WriteLine("Book Id:"+BID);
					String BPUB = book.getBookPublisher();
					Console.WriteLine("Book Publisher:" + BPUB);
					break;
				}
                else
                {
					Console.WriteLine("No such book is available..");
				}
			}
			
		}

		public void updateBook(String name, String publisher)
		{
			foreach (Book book in books)
			{
				if (book.getBookName().Equals(name))
				{
					Console.WriteLine("Book is Available..!");
					book.bookPublisher = publisher;
					Console.WriteLine("Publisher's name has been updated successfully..!");
					break;
				}
				else
				{
					Console.WriteLine("Book is not available for update");
				}
			}
		}

		public void listBooks()
		{
			Console.WriteLine("Listing down all books in system");
			foreach (Book book in books)
			{
				String bookName = book.getBookName();
				Console.WriteLine("Book Name:- " + bookName);
			}
		}
	}
}
