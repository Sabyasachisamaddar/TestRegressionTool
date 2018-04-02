using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TestRegressionTool
{
    public class MarkViewModel
    {
        private int maxMarks;
        private string fileName;

        public ICollectionView Marks { get; private set; }

        //public MarkViewModel()

        public MarkViewModel(int count, List<int> moderator_indices, int max_marks)
        {
            IList<Mark> list_marks = new List<Mark>();
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                var rmark = random.Next(0, 100);
                list_marks.Add(new Mark
                {
                    ID = i,
                    RawMark = rmark,
                    ModeratorMark = 0,
                    RegressedMark = 0
                });
                if (moderator_indices.IndexOf(i) >= 0)
                    list_marks[i].ModeratorMark = random.Next(0, 100);
            }
            var reg_limit = int.Parse(Math.Round(Decimal.ToDouble(max_marks / 10)).ToString());
            calculateRegressedMarks(list_marks, moderator_indices,reg_limit);
            Marks = CollectionViewSource.GetDefaultView(list_marks);
        }

        public MarkViewModel(int maxMarks, string fileName)
        {
            this.maxMarks = maxMarks;
            this.fileName = fileName;
            IList<Mark> list_marks = new List<Mark>();
            List<int> moderator_indices = new List<int>();
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = xlApp.Workbooks.Open(fileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            var xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            var range = xlWorkSheet.UsedRange;
            var rw = range.Rows.Count;
            var cl = range.Columns.Count;
            int rCnt;

            for (rCnt = 2; rCnt <= rw; rCnt++)
            {
                list_marks.Add(new Mark
                {
                    ID = (int)(range.Cells[rCnt, 1] as Microsoft.Office.Interop.Excel.Range).Value2,
                    RawMark = (int) (range.Cells[rCnt, 2] as Microsoft.Office.Interop.Excel.Range).Value2,
                    ModeratorMark =0,
                    RegressedMark = 0
                });
                if ((range.Cells[rCnt, 3] as Microsoft.Office.Interop.Excel.Range).Value2 != null)
                {
                    moderator_indices.Add(rCnt - 2);
                    list_marks[rCnt - 2].ModeratorMark = (int)(range.Cells[rCnt, 3] as Microsoft.Office.Interop.Excel.Range).Value2;
                }
                //if ((range.Cells[rCnt, 2] as Microsoft.Office.Interop.Excel.Range).Value2 != null)
                //    moderator_indices.Add(rCnt - 2);
                //MessageBox.Show(str);
            }

            var reg_limit = int.Parse(Math.Round(Decimal.ToDouble(maxMarks / 10)).ToString());
            calculateRegressedMarks(list_marks, moderator_indices, reg_limit);
            Marks = CollectionViewSource.GetDefaultView(list_marks);

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }

        private void calculateRegressedMarks(IList<Mark> list_marks, List<int> moderator_indices, int reg_limit)
        {
            var N = moderator_indices.Count();
            var sx = 0; var sy = 0; var sx2 = 0; var sxy = 0; var sy2 = 0; 
            for(int i = 0; i < N; i++)
            {
                sx = sx + list_marks[moderator_indices[i]].RawMark;
                sy = sy + list_marks[moderator_indices[i]].ModeratorMark;
                sx2 = sx2 + (list_marks[moderator_indices[i]].RawMark * list_marks[moderator_indices[i]].RawMark);
                sxy = sxy + (list_marks[moderator_indices[i]].RawMark * list_marks[moderator_indices[i]].ModeratorMark);
                sy2 = sy2 + (list_marks[moderator_indices[i]].ModeratorMark * list_marks[moderator_indices[i]].ModeratorMark);
            }
            var sxsq = sx * sx;
            var e5n = (N * sxy) - (sx * sy);
            var e5d = (N * sx2) - sxsq;
            var e6n = (sx2 * sy) - (sx * sxy);

            var M = (Decimal)e5n / (Decimal)e5d;
            var C = (Decimal)e6n / (Decimal)e5d;
            var curveFlag = false;
            for (int i = 0; i < list_marks.Count; i++)
            {
                list_marks[i].RegressedMark = Decimal.ToInt32(Math.Round((M * list_marks[i].RawMark) + C));
                if (list_marks[i].RegressedMark > maxMarks)
                    list_marks[i].RegressedMark = list_marks[i].RawMark;
                else if(list_marks[i].RegressedMark < 0)
                    list_marks[i].RegressedMark = 0;
                else if (list_marks[i].RegressedMark < reg_limit)
                    curveFlag = true;
            }

            if (curveFlag)
                calculate_regressedCurvePoints(list_marks, reg_limit, C, M, e5n, e6n, e5d);


        }

        private void calculate_regressedCurvePoints(IList<Mark> list_marks, int reg_limit, decimal C, decimal M, int e5n, int e6n, int e5d )
        {
            var P = 0.0M; var B = 0.0M; var A = 0.0M; var Q = 0.0M;
            if(C <= 1)
            {
                P = (Decimal)((reg_limit * e5d) - e6n) /(Decimal) e5n;
                B = (Decimal)(M * P) / (Decimal)((M * P) + C - 1);
                A = (Decimal)((M * P) + C - 1) / (Decimal)Math.Pow(Decimal.ToDouble(P), Decimal.ToDouble(B));
            }
            else
            {
                P = reg_limit;
                Q = (Decimal)((P * e5n) + e6n) / (Decimal)e5d;
                B = (Decimal)((Q * e5d) - e6n) / (Decimal)((Q - 1) * e5d);
                A = (Decimal)((Q - 1) * (Decimal)(Math.Pow(e5n, Decimal.ToDouble(B)))) / (Decimal)Math.Pow(Decimal.ToDouble((Q * e5d) - e6n), Decimal.ToDouble(B));
            }

            for(int i=0; i < list_marks.Count; i++)
            {
                if (list_marks[i].RegressedMark < reg_limit)
                {
                    if (list_marks[i].RawMark == 0)
                        list_marks[i].RegressedMark = 0;
                    else
                    {
                        var marks = Math.Round((Decimal.ToDouble(A) * Math.Pow(list_marks[i].RawMark, Decimal.ToDouble(B))) + 1);
                        list_marks[i].RegressedMark = int.Parse(marks.ToString());
                    }
                }
            }
        }
    }


}
