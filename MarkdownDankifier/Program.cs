using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdownDankifier
{
    class MainClass
    {
        public static string fixedString;
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
                ">");
            string inputText = Console.ReadLine();
            if (FilterAndFixMarkdown(inputText))
            {
                Environment.Exit(1);
            }
            Console.WriteLine(fixedString);
        }
        public static bool FilterAndFixMarkdown(string input)
        {
            List<Fixes> fixesToApply = new List<Fixes>();
            if (input.Contains("-"))
            {
                Console.Write("We found a hyphen (-) in your text. If this is a markdown list, then note that this app will mess it up.\n" +
                    "We can, however, convert your hyphen to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character." +
                    "\n>");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    fixesToApply.Add(Fixes.Hyphen);
                }
                if (!(response == "yes" | response == "repair"))
                {
                    return true;
                }
            } // Catch markdown lists
            if (input.Contains("*"))
            {
                Console.Write("We found an asterisk (*) in your text. If this is a markdown formatting mark, then note that this app will mess it up.\n" +
                	"We can, however, convert your formatting mark to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character." +
                    "\n>");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    fixesToApply.Add(Fixes.Asterisk);
                }
                if (!(response == "yes" | response == "repair"))
                {
                    return true;
                }
            } // Catch markdown asterisks
            if (input.Contains("_"))
            {
                Console.Write("We found an underscore (_) in your text. If this is a markdown formatting mark, then note that this app will mess it up.\n" +
                    "We can, however, convert your formatting mark to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character." +
                    "\n>");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    fixesToApply.Add(Fixes.Underscore);
                }
                if (!(response == "yes" | response == "repair"))
                {
                    return true;
                }
            } // Catch markdown underscores
            if (input.Contains("`"))
            {
                Console.Write("We found a backtick (`) in your text. If this is a markdown code block, then note that this app will mess it up.\n" +
                    "We can, however, convert your backtick to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character." +
                    "\n>");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    fixesToApply.Add(Fixes.Backtick);
                }
                if (!(response == "yes" | response == "repair"))
                {
                    return true;
                }
            } // Catch markdown code blocks
            if (input.Contains("#"))
            {
                Console.Write("We found a hashtag (#) in your text. If this is a markdown header, then note that this app will mess it up.\n" +
                    "We can, however, convert your backtick to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character." +
                    "\n>");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    fixesToApply.Add(Fixes.Hashtag);
                }
                if (!(response == "yes" | response == "repair"))
                {
                    return true;
                }
            } // Catch markdown headers
            if (input.Contains("\\"))
            {
                Console.Write("We found a backslash (\\) in your text. If this is a markdown escape character, then note that this app will mess it up.\n" +
                    "We can, however, convert your backslash to a plaintext character." +
                    "Type \"yes\" to continue,\n" +
                    "or type \"repair\" to turn it into a plaintext character." +
                    "\n>");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    fixesToApply.Add(Fixes.Backslash);
                }
                if (!(response == "yes" | response == "repair"))
                {
                    return true;
                }
            } // Catch markdown escapes
            FixMarkdown(input, fixesToApply);
            return false;
        }
        public static string FixMarkdown(string input, List<Fixes> fixes)
        {
            fixedString = input;
            if (fixes.Contains(Fixes.Backslash))
            {
                StringBuilder sb = new StringBuilder(fixedString);
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "\\")
                    {
                        sb.Insert(i++, Char.Parse("\\"));
                        i++;
                    }
                }
                fixedString = sb.ToString();
            } // Escape backslashes FIRST, so that escapes added below won't be turned into '\' characters
            
            // Escape things below
            if (fixes.Contains(Fixes.Hyphen))
            {
                StringBuilder sb = new StringBuilder(fixedString);
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "-")
                    {
                        sb.Insert(i++, Char.Parse("\\"));
                        i++;
                    }
                }
                fixedString = sb.ToString();
            } // Escape hyphens
            if (fixes.Contains(Fixes.Asterisk))
            {
                StringBuilder sb = new StringBuilder(fixedString);
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "*")
                    {
                        sb.Insert(i++, Char.Parse("\\"));
                        i++;
                    }
                }
                fixedString = sb.ToString();
            } // Escape asterisks
            if (fixes.Contains(Fixes.Underscore))
            {
                StringBuilder sb = new StringBuilder(fixedString);
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "_")
                    {
                        sb.Insert(i++, Char.Parse("\\"));
                        i++;
                    }
                }
                fixedString = sb.ToString();
            } // Escape underscores
            if (fixes.Contains(Fixes.Backtick))
            {
                StringBuilder sb = new StringBuilder(fixedString);
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "`")
                    {
                        sb.Insert(i++, Char.Parse("\\"));
                        i++;
                    }
                }
                fixedString = sb.ToString();
            } // Escape backticks
            if (fixes.Contains(Fixes.Hashtag))
            {
                StringBuilder sb = new StringBuilder(fixedString);
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "#")
                    {
                        sb.Insert(i++, Char.Parse("\\"));
                        i++;
                    }
                }
                fixedString = sb.ToString();
            } // Escape hashtags
            // Escape things above
            
            return fixedString;
            // PROBLEM: NEED TO INCREMENT i EVERY TIME IT LOOPS IN THE FOR, BUT I CAN'T FIGURE OUT HOW TO DO IT
        }
    }
    enum Fixes
    {
        Hyphen,
        Asterisk,
        Underscore,
        Backtick,
        Hashtag,
        Backslash
    }
}
