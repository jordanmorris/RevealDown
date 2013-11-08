RevealDown
==========

Summary
-------

Consistent conversion of [Markdown](http://daringfireball.net/projects/markdown/) to [Reveal.js](http://lab.hakim.se/reveal-js/) slides (via your favourite of markdown to html tool, e.g. [Pandoc](http://johnmacfarlane.net/pandoc/)).

Example usage:

    pandoc -t html5 -s TalkNotes.md | RevealDown.Cmd.exe -e > slides.html

Put the resultant html files (and any associated images) into a folder with Reveal.js

[Download Binaries](https://github.com/regexjoe/RevealDown/releases)


