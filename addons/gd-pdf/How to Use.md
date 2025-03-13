# Basic Usage 

This module is a simple wrapper for the UglyToad PDFPig library, which exposes a simple way to get a `PDFDocGD` object which contains text data, along with the position, font size, and font name of each piece of text.

To use this, add `PDFGD` to your Autoloads under the Globals tab of your project. Make sure the assigned name matches the ALLCAPS. (So, `PDFGD` and *not* `Pdfgd`). This will ensure that the `GetDocGD()` function is exposed, as well as all the `PDFSomething` objects.

## PDFGD Usage and object structure

`PDFGD` provides access to the `GetDocGD()` function, which returns a `PDFDocGD` object. This is a Godot object, and can be used immediately in GDScript.

`PDFDocGD` is composed of `PDFPage`s.
- `PDFPage.PDFLines` is an Array of `PDFLine`s, which include text that spans the entire with of a page.	
- *NOTE*: Currently, the code that determines the bounding box by which `PDFWord`s are grouped into lines is a hardcoded magic number, which is hacky. This should be fixed in a future update to use the MediaBox width of the page instead. 

`PDFLine`.

- `GetLineString()` gives the string value of the entire line of text.
	
  - *NOTE*: This currently only separates the words by a signle space. But `PDFWords` within the line may be spaced much farther apart, like tabs or columns.
	
  - **TODO**: Add `GetLineStringProperSpacing()` func to retrieve a single string of the line which has better approximated whitespace. 

- `GetLinePosition()` gives the x,y coordinates of the text line.

Each `PDFLine` is composed of `PDFWord`s. 

- `GetWordString()` gives the string of the word.

- `GetWordPosition()` gives the x,y coordinates of the word.

Finally, each `PDFWord` is composed of `PDFLetter`s.

Each `PDFLetter` has `Str` string which represents the unicode value, as well as `Location`, `FontSize`, `PointSize`, `Width` and `GlyphRect`.
- You can get all this from a single letter in a Dictionary using `GetLetterAsDict()`.


### PDF Coordinates
The `Location` of each `PDFLetter`, and therefore any text element, is calculated  with 0, 0 being the *bottom left* of a PDF Page, whereas
in Godot (0, 0) starts at the top left of a Window. This y-axis conversion must be accounted for by the user of this wrapper (or most any
other PDF Parsing / creation library, for that matter.)

## TODO:
- Add option to extract only Whole Words (just a single string value with associated data) instead of extracting (and storing) each individual PDFLetter struct.
