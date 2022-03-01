using System;

namespace PrintDiamond
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Wrong number of parameters - add one alphabetic letter");
                return;
            }
            var param = args[0];
            var character = param[0];
            if (!char.IsLetter(character))
            {
                Console.WriteLine("Wrong parameter - has to be alphabetic letter");
                return;
            }

            // TODO print diamond
        }
    }
}
