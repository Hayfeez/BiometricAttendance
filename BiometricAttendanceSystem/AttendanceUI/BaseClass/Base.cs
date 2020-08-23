﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceUI.BaseClass
{
   public static class Base
   {
       public const string IdForSelectAll = "c94cb05a-a323-4761-9c89-ad8911239a05"; //-200;
       public const string IdForSelect = "dc3454c8-7447-49d9-8b21-dbc50395535a"; //-300;

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

        public static DataTable ConvertToDataTable<T>(this List<T> iList)
        {
            var dT = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);

                dT.Columns.Add(propertyDescriptor.Name, type);

            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (var iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }

                dT.Rows.Add(values);
            }

            return dT;
        }

        public static void AddEditDeleteToGrid(ref DataGridView dataGrid, bool noItems)
        {
            //TODO: check if the columns exist, don't add otherwise add

            if (noItems)
                return;

            //Edit link
            var editlink = new DataGridViewLinkColumn
            {
                UseColumnTextForLinkValue = true,
                HeaderText = "Edit",
                DataPropertyName = "lnkColumn",
                LinkBehavior = LinkBehavior.SystemDefault,
                Text = "Edit"
            };

            //Delete link
            var deletelink = new DataGridViewLinkColumn
            {
                UseColumnTextForLinkValue = true,
                HeaderText = "Delete",
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
                HeaderText = "Delete",
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
    }
}
