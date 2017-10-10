using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcivy.Data.Dapper.Extensions
{
    /// <summary>
    /// IDataReader扩展
    /// </summary>
    public static class DataReaderExtensions
    {
        /// <summary>
        /// IDataReader转DataTable
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this IDataReader reader)
        {
            DataTable tb = new DataTable();
            DataColumn col;
            DataRow row;
            int i;

            for (i = 0; i < reader.FieldCount; i++)
            {
                col = new DataColumn();
                col.ColumnName = reader.GetName(i);
                col.DataType = reader.GetFieldType(i);
                tb.Columns.Add(col);
            }

            while (reader.Read())
            {
                row = tb.NewRow();
                for (i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader[i];
                }
                tb.Rows.Add(row);
            }
            return tb;
        }
    }
}
