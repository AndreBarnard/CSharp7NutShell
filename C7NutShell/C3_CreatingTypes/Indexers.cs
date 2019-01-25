using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7NutShell.C3_CreatingTypes
{
	public  class Sentence
	{
		string[] words = "The quick brown fox".Split();

		public string this[int wordNum]
		{
			get { return words[wordNum]; }
			set { words[wordNum] = value; }
		}


	}

	public class SentenceReadonlyIndexer
	{
		string[] words = "The quick brown fox".Split();

		//C# 6 to shorten its definition of above indexer
		public string this[int wordNum] => words[wordNum];


	}



}
