using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

public class Pdf
{
    public static byte[] GenerarPDF(string contenido)
    {
        PdfDocument document = new PdfDocument();
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);

        XRect contentArea = new XRect(50, 100, page.Width - 100, page.Height - 200);

        XFont font = new XFont("Arial", 12, XFontStyle.Regular);
        XStringFormat format = new XStringFormat();

        XFont headerFont = new XFont("Arial", 16, XFontStyle.Bold);
        gfx.DrawString("Certificado Laboral", headerFont, XBrushes.Black, new XRect(0, 50, page.Width, 50), format);

        XPen pen = new XPen(XColors.Black, 1);
        gfx.DrawRectangle(pen, contentArea);

        contentArea.Inflate(-10, -10);

        // Dividir el contenido en líneas
        string[] lines = contenido.Split('\n');

        double yPosition = contentArea.Top;
        foreach (string line in lines)
        {
            XSize size = gfx.MeasureString(line, font);

            if (yPosition + size.Height > contentArea.Bottom)
            {
                // Si la línea no cabe en la página actual, agregar una nueva página
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                yPosition = contentArea.Top;
            }

            gfx.DrawString(line, font, XBrushes.Black, new XRect(contentArea.Left, yPosition, contentArea.Width, contentArea.Height), format);
            yPosition += size.Height;
        }

        using (MemoryStream ms = new MemoryStream())
        {
            document.Save(ms, false);
            return ms.ToArray();
        }
    }
}