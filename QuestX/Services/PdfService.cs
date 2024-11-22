using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestX.Services;

public class PdfService
{
    public byte[] GenerateSamplePdf()
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Inch);
                page.Header().Text("Sample PDF").Bold().FontSize(20).AlignCenter();
                page.Content().Column(column =>
                {
                    column.Item().Text("This is a sample paragraph in the PDF.");
                    column.Item().Image(Placeholders.Image(100, 100));
                });
                page.Footer().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                    x.Span(" of ");
                    x.TotalPages();
                });
            });
        }).GeneratePdf();
    }
}