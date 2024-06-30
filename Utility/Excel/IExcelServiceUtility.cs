namespace Utility.Excel
{
    public interface IExcelServiceUtility
    {
        (bool success, string? base64, string? message, string? errorMessage) ListToExcelBase64<T, T1>(string SheetName, List<string> HeaderName, List<string> HeaderName2, List<T> Rows, List<T1> Rows2) where T : class where T1 : class;
    }
}
