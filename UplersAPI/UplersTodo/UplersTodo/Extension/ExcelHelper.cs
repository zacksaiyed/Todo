using BusinessModel.Response;
using ClosedXML.Excel;

namespace UplersTodo.Extension
{
    public class ExcelHelper
    {

        public static byte[] CreateExcelFile(Root root)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Customers");

                // Headers
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "State";
                worksheet.Cell(1, 3).Value = "Name";
                worksheet.Cell(1, 4).Value = "Email";
                worksheet.Cell(1, 5).Value = "Phone";
                worksheet.Cell(1, 6).Value = "Address";

                // Data
                for (int i = 0; i < root.Results.Count; i++)
                {
                    var result = root.Results[i];
                    worksheet.Cell(i + 2, 1).Value = result.Id;
                    worksheet.Cell(i + 2, 2).Value = result.State;
                    worksheet.Cell(i + 2, 3).Value = result.Name;
                    worksheet.Cell(i + 2, 4).Value = result.Email;
                    worksheet.Cell(i + 2, 5).Value = result.Phone;
                    worksheet.Cell(i + 2, 6).Value = result.Address;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }


        public static byte[] CreateInvoiceExcelFile(OrderResponse root)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Order");

                // Headers
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Customer  Name";
                worksheet.Cell(1, 3).Value = "Status";
                worksheet.Cell(1, 4).Value = "Classification";
                worksheet.Cell(1, 5).Value = "Distributor";
                worksheet.Cell(1, 6).Value = "Total";

                // Data
                for (int i = 0; i < root.Results.Count; i++)
                {
                    var result = root.Results[i];
                    worksheet.Cell(i + 2, 1).Value = result.Short_Id;
                    worksheet.Cell(i + 2, 2).Value = result.Customer.Display_Name;
                    worksheet.Cell(i + 2, 3).Value = result.Status;
                    worksheet.Cell(i + 2, 4).Value = result.Classification;
                    worksheet.Cell(i + 2, 5).Value = result.Distributor;
                    worksheet.Cell(i + 2, 6).Value = result.Total.Amount;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
