namespace RevealDown.Cmd
{
    internal static class Constants
    {
        internal const string RevealJsHeader = @"<!doctype html>
<html lang=""en"">

	<head>
		<meta charset=""utf-8"">

		<title>reveal.js - Barebones</title>

		<link rel=""stylesheet"" href=""css/reveal.min.css"">
		<link rel=""stylesheet"" href=""css/theme/default.css"" id=""theme"">
	</head>

	<body>

		<div class=""reveal"">

			<div class=""slides"">
";

        internal const string RevealJsFooter = @"
</div>

		</div>

		<script src=""lib/js/head.min.js""></script>
		<script src=""js/reveal.min.js""></script>

		<script>

			Reveal.initialize();

		</script>

	</body>
</html>";

    }
}
