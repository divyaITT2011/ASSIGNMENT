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
        public const string Path = "C:/Users/divya.singh/Desktop/demo/testFile.txt";

		public void createFileAndAddText()
		{
			String line;
			try
			{
				//Passing the file path and file name to the StreamReader constructor
				StreamReader sr = new StreamReader(Path);

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
			finally
			{
				Console.WriteLine("Executing finally block.");
			}
		}

		public void appendFile()
		{
			// Adding this text in the file
			try
			{
				using (StreamWriter sw = File.AppendText(Path))
				{
					sw.WriteLine("This");
					sw.WriteLine("is Extra");
					sw.WriteLine("Text");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}
			
		}

		public int countLines()
		{
			int lines = 0;
			using (TextReader reader = File.OpenText(Path))
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
			var data = File.ReadAllLines(Path);
			string last = data[data.Length - 1];
			return last;
		}

		public bool deleteFile()
		{
			if (File.Exists(Path))
			{
				File.Delete(Path);
				return true;
			}
			return false;
			}

	}
}
