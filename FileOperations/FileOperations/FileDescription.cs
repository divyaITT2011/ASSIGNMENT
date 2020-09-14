using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations
{
	class FileDescription
	{
        public const string path = "./Data/Hello1.txt";

		public void readText()
		{
			String line;
			try
			{
				//Passing the file path and file name to the StreamReader constructor
				StreamReader sr = new StreamReader(path);

				//Read the first line of text
				line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
				{
					//write the line to console window
					Console.WriteLine(line);
					//Read the next line
					line = sr.ReadLine();
				}

				//close the file
				sr.Close();
				Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}
		}

		public void appendFile()
		{
			Console.WriteLine("File is being appended..");
			// Adding this text in the file
			try
			{
				using (StreamWriter sw = File.AppendText(path))
				{
					sw.WriteLine("\nThis is Extra Text");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}

			Console.WriteLine("File has been successfully appended..");

		}

		public int countLines()
		{
			int lines = 0;
			using (TextReader reader = File.OpenText(path))
			{
				while (reader.ReadLine() != null)
				{
					lines++;
				}
			}
			return lines;
		}

		public string lastLine()
		{
			var data = File.ReadAllLines(path);
			string last = data[data.Length - 1];
			return last;
		}

		public bool deleteFile()
		{
			if (File.Exists(path))
			{
				File.Delete(path);
				return true;
			}
			return false;
			}

	}
}
