extends Node

func _ready() -> void:
	var doc: PDFDocGD = PDFGD.GetDocGD("/home/rich/Downloads/pdfs/VCR2L-2024-04-16.pdf")
	for page: PDFPage in doc.PDFPages:
		for line: PDFLine in page.PDFLines:
			print(
			"%20s" % ("%.2v" % line.GetLinePosition()),
			"%4s" % " ",
			line.GetLineString()
			)
			#for word in line.PDFWords:
				#print(word.GetWordString())
