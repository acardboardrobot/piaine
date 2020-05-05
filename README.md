﻿# PIAINE

Is é Piaine an cruthaitheoir suímh gríosain statacha .

# SETUP
```
piaine/
|-- piaine.exe
|-- paine.dll
|-- output
|   |-- index.html - Site index - generated by piaine
|   |-- blog.css
|	|-- content/
|	|	|-- image.png - Site content held here.
|   `-- posts/
|       |-- post1.html - Generated posts from txt files
|       `-- post2.html
|-- posts/
|   |-- post1.txt - Text files that are source for the posts.
|   `-- post2.txt
|-- post.html - Post template
`-- index.html - Index template
```

Sample directory structure above.
The template html files are customised for each site, and use the markup described below to insert the text from each individual posts.

# MARKUP
## Variables
{ !title } || { !date } || { !}

Variables in piaine templates are described within parentheses and identified with a ! character immediately preceding the variable. These variables are then mapped from the source content files where the content relating to a variable is defined following a colon ':'

## Links
+/TheCrowKing/+ Here+ is a sample link.

The href is defined within the first + pair. Then the link text is the text before the closing + tag. Currently links only can be defined at the start of a paragraph. This should be an easy fix, but it is not implemented yet.

## Subtitles
Subtitles are as done in markdown. # at the start of a line delimits that it should be a header or subtitle.

## Images
|sampleimage.png| alt text |

Images in piaine are defined with the file name and the alt text. The file name should be local to the content folder in the base site folder as shown in the directory structure above.
Moving of images to this content folder is currently manual.

## Templates

Templates are an optional attribute that can be added in content files. If no template attribute is found, then the post template is used, otherwise, the specified template is loaded for that single file.

# SAMPLE POST FILE
```
-title: Sample Post
-template: sampleTemplate.html
-body:
#Intro
Piaine is a simple .Net Core static website generator. Piaine is a personal project. Not really recommended for people to use. But it is simple, and it is fast.
Déanta in Éirinn, thar lear.

|testimage.png| sample image |

#Tech
Piaine is created using minimal .Net Core libraries and nothing outside of the standard libraries. As a result, it is lightweight, and also very opinionated.
#Links
So I have actually added link support to this.
+http://jpgleeson.com/+ Here+ is a link to my personal site, where I am dogfooding piaine.
```