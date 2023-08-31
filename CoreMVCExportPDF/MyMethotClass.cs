using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMVCExportPDF
{
    public class MyMethotClass
    {
        public static  FileResult GeneratePDF<T>(IEnumerable<T> data, string[] propertyNames, string[] columnHeaders)
        {
            StringBuilder sb = new StringBuilder();

            
            sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-family: Arial; font-size: 10pt;'>");
            sb.Append("<tr>");
            foreach (string header in columnHeaders)
            {
                sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>");
                sb.Append(header);
                sb.Append("</th>");
            }
            sb.Append("</tr>");

            foreach (T item in data)
            {
                sb.Append("<tr>");
                foreach (string propertyName in propertyNames)
                {
                    object value = item.GetType().GetProperty(propertyName).GetValue(item);
                    sb.Append("<td style='border: 1px solid #ccc'>");
                    sb.Append(value);
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString())))
            {
                MemoryStream pdfStream = new MemoryStream();
                PdfWriter writer = new PdfWriter(pdfStream);
                PdfDocument pdfDocument = new PdfDocument(writer);
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                HtmlConverter.ConvertToPdf(stream, pdfDocument);
                pdfDocument.Close();

                return new FileContentResult(pdfStream.ToArray(), "application/pdf")
                {
                    FileDownloadName = "Grid.pdf"
                };
            }
        }
    }
}
