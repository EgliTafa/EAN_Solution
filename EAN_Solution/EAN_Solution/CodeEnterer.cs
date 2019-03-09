using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EAN_Solution
{
	public class CodeEnterer
	{

			
		public static void Submit ()
		{
			var linesPrefixes = File.ReadAllLines(@"C: \Users\Egli\Documents\EAN_Solution\EAN_Solution\list_prefixes.txt");
			List<string> textFile = linesPrefixes.ToList ();
			string[] textFileArray = textFile.ToArray ();

			var linesCountry = File.ReadAllLines(@"C: \Users\Egli\Documents\EAN_Solution\EAN_Solution\list_countries.txt");
			List<string> textFileCountry = linesCountry.ToList ();
			string[] textCountryArray = textFileCountry.ToArray ();
			
			Console.Write ("Enter your code: ");
			string prefix = null;
			string mfnCode = null;
			string checkDigit = null;
			string eanCode;
			eanCode = Convert.ToString(Console.ReadLine ());


			if (eanCode.Length == 13) 
			{
				prefix = eanCode.Substring (0, 3);
				mfnCode = eanCode.Substring (3,5);
				checkDigit = eanCode.Substring (12);
			}

			if (eanCode.Length == 13 && linesPrefixes.Contains (prefix) == true)
			{
				Console.WriteLine ();
				Console.WriteLine ("Your code is valid.");
				Console.WriteLine ();
				Console.WriteLine ("The GS1 prefix is: " + prefix);
				Console.WriteLine ();
				Console.WriteLine ("The MFN Code is: " + mfnCode);
				Console.WriteLine ();
				Console.WriteLine ("The Check Digit is: " + checkDigit);
				Console.WriteLine ();

			}

			else
			{
				Console.WriteLine ("Your code is invalid.");
				Console.WriteLine ();
			}
				
			var index = Array.FindIndex(textFileArray, row => row.Contains(prefix));

			var countryIndex = textCountryArray[index];

			Console.WriteLine ("Your country is: " + countryIndex);
			Console.WriteLine ();

		}


	}
}
	