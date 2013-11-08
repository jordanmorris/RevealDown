using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RevealDown.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!IsPipedInput())
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("RevealDown.Cmd.exe [-e] [-l <slide level>] [-h] (stdin)");
                Console.WriteLine("Pipe in input, get stdout. Extra section breaks (within a slide) are defined by adding <!----> on a line.");
                Console.WriteLine("-l <slide level> E.g. -l 2 (default 1) = specify the deepest heading level which will result in a slide break. The next level in will create section breaks within a slide.");
                Console.WriteLine("-e = encapsulate sections output with barebones reveal.js html template");
                Console.WriteLine("-h = horizontal rules (hr tag) to be replaced by slidebreaks (---- in markdown)");
                return;
            }

            var encapsulate = args.Any(arg => Regex.IsMatch(arg, @"^\-e\s*$", RegexOptions.IgnoreCase));
            var slideLevelArg = args.SkipWhile(arg => !Regex.IsMatch(arg, @"^\-l\s*$", RegexOptions.IgnoreCase))
                                    .Skip(1)
                                    .FirstOrDefault();
            var hrBreaksSlide = args.Any(arg => Regex.IsMatch(arg, @"^\-h\s*$", RegexOptions.IgnoreCase));

            var sectionMaker = new SectionMaker();

            sectionMaker.AddHeaderFooter = encapsulate;
            int slideLevel;
            if (int.TryParse(slideLevelArg, out slideLevel)) sectionMaker.SlideLevel = slideLevel;
            sectionMaker.HorizontalRuleBreaksSlide = hrBreaksSlide;

            var input = Console.In.ReadToEnd();
            var sections = sectionMaker.GetSections(input.Split(new[] { Environment.NewLine }, StringSplitOptions.None));

            Console.OutputEncoding = Encoding.UTF8;
            Console.Out.Write(sections);
            Console.Out.Flush();
        }


        private static bool IsPipedInput()
        {
            try
            {
                var isKey = Console.KeyAvailable;
                Console.Out.Write("<!-- isKey={0} -->", isKey);
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
