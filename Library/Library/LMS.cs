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
				Console.WriteLine("Enter 6 to exit");

				int input = Convert.ToInt32(Console.ReadLine());
				switch (input)
				{
					case 1:
						bookOperations.addBook();
						break;

					case 2:
						bookOperations.deleteBook();
						break;

					case 3:
						bookOperations.listBooks();
						break;

                    case 4:
						bookOperations.searchBook();
						break;

					case 5:
						bookOperations.updateBook();
						break;

					case 6:
						return;

					default:
						Console.WriteLine("Invalid operation..!");
						break;
				}

				noOperations = noOperations - 1;
			}
		}
	}
}