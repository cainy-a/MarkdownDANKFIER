using System;
using System.Collections.Generic;
using System.Text;

namespace MarkdownDankifier
{
    public partial class MainClass
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
                ">");
            string inputText = Console.ReadLine();
            string filteredText = FilterAndFixMarkdown(inputText, out var exit);
            if (exit)
            {
                Environment.Exit(1);
            }
            string dankifiedText = DankifyText(filteredText);
            Console.WriteLine($"\n\nYour DANKIFIED text, in markdown format, is:\n{dankifiedText}");
            Console.ReadKey();
        }
        public static string FilterAndFixMarkdown(string input, out bool exit)
        {
            List<Fixes> fixesToApply = new List<Fixes>();
            if (
                input.Contains("-") ||
                input.Contains("*") ||
                input.Contains("_") ||
                input.Contains("`") ||
                input.Contains("#") ||
                input.Contains("\\"))
            {
                Console.Write(
                    "We found some markdown characters in your text. If these are formatting marks, then note that this app will mess it up.\n" +
                    "We can, however, convert these into plaintext characters.\n" +
                    "Type \"choose\" to convert some,\n" +
                    "or type \"repair\" to convert all of them." +
                    "\n>");
                var response = Console.ReadLine();
                if (response == "repair")
                {
                    fixesToApply.Add(Fixes.Hyphen);
                    fixesToApply.Add(Fixes.Asterisk);
                    fixesToApply.Add(Fixes.Backslash);
                    fixesToApply.Add(Fixes.Backtick);
                    fixesToApply.Add(Fixes.Hashtag);
                    fixesToApply.Add(Fixes.Underscore);
                    exit = false;
                    return FixMarkdown(input, fixesToApply);
                }
                else if (response != "choose")
                {
                    exit = true;
                    return input;
                }
            }

            if (input.Contains("-"))
            {
                Console.Write("We found a hyphen (-) in your text. If this is a markdown list, then note that this app will mess it up.\n" +
                    "We can, however, convert your hyphen to a plaintext character.\n" +
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
                    exit = true;
                    return input;
                }
            } // Catch markdown lists
            if (input.Contains("*"))
            {
                Console.Write("We found an asterisk (*) in your text. If this is a markdown formatting mark, then note that this app will mess it up.\n" +
                	"We can, however, convert your formatting mark to a plaintext character.\n" +
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
                    exit = true;
                    return input;
                }
            } // Catch markdown asterisks
            if (input.Contains("_"))
            {
                Console.Write("We found an underscore (_) in your text. If this is a markdown formatting mark, then note that this app will mess it up.\n" +
                    "We can, however, convert your formatting mark to a plaintext character.\n" +
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
                    exit = true;
                    return input;
                }
            } // Catch markdown underscores
            if (input.Contains("`"))
            {
                Console.Write("We found a backtick (`) in your text. If this is a markdown code block, then note that this app will mess it up.\n" +
                    "We can, however, convert your backtick to a plaintext character.\n" +
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
                    exit = true;
                    return input;
                }
            } // Catch markdown code blocks
            if (input.Contains("#"))
            {
                Console.Write("We found a hashtag (#) in your text. If this is a markdown header, then note that this app will mess it up.\n" +
                    "We can, however, convert your backtick to a plaintext character.\n" +
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
                    exit = true;
                    return input;
                }
            } // Catch markdown headers
            if (input.Contains("\\"))
            {
                Console.Write("We found a backslash (\\) in your text. If this is a markdown escape character, then note that this app will mess it up.\n" +
                    "We can, however, convert your backslash to a plaintext character.\n" +
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
                    exit = true;
                    return input;
                }
            } // Catch markdown escapes
            exit = false;
            return FixMarkdown(input, fixesToApply);
        }
        public static string FixMarkdown(string input, List<Fixes> fixes)
        {
            string fixedString = input;
            if (fixes.Contains(Fixes.Backslash))
            {
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "\\")
                    {
                        fixedString = fixedString.Insert(i++, "\\");
                    }
                }
            } // Escape backslashes FIRST, so that escapes added below won't be turned into '\' characters
            
            // Escape things below
            if (fixes.Contains(Fixes.Hyphen))
            {
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "-")
                    {
                        fixedString = fixedString.Insert(i++, "\\");
                    }
                }
            } // Escape hyphens
            if (fixes.Contains(Fixes.Asterisk))
            {
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "*")
                    {
                        fixedString = fixedString.Insert(i++, "\\");
                    }
                }
            } // Escape asterisks
            if (fixes.Contains(Fixes.Underscore))
            {
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "_")
                    {
                        fixedString = fixedString.Insert(i++, "\\");
                    }
                }
            } // Escape underscores
            if (fixes.Contains(Fixes.Backtick))
            {
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "`")
                    {
                        fixedString = fixedString.Insert(i++, "\\");
                    }
                }
            } // Escape backticks
            if (fixes.Contains(Fixes.Hashtag))
            {
                for (int i = 0; i < fixedString.Length; i++)
                {
                    string currentChar = fixedString[i].ToString();
                    if (currentChar == "#")
                    {
                        fixedString = fixedString.Insert(i++, "\\");
                    }
                }
            } // Escape hashtags
            // Escape things above
            
            return fixedString;
        }
    }

    public enum Fixes
    {
        Hyphen,
        Asterisk,
        Underscore,
        Backtick,
        Hashtag,
        Backslash
    }
}
