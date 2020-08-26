using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClosedXML.Excel;

namespace AttendanceUI.BaseClass
{
   public static class Base
   {
       public const string IdForSelectAll = "c94cb05a-a323-4761-9c89-ad8911239a05";
       public const string IdForSelect = "dc3454c8-7447-49d9-8b21-dbc50395535a";


        #region Datatable Conversions
        
        private static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }

        private static T CreateItem<T>(this DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here
                        throw;
                    }
                }
            }

            return obj;
        }

        private static IList<T> ConvertTo<T>(this IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }
       
        public static IList<T> ConvertToList<T>(this DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        public static DataTable ConvertToDataTable<T>(this IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        //public static DataTable ConvertToDataTable<T>(this List<T> iList)
        //{
        //    var dT = new DataTable();
        //    PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(T));
        //    for (int i = 0; i < propertyDescriptorCollection.Count; i++)
        //    {
        //        PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
        //        Type type = propertyDescriptor.PropertyType;

        //        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        //            type = Nullable.GetUnderlyingType(type);

        //        dT.Columns.Add(propertyDescriptor.Name, type);

        //    }
        //    object[] values = new object[propertyDescriptorCollection.Count];
        //    foreach (var iListItem in iList)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
        //        }

        //        dT.Rows.Add(values);
        //    }

        //    return dT;
        //}

        
        #endregion

        #region Alerts

        public static void ShowInfo(string caption, string text)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string caption, string text)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string caption, string text)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK);
        }

        public static DialogResult ShowDialog(MessageBoxButtons buttons, string caption, string text)
        {
            return MessageBox.Show(text, caption, buttons, MessageBoxIcon.Warning);
        }

        #endregion

        #region GridView

        
        public static void AddEditDeleteToGrid(ref DataGridView dataGrid, bool noItems)
        {
            //TODO: check if the columns exist, don't add otherwise add

            if (noItems)
                return;

            //Edit link
            var editlink = new DataGridViewLinkColumn
            {
                UseColumnTextForLinkValue = true,
                HeaderText = "",
                DataPropertyName = "lnkColumn",
                LinkBehavior = LinkBehavior.SystemDefault,
                Text = "Edit"
            };

            //Delete link
            var deletelink = new DataGridViewLinkColumn
            {
                UseColumnTextForLinkValue = true,
                HeaderText = "",
                DataPropertyName = "lnkColumn",
                LinkBehavior = LinkBehavior.SystemDefault,
                Text = "Delete"
            };

            if (!dataGrid.Columns.Contains(editlink.Text))
                dataGrid.Columns.Add(editlink);

            if (!dataGrid.Columns.Contains(deletelink.Text))
                dataGrid.Columns.Add(deletelink);

        }

        public static void AddDeleteToGrid(ref DataGridView dataGrid, bool noItems)
        {
            //TODO: check if the columns exist, don't add otherwise add

            if (noItems)
                return;

            //Delete link
            var deletelink = new DataGridViewLinkColumn
            {
                UseColumnTextForLinkValue = true,
                HeaderText = "",
                DataPropertyName = "lnkColumn",
                LinkBehavior = LinkBehavior.SystemDefault,
                Text = "Delete"
            };

            if (!dataGrid.Columns.Contains(deletelink.Text))
                dataGrid.Columns.Add(deletelink);

        }

        public static void ResizeGrid(ref DataGridView grd,
         ref DataTable dt)
        {
            try
            {
                int width = grd.RowHeadersWidth;
                grd.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Green;
                grd.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                grd.ColumnHeadersHeight = 30;
                grd.ClearSelection();
                grd.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                grd.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                grd.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkGreen;
                grd.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                grd.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Green;
                grd.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
                // grd.Dock = DockStyle.None;
                int index = 0;
                //foreach (DataGridViewColumn col in grd.Columns)
                //{
                //    if (dt != null)
                //    {
                //        if (dt.Columns[index].DataType == typeof(System.Int32) ||
                //            dt.Columns[index].DataType == typeof(System.Int64) ||
                //            dt.Columns[index].DataType == typeof(System.Double) ||
                //            dt.Columns[index].DataType == typeof(System.Decimal))
                //        {
                //            if (dt.Columns[index].DataType == typeof(System.Double))
                //            {
                //                col.DefaultCellStyle.Format = "N2";
                //            }
                //            else
                //            {
                //                col.DefaultCellStyle.Format = "N0";
                //            }
                //            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //        }
                //    }
                //    index++;
                //    width += col.Width;
                //}

                if (width < grd.Width)
                {
                    int ind = 0;
                    foreach (DataGridViewColumn col in grd.Columns)
                    {
                        if (ind > 0) col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        ++ind;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void ResizeGrid(ref DataGridView grd)
        {
            try
            {
                int width = grd.RowHeadersWidth;
                grd.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                grd.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                grd.ColumnHeadersHeight = 30;

                grd.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                grd.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                grd.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Aqua;
                grd.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Red;
                grd.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Black;
                grd.RowHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Aqua;
                // grd.Dock = DockStyle.None;
                grd.ClearSelection();

                if (width < grd.Width)
                {
                    int ind = 0;
                    foreach (DataGridViewColumn col in grd.Columns)
                    {
                        if (ind > 0) col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        ++ind;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static DataTable SearchGrid(DataTable dT, string searchString)
        {
            try
            {
                if (dT != null)
                {
                    List<string> headers = new List<string>();

                    foreach (DataColumn dC in dT.Columns)
                    {
                        if (dC.DataType == typeof(string))
                        {
                            headers.Add(dC.ColumnName.Replace(" ", ""));
                        }
                    }

                    string filterString = "";
                    for (int i = 0; i < headers.Count; i++)
                    {
                        if (i == headers.Count - 1)
                            filterString += $"{headers[i].ToString()} like '%{searchString}%'";

                        else
                            filterString += $"{headers[i].ToString()} like '%{searchString}%' or ";
                    }

                    var rows = dT.Select(filterString);
                    if (rows.Length > 0)
                    {
                        return rows.CopyToDataTable();
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        #endregion

        #region Excel 

        public static bool SaveAsExcel(DataTable data, string reportName)
        {
            try
            {
                var file = new SaveFileDialog()
                {
                    Filter = "Excel Files|*.xlsx;",
                    FileName = $"{reportName}.xlsx"
                };

                if (file.ShowDialog() == DialogResult.OK)
                {
                    XLWorkbook wb = new XLWorkbook();
                    wb.Worksheets.Add(data, reportName);
                    wb.SaveAs(file.FileName);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ReadExcelFile(string filePath)
        {
            try
            {
                DataTable dt = new DataTable();

                //Started reading the Excel file.  
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);
                    bool FirstRow = true;

                    //Range for reading the cells based on the last cell used.  
                    string readRange = "1:1";
                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        //If Reading the First Row (used) then add them as column name  
                        if (FirstRow)
                        {
                            //Checking the Last cellused for column generation in datatable  
                            readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }

                            FirstRow = false;
                        }
                        else
                        {
                            //Adding a Row in datatable  
                            dt.Rows.Add();
                            int cellIndex = 0;

                            //Updating the values of datatable  
                            foreach (IXLCell cell in row.Cells(readRange))
                            {
                                dt.Rows[dt.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                cellIndex++;
                            }
                        }
                    }
                }

                return dt;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
