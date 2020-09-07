using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	class LMS
	{
      

        public static void Main(String[] args)
		{
			Operations bookOperations = new Operations();
			Console.WriteLine("Enter the total number of Operations to be performed ");
			String NoOperations = Console.ReadLine();
			int noOperations = Convert.ToInt32(NoOperations);
			Console.WriteLine("Total Operations to be performed: " + noOperations);

			while (noOperations > 0)
			{
				Console.WriteLine("Enter 1 to add the books in the library");
				Console.WriteLine("Enter 2 to remove the books in the library");
				Console.WriteLine("Enter 3 to print the books available in the library");
				Console.WriteLine("Enter 4 to search for a book in the library");
				Console.WriteLine("Enter 5 to update a books in the library");
				
				String Input = Console.ReadLine();
				int input = Convert.ToInt32(Input);
				switch (input)
				{
					case 1:
						
						Console.WriteLine("Enter the book name");
						String b_name = Console.ReadLine();
						Console.WriteLine("Enter the book id");
						String b_id = Console.ReadLine();
						int bb_id = Convert.ToInt32(b_id);
						Console.WriteLine("Enter the book type");
						String b_type = Console.ReadLine();
						Console.WriteLine("Enter the book's author name");
						String b_authour = Console.ReadLine();
						Console.WriteLine("Enter the number of pages in the book");
						String b_pages = Console.ReadLine();
						int bb_pages = Convert.ToInt32(b_pages);
						Console.WriteLine("Enter the book's publisher name");
						String b_pub = Console.ReadLine();
						Console.WriteLine("Adding books in the library");
						bookOperations.addBook(b_name, bb_id, b_type, b_authour, bb_pages, b_pub);
						break;

					case 2:
						Console.WriteLine("Enter book's name that need to be deleted");
						String bookTodelete = Console.ReadLine();
						Console.WriteLine("Deleting books in the library");
						bookOperations.deleteBook(bookTodelete);
						break;

					case 3:
						Console.WriteLine("Printing all the books");
						bookOperations.listBooks();
						break;

                    case 4:
						Console.WriteLine("Enter book's name that needs to be searched");
						String bookToSearch = Console.ReadLine();
						Console.WriteLine("Searching for the book");
						bookOperations.searchBook(bookToSearch);
						break;

					case 5:
						Console.WriteLine("Enter book's name that needs to be updated");
						String bookToBeUpdated = Console.ReadLine();
						Console.WriteLine("Enter new publisher's name");
						String pubUpdated = Console.ReadLine();
						Console.WriteLine("Updating the book");
						bookOperations.updateBook(bookToBeUpdated, pubUpdated);
						break;

					default:
						Console.WriteLine("Invalid operation..!");
						break;
				}
				noOperations = noOperations - 1;
			}
		}
	}
}