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

		public void addBook()
		{
			Console.WriteLine("Enter the book name");
			String b_name = Console.ReadLine();
			Console.WriteLine("Enter the book id");
			int bb_id = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the book type");
			String b_type = Console.ReadLine();
			Console.WriteLine("Enter the book's author name");
			String b_authour = Console.ReadLine();
			Console.WriteLine("Enter the number of pages in the book");
			int bb_pages = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the book's publisher name");
			String b_pub = Console.ReadLine();
			Console.WriteLine("Enter the book's price");
			int b_price = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Adding books in the library");
			Book book = new Book();
			book.setBookName(b_name);
			book.setBookId(bb_id);
			book.setBookType(b_type);
			book.setBookAuthor(b_authour);
			book.setBookPages(bb_pages);
			book.setbookPub(b_pub);
			book.setPrice(b_price);
			books.Add(book);
			Console.WriteLine("Book is Successfully added..!");
		}

		public void deleteBook()
		{
			Console.WriteLine("Enter book's name that need to be deleted");
			String bookTodelete = Console.ReadLine();
			Console.WriteLine("Deleting books in the library");
			foreach (Book book in books)
			{
				if (book.getBookName().Equals(bookTodelete))
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

		public void searchBook()
		{
			Console.WriteLine("Enter book's name that needs to be searched");
			String bookToSearch = Console.ReadLine();
			Console.WriteLine("Searching for the book");
			foreach (Book book in books)
			{
				if (book.getBookName().Equals(bookToSearch))
				{
					Console.WriteLine("Book is available..");
					int BID= book.getBookId();
					Console.WriteLine("Book Id:"+BID);
					String BPUB = book.getbookPubl();
					Console.WriteLine("Book Publisher:" + BPUB);
					String BNAME = book.getBookName();
					Console.WriteLine("Book Name:- " + BNAME);
					String BTYPE = book.getBookType();
					Console.WriteLine("Book Type:- " + BTYPE);
					String BAUTH = book.getBookAuthor();
					Console.WriteLine("Book Author:- " + BAUTH);
					int BPAGES = book.getBookPages();
					Console.WriteLine("Book Pages:- " + BPAGES);
					break;
				}
                else
                {
					Console.WriteLine("No such book is available..");
				}
			}
			
		}

		public void updateBook()
		{
			Console.WriteLine("Enter book's name that needs to be updated");
			String BOOKTOBEUPDATED = Console.ReadLine();
			Console.WriteLine("Enter new publisher's name");
			String PUBTOBEUPDATED = Console.ReadLine();
			Console.WriteLine("Updating the book");
			foreach (Book book in books)
			{
				if (book.getBookName().Equals(BOOKTOBEUPDATED))
				{
					Console.WriteLine("Book is Available..!");
					book.bookPublisher = PUBTOBEUPDATED;
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
				int bookID = book.getBookId();
				Console.WriteLine("Book ID:- " + bookID);
				String bookType = book.getBookType();
				Console.WriteLine("Book Type:- " + bookType);
				String bookAuthor = book.getBookAuthor();
				Console.WriteLine("Book Author:- " + bookAuthor);
				String bookPublisher = book.getbookPubl();
				Console.WriteLine("Book Publisher:- " + bookPublisher);
				int bookPages = book.getBookPages();
				Console.WriteLine("Book Pages:- " + bookPages);
			}
		}
	}
}
