using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyExcelLAB
{
    public partial class Form1 : Form
    {
        Data DATA = new Data();
        public Form1()
        {
            InitializeComponent();
            CreateDataGridView( DATA.ColCount,DATA.RowCount);


        }
         private void CreateDataGridView(int columns,int rows)
        {
            for(int i=0;i<columns;++i)
            {
                string colname = _26BasedSystem.To26System(i);
                DGV.Columns.Add(colname, colname);
                DGV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DGV.RowCount = rows;
            for(int i=0;i<rows;++i)
            {
                DGV.Rows[i].HeaderCell.Value = i.ToString();
            }
        }


        private void Enter_Click(object sender, EventArgs e)
        {
            int col = DGV.SelectedCells[0].ColumnIndex;
            int row = DGV.SelectedCells[0].RowIndex;
            string expr = TableOut.Text;
            if(expr=="")
            {
                return;
            }
            DATA.ChangeCellCompletely(row, col, expr, DGV);
            DGV[col, row].Value = DATA.data[row][col].Value;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = DGV.SelectedCells[0].ColumnIndex;
            int row = DGV.SelectedCells[0].RowIndex;
            string expression = DATA.data[row][col].Expression;
            string value = DATA.data[row][col].Value;
            TableOut.Text = expression;
            TableOut.Focus();
        }

 
        
        private void AddColumn_Click(object sender, EventArgs e)
        {
            string colname = _26BasedSystem.To26System(DATA.ColCount);
            DGV.Columns.Add(colname, colname);
            DGV.Columns[colname].SortMode= DataGridViewColumnSortMode.NotSortable;
            DATA.AddColumn();
        }

        private void AddRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if(DGV.Columns.Count==0)
            {
                MessageBox.Show("Не має колонок!");
                return;
            }
            DGV.Rows.Add(row);
            DGV.Rows[DATA.RowCount].HeaderCell.Value = DATA.RowCount.ToString();
            DATA.AddRow();
        }

        private void DeleteColumn_Click(object sender, EventArgs e)
        {
            int curcol = DATA.ColCount - 1;
            if(!DATA.DeleteCol())
            {
                return;
            }
            DGV.Columns.RemoveAt(curcol);
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            int rowCurrent = DATA.RowCount - 1;
            if (!DATA.DeleteRow())
                return;
            DGV.Rows.RemoveAt(rowCurrent);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter= "GridFile|*.grd";
            openFileDialog.Title= "Save Grid File";
            if(openFileDialog.ShowDialog()!=DialogResult.OK)
            {
                return;
            }
            StreamReader sr = new StreamReader(openFileDialog.FileName);
            DATA.Clear();
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            Int32.TryParse(sr.ReadLine(), out int row);
            Int32.TryParse(sr.ReadLine(), out int col);
            CreateDataGridView(col, row);
            DATA.Open(row, col, sr, DGV);
            sr.Close();



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "GridFile|*.grd";
            saveFileDialog.Title = "Save Grid File";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(fs);
                DATA.Save(sw);
                sw.Close();
                fs.Close();
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені,що хочете закрити програму", "Увага!",
           MessageBoxButtons.OKCancel,
           MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
           MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Привіт! Це мій міні excel =)" +
                "Тут ти можеш використовувати такі операції:\n" +
                "-+(унариний)\n" +
                "inc dec (збільшення чи зменшення на 1 відп)\n" +
                "mod div (остача та ділення цілочисельне)\n" +
                "+ - (додавання і віднімання)\n" +
                "^ (піднесення у степінь)\n" +
                "Будь уважним,не можна використовувати клітинки,які ще не створені!");
        }
    }
}
