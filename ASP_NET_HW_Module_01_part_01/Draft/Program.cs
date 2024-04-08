using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draft
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//DateTime today = DateTime.Today;
			//Console.WriteLine($"Today is {GetDate().ToString("dd-MM-yyyy")}");
			//int dsa = GetRandom();
			//Console.WriteLine($" random number is {dsa}");

		}
        static public DateTime GetDate()
        {
            DateTime today = DateTime.Today;
            return today;
        }
        static public int GetDay()
        {
            DateTime today = DateTime.Today;
            return today.DayOfYear;
        }
		static int GetRandom()
		{
			Random random = new Random();
            int asd = random.Next(26);
            return asd;
		} 
        static char GetLetter(int position) 
        {
			char[] Letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
							'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
			char letter = Letters[position];
            return letter;
        }
	}
}
