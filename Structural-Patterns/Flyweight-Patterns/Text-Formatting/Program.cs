using System;

namespace Text_Formatting
{
    class Program
    {
        static void Main(string[] args)
        {
            var formattedText = new FormattedText("This is a brave new world");
            formattedText.Capitalize(10, 15);
            Console.Write(formattedText);

            var betterFormattedText = new BetterFormattedText("This is a brave new world");
            betterFormattedText.GetRange(10, 15).Capitalize = true;
            Console.Write(betterFormattedText);
        }
    }
}