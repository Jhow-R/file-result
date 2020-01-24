using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace MVC_FileResult.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /* FileResult é uma classe abstrata derivada de ActionResult que delega escrita do arquivo no response às subclasses.
           Contém um único método abstrato chamado WriteFile que cada subclasse deve implementar.
           Esta classe faz o trabalho de adicionar cabeçalhos Content-Type e Content-Disposition no response.
           Existem três classes embutidas que implementam FileResult:
           1. FilePathResult
           2. FileContentResult
           3. FileStreamResult
        */


        // Permite exibir ou baixar um arquivo de formato genérico a partir de uma localização
        public FileResult Download()
        {
            // ReadAllBytes: Abre o arquivo, lê o conteúdo, salva em um array de bytes e fecha o arquivo 
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"c:\caminho_arquivo\nome_arquivo.txt");
            string fileName = "meuArquivo.txt";

            // MediaTypeNames.Application:  especifica o tipo de dados do aplicativo em um anexo de email.
            return File(fileBytes, MediaTypeNames.Application.Octet, fileName);
        }

        // Exibe ou baixa um arquivo PDF de um determinado local no servidor
        public FileResult ArquivoFilePathResult()
        {
            string fileName = @"c:\caminho_arquivo\nome_arquivo.txt";
            string contentType = "application/pdf";

            return new FilePathResult(fileName, contentType);
        }

        // Exibe ou baixa um arquivo PDF a partir da pasta Arquivos da aplicação
        public ActionResult AquivoPDF()
        {
            return File("/Arquivos/nome_aquivo.pdf", "application/pdf");
        }

        // Exibe ou baixa um arquivo WAV a partir da pasta Arquivos da aplicação
        public ActionResult AquivoWAV()
        {
            return File("/Arquivos/nome_aquivo.wav", "audio/x-wav");
        }

        // Exibe ou baixa um arquivo RTF a partir da pasta Arquivos da aplicação
        public ActionResult AquivoRTF()
        {
            return File("/Arquivos/nome_aquivo.rtf", "application/msword");
        }


    }
}