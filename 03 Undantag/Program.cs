using System;

namespace _03_Undantag
{
    public class InvalidPrinterMarginsException : Exception
    {
        public InvalidPrinterMarginsException() { }
        public InvalidPrinterMarginsException(string msg) : base(msg) { }
        public InvalidPrinterMarginsException(string msg, Exception innerException) 
            : base(msg, innerException) { }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new InvalidPrinterMarginsException("Marginalerna är för små");
            }
            catch (InvalidPrinterMarginsException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
    }
}
