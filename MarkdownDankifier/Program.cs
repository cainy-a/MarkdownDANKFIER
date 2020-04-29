using System;
using System.Collections.Generic;

namespace MarkdownDankifier
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "-------------------------------------------------------\n" +
                "Markdown DANKIFIER by Cain Atkinson\n" +
                "(https://cainy-a.github.io, https://github.com/cainy-a)\n" +
                "-------------------------------------------------------");
            System.Threading.Thread.Sleep(500);
            Console.Write(
            "\nPlease Enter the text you wish to DANKIFY at the prompt below.\n" +
                "Please note that the input text should be PLAIN TEXT or " +
                "this app will do funky things to existing formatting, and the " +
                "output will be markdown\n" +
                ">");
            string inputText = Console.ReadLine();

        }
        public static bool FilterMarkdown(string input)
        {
            if (input.Contains("-"))
            {
                Console.Write("We found a hyphen (-) in your text. If this is a markdown list, then note that this app will mess it up.\n" +
                    "We can, however, convert your hyphen to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character.");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    throw new NotImplementedException();
                }
                if (response != "yes" || response == "repair")
                {
                    return true;
                }
            } // Catch markdown lists
            if (input.Contains("*"))
            {
                Console.Write("We found an asterisk (*) in your text. If this is a markdown formatting mark, then note that this app will mess it up.\n" +
                	"We can, however, convert your formatting mark to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character.");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    throw new NotImplementedException();
                }
                if (response != "yes" || response == "repair")
                {
                    return true;
                }
            } // Catch markdown asterisks
            if (input.Contains("_"))
            {
                Console.Write("We found an underscore (_) in your text. If this is a markdown formatting mark, then note that this app will mess it up.\n" +
                    "We can, however, convert your formatting mark to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character.");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    throw new NotImplementedException();
                }
                if (response != "yes" || response == "repair")
                {
                    return true;
                }
            } // Catch markdown underscores
            if (input.Contains("`"))
            {
                Console.Write("We found a backtick (`) in your text. If this is a markdown code block, then note that this app will mess it up.\n" +
                    "We can, however, convert your backtick to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character.");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    throw new NotImplementedException();
                }
                if (response != "yes" || response == "repair")
                {
                    return true;
                }
            } // Catch markdown code blocks
            if (input.Contains("#"))
            {
                Console.Write("We found a hashtag (#) in your text. If this is a markdown header, then note that this app will mess it up.\n" +
                    "We can, however, convert your backtick to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character.");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    throw new NotImplementedException();
                }
                if (response != "yes" || response == "repair")
                {
                    return true;
                }
            } // Catch markdown headers
            if (input.Contains("\\"))
            {
                Console.Write("We found a backslash (\\) in your text. If this is a markdown escape character, then note that this app will mess it up.\n" +
                    "We can, however, convert your backslash to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character.");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    throw new NotImplementedException();
                }
                if (response != "yes" || response == "repair")
                {
                    return true;
                }
            } // Catch markdown escapes
            return false;
        }
        public static string FixMarkdown(string input, List<Fixes> fixes)
        {
            return String.Empty;
        }
    }
    enum Fixes
    {
        hyphen,
        asterisk,
        underscore,
        backtick,
        hashtag,
        backslash
    }
}
