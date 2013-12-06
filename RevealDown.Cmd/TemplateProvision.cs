using System;
using System.IO;
using System.Text;

namespace RevealDown.Cmd
{
    internal class TemplateProvision
    {
        public TemplateProvision(Uri sourceFileUri)
        {
            PopulateHeaderFooter(sourceFileUri);
        }


        public string Header { get; private set; }
        public string Footer { get; private set; }


        private void PopulateHeaderFooter(Uri sourceFileUri)
        {
            var templateLines = File.ReadAllLines(sourceFileUri.ToString());
            var header = new StringBuilder();
            var footer = new StringBuilder();
            var headerFinished = false;
            foreach (var tl in templateLines)
            {
                if (headerFinished)
                {
                    footer.AppendLine(tl);
                }
                else
                {
                    header.AppendLine(tl);
                    headerFinished = SlidesMaker.BodyLineRegex.IsMatch(tl);
                }
            }
            Header = header.ToString();
            Footer = footer.ToString();
        }
    }
}
