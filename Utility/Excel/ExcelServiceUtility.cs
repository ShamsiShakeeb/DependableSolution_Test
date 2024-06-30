using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Excel
{
    public class ExcelServiceUtility : IExcelServiceUtility
    {
        public (bool success, string? base64, string? message, string? errorMessage) ListToExcelBase64<T,T1>(string SheetName, List<string> HeaderName, List<string> HeaderName2, List<T> Rows, List<T1> Rows2) where T : class where T1 : class
        {
            try
            {
                using XLWorkbook xLWorkbook = new XLWorkbook();
                IXLWorksheet iXLWorksheet = xLWorkbook.Worksheets.Add(SheetName);

                int div = 1;

                for (int i = 0; i < HeaderName.Count; i++)
                {
                    iXLWorksheet.Cell(1, i + 1).Value = HeaderName[i];
                    iXLWorksheet.Cell(1, i + 1).Style.Font.Bold = true;
                   
                }
              
                for (int j = 1; j <= Rows.Count; j++)
                {
                    int num = 1;
                    T val = Rows[j - 1];
                    PropertyInfo[] properties = val.GetType().GetProperties();
                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        propertyInfo.GetValue(val, null);
                        iXLWorksheet.Cell(j + 1, num).Value = propertyInfo.GetValue(val, null);
                        num++;
                    }
                    div++;
                }
                div = div + 2;

                for (int i = 0; i < HeaderName2.Count; i++)
                {
                    iXLWorksheet.Cell(div, i + 1).Value = HeaderName2[i];
                    iXLWorksheet.Cell(div, i + 1).Style.Font.Bold = true;
                }

                for (int j = 1; j <= Rows2.Count; j++)
                {
                    int num = 1;
                    T1 val = Rows2[j - 1];
                    PropertyInfo[] properties = val.GetType().GetProperties();
                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        propertyInfo.GetValue(val, null);
                        iXLWorksheet.Cell(div+j, num).Value = propertyInfo.GetValue(val, null);
                        num++;
                    }
                }

                MemoryStream memoryStream = new MemoryStream();
                xLWorkbook.SaveAs(memoryStream);
                string item = Convert.ToBase64String(memoryStream.ToArray());
                return (true, item, "Base 64 File created from List", null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
    }
}
