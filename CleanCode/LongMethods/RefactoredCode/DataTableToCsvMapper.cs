using System;
using System.Data;
using System.IO;

namespace CleanCode.LongMethods.RefactoredCode
{
    // Hence now this class is highly Cohesive as it only converts DataTable To Csv and nothing else
    // Also each and every method is cohesive as well
    // Room for improvement:
    // - Use using statements while creating memory stream and writing to it in Map method
    // - Create a type with Datatable and index and rename parameters dt and i to reduce the number of parameters in method
    class DataTableToCsvMapper
    {
        public System.IO.MemoryStream Map(DataTable dataTable)
        {
            MemoryStream memoryStream = new MemoryStream();

            StreamWriter sw = new StreamWriter(memoryStream);
            WriteColumnNames(dataTable, sw);
            WriteRows(dataTable, sw);
            sw.Flush();
            sw.Close();

            return memoryStream;
        }

        private static void WriteRows(DataTable dt, StreamWriter sw)
        {
            foreach (DataRow dr in dt.Rows)
            {
                WriteRow(dt, dr, sw);
                sw.WriteLine();
            }
        }

        private static void WriteRow(DataTable dt, DataRow dr, StreamWriter sw)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                WriteCell(dr, i, sw);

                WriteSeperatorIfRequired(dt, i, sw);
            }
        }

        private static void WriteSeperatorIfRequired(DataTable dt, int i, StreamWriter sw)
        {
            if (i < dt.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }

        private static void WriteCell(DataRow dr, int i, StreamWriter sw)
        {
            if (!Convert.IsDBNull(dr[i]))
            {
                string str = String.Format("\"{0:c}\"", dr[i].ToString()).Replace("\r\n", " ");
                sw.Write(str);
            }
            else
            {
                sw.Write("");
            }
        }

        private static void WriteColumnNames(DataTable dt, StreamWriter sw)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < dt.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.WriteLine();
        }
    }
}