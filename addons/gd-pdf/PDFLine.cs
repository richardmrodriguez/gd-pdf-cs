using Godot;
using System;
using System.IO;
using System.Collections.Generic;
using Godot.Collections;

[GlobalClass]
public partial class PDFLine : GodotObject
{
    public Godot.Collections.Array<PDFWord> PDFWords = new();

    public string GetLineString()
    {
        string newLineString = "";
        foreach (PDFWord word in PDFWords)
        {
            newLineString += word.GetWordString() + " ";
            // FIXME: obviously a naive impelementation that does not account for custom spacing or use of tabs
            // TODO: use the space between words to figure out how many character widths of space 
            // go between them
            // Or, figure out a new strategy to get horizontal lines of text or smth idk
            //GD.Print("Adding to LineString! ", newLineString);
        }

        return newLineString;
    }

    // TODO: ipmlement a func to get the line of text with actual spaces between words,

    public Vector2 GetLinePosition()
    {
        if (PDFWords.Count == 0)
        {
            GD.Print("NO WORDS");
        }


        PDFWord FirstWord = PDFWords[0];

        return FirstWord.GetPosition();

    }

    public Dictionary GetLineAsDict()
    // TODO: Serializing this Line means serializing the PDFWords 
    {
        Godot.Collections.Array WordsArray = new();
        foreach (PDFWord w in PDFWords)
        {
            WordsArray.Add(w.GetWordAsDict());
        }
        Dictionary LineDict = new()
        {
            {"pdfwords", WordsArray},
        };




        return LineDict;
    }

    public void SetLineFromDict(Dictionary LineDict)
    {
        PDFWords = new();
        foreach (Dictionary NWDict in (Array<Dictionary>)LineDict["pdfwords"])
        {
            PDFWord NewWord = new();
            NewWord.SetWordFromDict(NWDict);
            PDFWords.Add(NewWord);
        }

    }

}