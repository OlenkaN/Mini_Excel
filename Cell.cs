using System;
using System.Collections.Generic;
using System.Text;

namespace MyExcelLAB
{
    public class Cell
    {
        public string Index
        { 
            get;
           private set;
         }
        public int CollIndex
        {
            get;
            private set;
        }
        public int RowIndex
        {
            get;
            private set;
        }
        public string Value;
        public string Expression;
        public List<Cell> CellDepentsOn = new List<Cell>();//ті клітинки від яких залежна дана
        public List<Cell> DepentsOnThisCell = new List<Cell>();// ті клітинки ,які залежні від нашої
        public List<Cell> NewCellDepentsOn = new List<Cell>();
        public Cell(string index,int row,int col)
        {
            Index = index;
            RowIndex = row;
            CollIndex = col;
            Value = "0";
            Expression = "";
        }
        public void SetCell(string value,string expression,List<Cell> MyCellDepentsOn, List<Cell> CellDependencies)
        {
            this.Value = value;
            this.Expression = expression;
            this.CellDepentsOn.Clear();
            this.CellDepentsOn.AddRange(MyCellDepentsOn);
            this.DepentsOnThisCell.Clear();
            this.DepentsOnThisCell.AddRange(CellDependencies);
          
        }
        public bool CheckForLoop(List<Cell> ListToCheck)
        {
            foreach(Cell cell in ListToCheck )
            {
                //перевірка чи часом вираз, який ми хочемо записати в клітинку не містить саму клітинку
                if (cell.Index==Index)
                {
                    return false;
                }
            }
            //перевірка виразів клітинок,які залежать від даної
            foreach (Cell depend in DepentsOnThisCell)
            {
                foreach(Cell cell in ListToCheck)
                {
                    //перевірка чи серед цих клітинок нема тих які ми присвоюємо 
                    if(cell.Index==depend.Index)
                    {
                        return false;
                    }
                }
                //рекурсивно перевіряємо ті, які залежать від клітинки
                if (!depend.CheckForLoop(ListToCheck))
                {
                    return false;
                }
            }
            return true;
        }
        public void AddDependencies()
        {
            //для кожної клітинки з виразу додаємо ту якій присвоювався вираз,як залежну від
            foreach(Cell depend in NewCellDepentsOn)
            {
                depend.DepentsOnThisCell.Add(this);
            }
            CellDepentsOn = NewCellDepentsOn;
        }
        public void DelDependencies()
        {
            if(CellDepentsOn!=null)
            {
                foreach (Cell cell in CellDepentsOn)
                {
                    cell.DepentsOnThisCell.Remove(this);
                }
                CellDepentsOn = null;
            }
        }
   

    }
}
