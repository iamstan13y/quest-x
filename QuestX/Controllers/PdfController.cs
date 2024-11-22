using Microsoft.AspNetCore.Mvc;
using QuestX.Services;

namespace QuestX.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PdfController(PdfService pdfService) : ControllerBase
{
    private readonly PdfService _pdfService = pdfService;

    [HttpGet("generate")]
    public IActionResult GeneratePdf()
    {
        var pdf = _pdfService.GenerateSamplePdf();
        return File(pdf, "application/pdf", "sample.pdf");
    }
}