using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

public class Pdf
{
    public static byte[] GenerarPDF(string contenido)
    {
        // Crear un nuevo documento PDF
        PdfDocument document = new PdfDocument();

        // Agregar una página al documento
        PdfPage page = document.AddPage();

        // Obtener el objeto XGraphics para dibujar en la página
        XGraphics gfx = XGraphics.FromPdfPage(page);

        // Definir una fuente y un formato para el texto
        XFont font = new XFont("Arial", 12, XFontStyle.Regular);
        XStringFormat format = new XStringFormat();

        // Dibujar el contenido en la página
        gfx.DrawString(contenido, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), format);

        // Crear un MemoryStream para almacenar el PDF
        using (MemoryStream ms = new MemoryStream())
        {
            // Guardar el documento en el MemoryStream
            document.Save(ms, false);

            // Convertir el MemoryStream a un array de bytes y devolverlo
            return ms.ToArray();
        }
    }
}