using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {

		public String bookName;
		public int bookId;
		public String bookType;
		public String bookAuthour;
		public int bookPages;
		public String bookPublisher;

		public Book(String bookName, int bookId, String bookType, String bookAuthour, int bookPages, String bookPublisher)
		{

			this.bookName = bookName;
			this.bookId = bookId;
			this.bookType = bookType;
			this.bookAuthour = bookAuthour;
			this.bookPages = bookPages;
			this.bookPublisher = bookPublisher;
		}

		public String getBookName()
		{
			return bookName;
		}

		public int getBookId()
		{
			return bookId;
		}

		public String getBookType()
		{
			return bookType;
		}

		public String getBookAuthor()
		{
			return bookAuthour;
		}

		public String getBookPublisher()
		{
			return bookPublisher;
		}

		public int getBookPages()
		{
			return bookPages;
		}
	}
}
