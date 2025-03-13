using Godot;
using System;
using System.IO;
using System.Collections.Generic;
using Godot.Collections;

[GlobalClass]
public partial class PDFPage : GodotObject
{
    public Vector2 PageSizeInPoints = new(); // TODO: rename to "MediaBox" 
    public Array<PDFLine> PDFLines = new(); // horizontal lines of text


}