RevealDown
==========

Summary
-------

Consistent conversion of [Markdown](http://daringfireball.net/projects/markdown/) to [Reveal.js](http://lab.hakim.se/reveal-js/) slides (via your favourite markdown to html tool, e.g. [Pandoc](http://johnmacfarlane.net/pandoc/)).

Example usage:

    pandoc -t html5 -s TalkNotes.md | RevealDown.Cmd.exe -e > slides.html

Put the resultant html file (and any associated images) into a folder with Reveal.js

[Download Binaries](https://github.com/regexjoe/RevealDown/releases)

Usage
-----
`RevealDown.Cmd.exe [-e] [-l <slide level>] [-h] (stdin)`  
Pipe in input, get stdout.  
`-l <slide level> E.g. -l 2 (default 1)` = specify the deepest heading level which will result in a slide break. The next level in will create section breaks within a slide.  
`-e` = encapsulate sections output with barebones reveal.js html template  
`-h` = horizontal rules (`----` in markdown) to be replaced by section break. Section breaks (within a slide) can also always be added by putting `<!---->` on a line.  
