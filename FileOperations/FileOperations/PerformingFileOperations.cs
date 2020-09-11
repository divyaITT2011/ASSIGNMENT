using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations
{
	class VariousFileOperations
	{
	   public static void Main(String[] args)
		{
			FileDescription fileOperations = new FileDescription();
			Console.WriteLine("Enter the total number of Operations to be performed ");
			String NoOperations = Console.ReadLine();
			int noOperations = Convert.ToInt32(NoOperations);
			Console.WriteLine("Total Operations to be performed: " + noOperations);

			while (noOperations > 0)
			{
				Console.WriteLine("Enter 1 to Count total number of lines");
				Console.WriteLine("Enter 2 to Last line");
				Console.WriteLine("Enter 3 to Append file");
				Console.WriteLine("Enter 4 to Read text from file");
				Console.WriteLine("Enter 5 to Delete file");

				String Input = Console.ReadLine();
				int input = Convert.ToInt32(Input);
				switch (input)
				{
					case 1:
						int counts = fileOperations.countLines();
						Console.WriteLine("Total number of lines in file are:" + counts);
						break;

					case 2:
						string lastL = fileOperations.lastLine();
						Console.WriteLine("Last line of the file is:" + lastL);
						break;

					case 3:
						Console.WriteLine("File is being appended..");
						fileOperations.appendFile();
						Console.WriteLine("File has been successfully appended..");
						break;
								
					case 4:
						fileOperations.createFileAndAddText();
						Console.WriteLine("Text has been successfully read from the file..");
						break;
															
					case 5:
						bool result=fileOperations.deleteFile();
						Console.WriteLine("File has been successfully deleted:"+result);
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