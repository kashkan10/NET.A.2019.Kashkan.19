using System;

namespace Day19Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new TxtReader().Read();
            XmlWriter writer = new XmlWriter(arr, new StringParser());
            writer.Write();
            Console.Read();
        }
    }
}
