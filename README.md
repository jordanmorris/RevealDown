RevealDown
==========

Summary
-------

Consistent conversion of [Markdown](http://daringfireball.net/projects/markdown/) to [Reveal.js](http://lab.hakim.se/reveal-js/) slides (via your favourite markdown to html tool, e.g. [Pandoc](http://johnmacfarlane.net/pandoc/) or [Marked](https://github.com/chjj/marked))

### Use Examples

``` bash
pandoc -t html5 -s TalkNotes.md | RevealDown.Cmd.exe -t > TalkSlides.html
```

``` bash
cat TalkNotes.md | marked | revealdown -t template.html -l 2 > TalkSlides.html
```

Put the resultant html file (and any associated images) somewhere with a folder named `reveal.js`, containing the reveal.js files.

---

&nbsp; | &nbsp; | &nbsp;

[Download Binaries](https://github.com/regexjoe/RevealDown/releases)

### Samples (WIP)

<!-- have to have these weird dummy headers in so github will recognise it as a table -->
<!---> | <!---> | <!--->
--- | --- | ---
*Still* | `renders` | **nicely**
1 | 2 | 3


Usage
-----
Note, RevealDown only outputs the `<div>` containing the slides themselves (no html/body tags), unless you specify the `-t` switch.

``` bash
revealdown [-t ["path/template.html"]] [-l <slide level>] [-h] (stdin)

Pipe in input, get stdout. Extra section breaks (within a slide) are
defined by adding `<!---->` on a line. If there are body tags in the 
input, only what is inside the body tags will be processed/output.
______________________________   

-l <slide level> E.g. -l 2 (default 1) = specify the deepest heading 
level which will result in a slide break. The next level in will 
create section breaks within a slide.

-t ["path/template.html"] = encapsulate slides output with an html 
template. By default uses a built-in barebones reveal.js html 
template, otherwise uses the template you specify in the optional 
path argument. In this case the slides will be inserted immediately 
after the opening body tag (which must be on its own line).

-h = horizontal rules (---- in markdown) also to be replaced by 
section breaks.
```

[Mono](http://www.mono-project.com) compatible.

Templates
---------
Templates are nothing special. Just create an html file with your desired reveal.js setup. Specify the filename with the `-t` tag and RevealDown will output the html with the slides div inserted immediately below the opening `body` tag. You will of course need to bring the required includes with you (.css, .js files, etc.).

There is one pre-made template in the source. It includes [highlight.js](http://highlightjs.org/) and turns it on with marked syntax class name support.

Philosophy
----------
Although RevealDown is intended for markdown users, it actually parses html. I was having a lot of trouble getting consistent results from other parsers which attempt to create reveal.js slides directly from markdown. I then realised there is a lot more predictability in html generated from markdown than there is in markdown itself. RevealDown capitalises on that fact.

<!---->

The linux-like approach of piping with other parsers has other happy consequences, like how your choice of markdown to html parser is not restricted to those which directly support reveal.js slide output (or any slide output). 

Other important decisions involved how to manage slide divisions. In this I have tried to support a purist markdown approach, or the use of dividers which are at least silent in html output.

Improvements I would make, given the time:
-----------------------------------------
- Rewrite it in a functional language. It turns out the task is more suited to that.
- Parse based on actual XML elements instead of line-by-line.
- Better application of SOLID principles.  
