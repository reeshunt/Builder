using System.Diagnostics;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilder.Models;
using SelectPdf;

namespace ResumeBuilder.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult CreateResume()
    {
        try
        {
            // instantiate the html to pdf converter
            HtmlToPdf converter = new HtmlToPdf();

            // convert the url to pdf
            PdfDocument doc = converter.ConvertUrl("https://www.google.com");

            // save pdf document
            doc.Save(".pdf");

            // close pdf document
            doc.Close();
        }
        catch (Exception ex)
        {

        }
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

