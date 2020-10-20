using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyExcelLAB
{
    public class Data
    {

        private const int baseColCount = 10;
        private const int baseRowCount = 10;
        public int ColCount;
        public int RowCount;
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public List<List<Cell>> data = new List<List<Cell>>();
        public Data()
        {
            this.SetTable(baseRowCount,baseColCount);

        }
        public void SetTable(int row1 , int col1 )
        {
            ColCount = col1;
            RowCount = row1;
            for (int i = 0; i < RowCount; ++i)
            {
                List<Cell> row = new List<Cell>();
                for (int j = 0; j < ColCount; ++j)
                {
                    string name = _26BasedSystem.To26System(j) + i.ToString();
                    row.Add(new Cell(name, i, j));
                    dictionary.Add(name, "");
                }
                data.Add(row);

            }
        }
        public void Clear()
        {
            for(int i=0;i<RowCount;++i)
            {
                data[i].Clear();
            }
            data.Clear();
            dictionary.Clear();
            ColCount = 0;
            RowCount = 0;
        }
        #region Expression in cell
        public void ChangeCellCompletely(int row, int col, string expression, DataGridView dataGridView)
        {
            string old_expression = data[row][col].Expression;
            data[row][col].DelDependencies();
            data[row][col].Expression = expression;
            data[row][col].NewCellDepentsOn.Clear();
            string value = expression;
            string fullname = FullName(col, row);
            if (expression != "")
            {
                if (expression[0] != '=')
                {
                    data[row][col].Value = expression;
                    dictionary[fullname] = expression;
                    foreach (Cell cell in data[row][col].DepentsOnThisCell)
                    {
                        RefreshCellAndDependencies(cell, dataGridView);
                    }
                    return;
                }

            }
            string NewExpression = ConvertDependencies(row, col, expression);
            if (NewExpression != "")
            {
                NewExpression = NewExpression.Remove(0, 1);
            }
            if (!data[row][col].CheckForLoop(data[row][col].NewCellDepentsOn))
            {
                MessageBox.Show("Тут є цикл!Будьте уважними, будь ласка, змініть вираз");
                return;
            }
            data[row][col].AddDependencies();
            value = Calculate(NewExpression);
            if (value == "Error")
            {
                MessageBox.Show("Помилка в клітинці " + fullname + "!");
                return;
            }
            data[row][col].Value = value;
            dictionary[fullname] = value;
            foreach (Cell cell in data[row][col].DepentsOnThisCell)
            {
                RefreshCellAndDependencies(cell, dataGridView);
            }


        }

        public bool RefreshCellAndDependencies(Cell cell, DataGridView dataGridView)
        {
            cell.NewCellDepentsOn.Clear();
            string NewExpression = ConvertDependencies(cell.RowIndex, cell.CollIndex, cell.Expression);
            NewExpression = NewExpression.Remove(0, 1);
            string value = Calculate(NewExpression);
            if (value == "Error")
            {
                MessageBox.Show("Помилка в клітинці " + cell.Index + "!");
                return false;
            }
            data[cell.RowIndex][cell.CollIndex].Value = value;
            dictionary[cell.Index] = value;
            dataGridView[cell.CollIndex, cell.RowIndex].Value = value;
            foreach (Cell depend in cell.DepentsOnThisCell)
            {
                if (!RefreshCellAndDependencies(depend, dataGridView))
                {
                    return false;
                }
            }
            return true;

        }

        public string FullName(int col, int row)
        {
            return _26BasedSystem.To26System(col) + row;
        }
        public string ConvertDependencies(int row, int col, string expression)
        {
            string MyPattern = @"[A-Z]+[0-9]+";
            Regex regex = new Regex(MyPattern, RegexOptions.IgnoreCase);
            int[] nums;
            foreach (Match match in regex.Matches(expression))
            {
                if (dictionary.ContainsKey(match.Value))
                {
                    nums = _26BasedSystem.From26Sys(match.Value);
                    data[row][col].NewCellDepentsOn.Add(data[nums[1]][nums[0]]);

                }
            }
            MatchEvaluator MyEvaluator = new MatchEvaluator(DependsToValue);
            string NewExpression = regex.Replace(expression, MyEvaluator);
            return NewExpression;

        }
        public string DependsToValue(Match m)
        {
            if (dictionary.ContainsKey(m.Value))
            {
                if (dictionary[m.Value] == "")
                    return "0";
                else
                    return dictionary[m.Value];
            }
            return m.Value;
        }
        public string Calculate(string expression)
        {
            string result = null;
            try
            {
                result = Convert.ToString(Calculator.Evaluate(expression));
                return result;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Ділення на нуль");
                return "Error";
            }
            catch
            {
                return "Error";
            }
        }
        #endregion
        #region Action with col and row
        public void AddColumn()
        {
            for (int i = 0; i < RowCount; ++i)
            {
                string name = FullName(ColCount, i);
                data[i].Add(new Cell(name, i, ColCount));
                dictionary.Add(name, "");
            }
            ColCount++;
        }
        public void AddRow()
        {
            List<Cell> new_row = new List<Cell>();
            for (int i = 0; i < ColCount; ++i)
            {
                string name = FullName(i, RowCount);
                new_row.Add(new Cell(name, RowCount, i));
                dictionary.Add(name, "");
            }
            data.Add(new_row);
            RowCount++;
        }
        public bool DeleteCol()
        {
            int colCurrent = ColCount - 1;
            if (ColCount == 0)
                return false;
            for (int i = 0; i < RowCount; ++i)
            {
                string name = FullName(colCurrent, i);
                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                {
                    MessageBox.Show($"Тут є не пуста клітинка {name}.Ви не можете видалити колонку");
                    return false;
                }
                if (data[i][colCurrent].DepentsOnThisCell.Count != 0)
                {
                    MessageBox.Show($"Є клітинки ,які залежні від {name}.Ви не можете видалити колонку");
                    return false;
                }
            }
            for (int i = 0; i < RowCount; ++i)
            {
                string name = FullName(colCurrent, i);
                dictionary.Remove(name);
                data[i].RemoveAt(colCurrent);
            }

            ColCount--;
            if (ColCount == 0)
            {
                RowCount = 0;
                data.Clear();
            }
            return true;
        }
        public bool DeleteRow()
        {
            if (RowCount == 0)
                return false;
            int rowCurrent = RowCount - 1;
            for (int i = 0; i < ColCount; ++i)
            {
                string name = FullName(i, rowCurrent);
                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                {
                    MessageBox.Show($"Тут є не пуста клітинка {name}.Ви не можете видалити колонку");
                    return false;
                }
                if (data[rowCurrent][i].DepentsOnThisCell.Count != 0)
                {
                    MessageBox.Show($"Є клітинки ,які залежні від {name}.Ви не можете видалити колонку");
                    return false;
                }
            }
            for (int i = 0; i < ColCount; ++i)
            {
                string name = FullName(i, rowCurrent);
                dictionary.Remove(name);
            }
            data.RemoveAt(rowCurrent);
            RowCount--;
            return true;
        }
        #endregion
        public void Save(StreamWriter sw)
        {
            sw.WriteLine(RowCount);
            sw.WriteLine(ColCount);
            foreach (List<Cell> list in data)
            {
                foreach (Cell cell in list)
                {
                    sw.WriteLine(cell.Index);
                    sw.WriteLine(cell.Expression);
                    sw.WriteLine(cell.Value);
                    if (cell.CellDepentsOn == null)
                        sw.WriteLine(0);
                    else
                    {
                        sw.WriteLine(cell.CellDepentsOn.Count);
                        foreach (Cell depend in cell.CellDepentsOn)
                        {
                            sw.WriteLine(depend.Index);
                        }
                    }
                    if (cell.DepentsOnThisCell == null)
                        sw.WriteLine(0);
                    else
                    {
                        sw.WriteLine(cell.DepentsOnThisCell.Count);
                        foreach (Cell depend in cell.DepentsOnThisCell)
                        {
                            sw.WriteLine(depend.Index);
                        }
                    }
                }
            }
        }
        public void Open(int row, int col, StreamReader sr, DataGridView dataGridView)
        {
            this.SetTable(row, col);
            for (int r = 0; r < row; ++r)
            {
                for (int c = 0; c < col; ++c)
                {


                    string index = sr.ReadLine();
                    string expression = sr.ReadLine();
                    string value = sr.ReadLine();
                    if (expression != "")
                    {
                        dictionary[index] = value;
                    }
                    else
                        dictionary[index] = "";
                    int depCount = Convert.ToInt32(sr.ReadLine());
                    List<Cell> newdep = new List<Cell>();
                    string depend;
                    for (int i = 0; i < depCount; ++i)
                    {
                        depend = sr.ReadLine();
                        newdep.Add(data[_26BasedSystem.From26Sys(depend)[1]][_26BasedSystem.From26Sys(depend)[0]]);
                    }
                    int depCount2 = Convert.ToInt32(sr.ReadLine());
                    List<Cell> newdep2 = new List<Cell>();
                    string depend2;
                    for (int i = 0; i < depCount2; ++i)
                    {
                        depend2 = sr.ReadLine();
                        newdep2.Add(data[_26BasedSystem.From26Sys(depend2)[1]][_26BasedSystem.From26Sys(depend2)[0]]);
                    }
                    data[r][c].SetCell(value, expression, newdep, newdep2);
                    int icol = data[r][c].CollIndex;
                    int irow = data[r][c].RowIndex;
                    dataGridView[icol, irow].Value = dictionary[index];


                }
            }



        }
    }
}
