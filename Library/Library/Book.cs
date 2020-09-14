using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book : Publication
    {

		public String bookName;
		public int bookId;
		public String bookType;
		public String bookAuthour;
		public int bookPages;
		

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

		public int getBookPages()
		{
			return bookPages;
		}

		public void setBookName(String bookName)
		{
			this.bookName = bookName;
		}
		

		public void setBookId(int bookId)
		{
			this.bookId = bookId;
		}

		public void setBookType(String bookType)
		{
			this.bookType = bookType;
		}

		public void setBookAuthor(String bookAuthour)
		{
			this.bookAuthour = bookAuthour;
		}

		public void setBookPages(int bookPages)
		{
			this.bookPages = bookPages;
		}
	}
}
