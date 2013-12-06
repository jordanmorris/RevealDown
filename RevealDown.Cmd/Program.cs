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
                Console.WriteLine("revealdown [-t [\"path/template.html\"]] [-l <slide level>] [-h] (stdin)");
                Console.WriteLine();
                Console.WriteLine("Pipe in input, get stdout. Extra section breaks (within a slide) are defined by adding <!----> on a line. If there are body tags in the input, only what is inside the body tags will be processed/output.");
                Console.WriteLine();
                Console.WriteLine("______________________________");
                Console.WriteLine();
                Console.WriteLine("-l <slide level> E.g. -l 2 (default 1) = specify the deepest heading level which will result in a slide break. The next level in will create section breaks within a slide.");
                Console.WriteLine();
                Console.WriteLine("-t [\"path/template.html\"] = encapsulate slides output with an html template. By default uses a built-in barebones reveal.js html template, otherwise uses the template you specify in the optional path argument. In this case the slides will be inserted immediately after the opening body tag (which must be on its own line).");
                Console.WriteLine();
                Console.WriteLine("-h = horizontal rules (---- in markdown) also to be replaced by section breaks.");
                return;
            }

            //find arguments
            var encapsulate = args.Any(arg => Regex.IsMatch(arg, @"^\-t\s*$", RegexOptions.IgnoreCase));
            var encapsulateArg = args.SkipWhile(arg => !Regex.IsMatch(arg, @"^\-t\s*$", RegexOptions.IgnoreCase))
                                    .Skip(1)
                                    .FirstOrDefault();
            if (encapsulateArg != null && encapsulateArg.StartsWith("-")) encapsulateArg = null;
            var slideLevelArg = args.SkipWhile(arg => !Regex.IsMatch(arg, @"^\-l\s*$", RegexOptions.IgnoreCase))
                                    .Skip(1)
                                    .FirstOrDefault();
            var hrBreaksSlide = args.Any(arg => Regex.IsMatch(arg, @"^\-h\s*$", RegexOptions.IgnoreCase));

            //create sectionmaker
            var sectionMaker = new SlidesMaker();

            //set sectionmaker properties based on arguments
            sectionMaker.AddHeaderFooter = encapsulate;

            TemplateProvision templateProv = null;
            if (!string.IsNullOrEmpty(encapsulateArg))
            {
                var templateFilePath = new Uri(encapsulateArg, UriKind.RelativeOrAbsolute);
                templateProv = new TemplateProvision(templateFilePath);
                sectionMaker.Header = templateProv.Header;
                sectionMaker.Footer = templateProv.Footer;
            }

            int slideLevel;
            if (int.TryParse(slideLevelArg, out slideLevel)) sectionMaker.SlideLevel = slideLevel;

            sectionMaker.HorizontalRuleBreaksSlide = hrBreaksSlide;

            //output results from sectionmaker
            var input = Console.In.ReadToEnd();
            var sections =
                sectionMaker.GetSections(input.Split(new[] {Environment.NewLine, "\r", "\n"},
                                                     StringSplitOptions.RemoveEmptyEntries));
            Console.OutputEncoding = Encoding.UTF8;
            Console.Out.Write(sections);
            Console.Out.Flush();
        }


        private static bool IsPipedInput()
        {
#if DEBUG
            return true;
#else
            try
            {
                return Console.KeyAvailable;
            }
            catch
            {
                return true;
            }
#endif
        }
    }
}
