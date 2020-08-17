using System;
using System.Web;

namespace CleanCode.LongMethods.RefactoredCode
{
    // As this is a WebForm, all a WebForm should do is display data, it doesn't care about where the data comes from
    // Hence encapsulated all the logic of downloading data and loading memory stream into a seperate class
    public partial class Download : System.Web.UI.Page
    {
        // Hence delegating the responsibility of reading from database and writing to csv to seperate classes
        private readonly DataTableToCsvMapper _dataTableToCsvMapper = new DataTableToCsvMapper();
        private readonly TableReader _tableReader = new TableReader();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClearResponse();

            SetCacheability();

            byte[] byteArray = GetCsv();
            WriteContentToResponse(byteArray);
        }

        private byte[] GetCsv()
        {
            System.IO.MemoryStream ms = _dataTableToCsvMapper.Map(_tableReader.GetDataTable());

            byte[] byteArray = ms.ToArray();
            ms.Flush();
            ms.Close();
            return byteArray;
        }

        private void WriteContentToResponse(byte[] byteArray)
        {
            Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
            Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
            Response.ContentType = "text/comma-separated-values";
            Response.AddHeader("Content-Disposition", "attachment; filename=FooFoo.csv");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.BinaryWrite(byteArray);
        }

        private void SetCacheability()
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.CacheControl = "private";
            Response.AppendHeader("Pragma", "cache");
            Response.AppendHeader("Expires", "60");
        }

        private void ClearResponse()
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Cookies.Clear();
        }
    }
}