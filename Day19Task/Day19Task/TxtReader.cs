using System;
using System.IO;

namespace Day19Task
{
    class TxtReader
    {
        private string path;

        /// <summary>
        /// Default constructor
        /// </summary>
        public TxtReader()
        {
            path = "doc.txt";
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="path"></param>
        public TxtReader(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Read from file
        /// </summary>
        /// <returns>array of strings</returns>
        public string[] Read()
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path).Split();
            }
            else throw new Exception("File is not found");
        }
    }
}
