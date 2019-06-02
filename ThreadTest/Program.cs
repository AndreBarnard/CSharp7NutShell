using System;
using System.Threading;

namespace ThreadTest
{
  class Program
  {
    static void Main(string[] args)
    {
      Thread t = new Thread(WriteY); // Kick off a new thread
      t.Start();
      t.Join();
      Console.WriteLine("Thread t has ended");
    }

    static void WriteY()
    {
      for (int i = 0; i < 1000; i++) Console.Write("y");
    }
  }
}
