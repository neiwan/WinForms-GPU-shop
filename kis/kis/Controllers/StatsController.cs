using kis.DB_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.Intrinsics.Arm;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;

namespace kis.Controllers
{
    public class StatsController
    {
        private ExcelPackage package;
        private VidContext db { get; set; }

        public StatsController(VidContext db) 
        {
            this.db = db;
        }
        private string NewFile(string path)
        {
            int file_num = 1;
            while (File.Exists(path + "\\stats" + file_num.ToString() + ".xlsx"))
            {
                file_num++;
            }
            return path + "\\stats" + file_num.ToString() + ".xlsx";
        }
        public void Generate1(string path, string[,] data)
        {
            package = new ExcelPackage(NewFile(path));

            var worksheet = package.Workbook.Worksheets.Add("Отчет");

            worksheet.Cells["A1:I1"].Merge = true;
            worksheet.Cells[1, 1].Value = "Список доступных видеокарт:";

            worksheet.Cells[2, 1].Value = "Id";
            worksheet.Cells[2, 2].Value = "Производитель";
            worksheet.Cells[2, 3].Value = "Производитель ГЯ";
            worksheet.Cells[2, 4].Value = "Модель";
            worksheet.Cells[2, 5].Value = "Серия";
            worksheet.Cells[2, 6].Value = "ОП";
            worksheet.Cells[2, 7].Value = "Кол-во кулеров";
            worksheet.Cells[2, 8].Value = "Цена";
            worksheet.Cells[2, 9].Value = "Кол-во видеокарт";

            int rowCount = data.GetLength(0);
            int colCount = data.GetLength(1);
            for (int row = 3; row <= rowCount + 2; row++)
            {
                for (int col = 1; col <= colCount - 1; col++)
                {
                    worksheet.Cells[row, col].Value = data[row - 3, col - 1];
                }
            }

            var allCells = worksheet.Cells[worksheet.Dimension.Address];
            var allStyle = allCells.Style;
            allStyle.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells.AutoFitColumns();

            // Сохраняем файл Excel
            package.Save();
        }
        public void Generate2(string path, string ans2, string[,] data)
        {
            package = new ExcelPackage(NewFile(path));

            var worksheet = package.Workbook.Worksheets.Add("Отчет");

            worksheet.Cells["A1:H1"].Merge = true;
            worksheet.Cells[1, 1].Value = "Список доступных видеокарт в городе " + ans2 + ":" ;

            worksheet.Cells[2, 1].Value = "Id";
            worksheet.Cells[2, 2].Value = "Производитель";
            worksheet.Cells[2, 3].Value = "Производитель ГЯ";
            worksheet.Cells[2, 4].Value = "Модель";
            worksheet.Cells[2, 5].Value = "Серия";
            worksheet.Cells[2, 6].Value = "ОП";
            worksheet.Cells[2, 7].Value = "Кол-во кулеров";
            worksheet.Cells[2, 8].Value = "Цена";

            int id = db.Shops.FirstOrDefault(s => s.ShopCity[0] == ans2).ShopId;
            Console.WriteLine(id);
            data = GetDataByShop(id, data);

            int rowCount = data.GetLength(0);
            int colCount = data.GetLength(1);
            for (int row = 3; row <= rowCount + 2; row++)
            {
                for (int col = 1; col <= colCount - 1; col++)
                {
                    worksheet.Cells[row, col].Value = data[row - 3, col - 1];
                }
            }

            var allCells = worksheet.Cells[worksheet.Dimension.Address];
            var allStyle = allCells.Style;
            allStyle.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells.AutoFitColumns();

            // Сохраняем файл Excel
            package.Save();
        }

        public void Generate3(string path, string ans3_1, string ans3_2, string[,] data)
        {
            package = new ExcelPackage(NewFile(path));

            var worksheet = package.Workbook.Worksheets.Add("Отчет");

            worksheet.Cells["A1:H1"].Merge = true;
            worksheet.Cells[1, 1].Value = "Список доступных видеокарт в ценовом диапазоне " + ans3_1 + " - " + ans3_2 + " :";

            worksheet.Cells[2, 1].Value = "Id";
            worksheet.Cells[2, 2].Value = "Производитель";
            worksheet.Cells[2, 3].Value = "Производитель ГЯ";
            worksheet.Cells[2, 4].Value = "Модель";
            worksheet.Cells[2, 5].Value = "Серия";
            worksheet.Cells[2, 6].Value = "ОП";
            worksheet.Cells[2, 7].Value = "Кол-во кулеров";
            worksheet.Cells[2, 8].Value = "Цена";

            data = GetDataByPrice(ans3_1, ans3_2, data);

            int rowCount = data.GetLength(0);
            int colCount = data.GetLength(1);
            for (int row = 3; row <= rowCount + 2; row++)
            {
                for (int col = 1; col <= colCount; col++)
                {
                    worksheet.Cells[row, col].Value = data[row - 3, col - 1];
                }
            }

            var allCells = worksheet.Cells[worksheet.Dimension.Address];
            var allStyle = allCells.Style;
            allStyle.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells.AutoFitColumns();

            // Сохраняем файл Excel
            package.Save();
        }


        public void Generate4(string path, DateTime ans4_1, DateTime ans4_2, string[,] strings)
        {
            package = new ExcelPackage(NewFile(path));

            var worksheet = package.Workbook.Worksheets.Add("Отчет");

            worksheet.Cells["A1:I1"].Merge = true;
            worksheet.Cells[1, 1].Value = "Аналитический отчет на промежутке от : " + ans4_1 + " до " + ans4_2;

            worksheet.Cells[2, 1].Value = "Дата";
            worksheet.Cells[2, 2].Value = "Кол-во";
            worksheet.Cells[2, 3].Value = "Выручка";

            int rowCount = strings.GetLength(0);
            int colCount = strings.GetLength(1);
            for (int row = 3; row <= rowCount + 2; row++)
            {
                for (int col = 1; col <= colCount; col++)
                {
                    if (col == 1)
                    {
                        worksheet.Cells[row, col].Value = DateTime.Parse(strings[row - 3, col - 1]).ToShortDateString();
                        worksheet.Cells[row, col].Style.Numberformat.Format = "yyyy-MM-dd";
                    }
                    else
                    {
                        if (int.TryParse(strings[row - 3, col - 1], out int outRes))
                        worksheet.Cells[row, col].Value = outRes;
                        worksheet.Cells[row, col].Style.Numberformat.Format = "0";
                    }
                }
            }

            var chart = worksheet.Drawings.AddChart("Histogram", eChartType.ColumnClustered);
            var chart2 = worksheet.Drawings.AddChart("Histogram2", eChartType.ColumnClustered);
            chart.SetSize(600, 400); // Устанавливаем размер графика

            // Указываем данные для гистограммы (диапазон ячеек с данными)
            var series = chart.Series.Add(worksheet.Cells["B3:B" + (rowCount + 2)], worksheet.Cells["A3:A" + (rowCount + 2)]);
            var series2 = chart2.Series.Add(worksheet.Cells["C3:C" + (rowCount + 2)], worksheet.Cells["A3:A" + (rowCount + 2)]);
            var allCells = worksheet.Cells[worksheet.Dimension.Address];
            var allStyle = allCells.Style;
            allStyle.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells.AutoFitColumns();

            // Сохраняем файл Excel
            package.Save();
        }
        public void Generate5(string path, string gpu, string[,] data)
        {
            package = new ExcelPackage(NewFile(path));

            var worksheet = package.Workbook.Worksheets.Add("Отчет");

            worksheet.Cells["A1:G1"].Merge = true;
            worksheet.Cells[1, 1].Value = "Список видеокарт по GPU: " + gpu;

            worksheet.Cells[2, 1].Value = "Id";
            worksheet.Cells[2, 2].Value = "Производитель";
            worksheet.Cells[2, 3].Value = "Производитель ГЯ";
            worksheet.Cells[2, 4].Value = "Серия";
            worksheet.Cells[2, 5].Value = "ОП";
            worksheet.Cells[2, 6].Value = "Кол-во кулеров";
            worksheet.Cells[2, 7].Value = "Цена";

            data = GetDataByGpu(gpu, data);

            int rowCount = data.GetLength(0);
            int colCount = data.GetLength(1);
            for (int row = 3; row <= rowCount + 2; row++)
            {
                for (int col = 1; col <= colCount - 1; col++)
                {
                    worksheet.Cells[row, col].Value = data[row - 3, col - 1];
                }
            }

            var allCells = worksheet.Cells[worksheet.Dimension.Address];
            var allStyle = allCells.Style;
            allStyle.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells.AutoFitColumns();

            // Сохраняем файл Excel
            package.Save();
        }


        public void Generate6(string path, string ram, string[,] data)
        {
            package = new ExcelPackage(NewFile(path));

            var worksheet = package.Workbook.Worksheets.Add("Отчет");

            worksheet.Cells["A1:G1"].Merge = true;
            worksheet.Cells[1, 1].Value = "Список видеокарт по ОП: " + ram;

            worksheet.Cells[2, 1].Value = "Id";
            worksheet.Cells[2, 2].Value = "Производитель";
            worksheet.Cells[2, 3].Value = "Производитель ГЯ";
            worksheet.Cells[2, 4].Value = "Модель";
            worksheet.Cells[2, 5].Value = "Серия";
            worksheet.Cells[2, 6].Value = "Кол-во кулеров";
            worksheet.Cells[2, 7].Value = "Цена";

            data = GetDataByRam(ram, data);

            int rowCount = data.GetLength(0);
            int colCount = data.GetLength(1);
            for (int row = 3; row <= rowCount + 2; row++)
            {
                for (int col = 1; col <= colCount - 1; col++)
                {
                    worksheet.Cells[row, col].Value = data[row - 3, col - 1];
                }
            }

            var allCells = worksheet.Cells[worksheet.Dimension.Address];
            var allStyle = allCells.Style;
            allStyle.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells.AutoFitColumns();

            // Сохраняем файл Excel
            package.Save();
        }

        public void Generate7(string path, string manufacturer, string[,] data)
        {
            package = new ExcelPackage(NewFile(path));

            var worksheet = package.Workbook.Worksheets.Add("Отчет");

            worksheet.Cells["A1:G1"].Merge = true;
            worksheet.Cells[1, 1].Value = "Список видеокарт по производителю: " + manufacturer;

            worksheet.Cells[2, 1].Value = "Id";
            worksheet.Cells[2, 2].Value = "Производитель";
            worksheet.Cells[2, 3].Value = "Модель";
            worksheet.Cells[2, 4].Value = "Серия";
            worksheet.Cells[2, 5].Value = "ОП";
            worksheet.Cells[2, 6].Value = "Кол-во кулеров";
            worksheet.Cells[2, 7].Value = "Цена";

            data = GetDataByManufacturer(manufacturer, data);

            int rowCount = data.GetLength(0);
            int colCount = data.GetLength(1);
            for (int row = 3; row <= rowCount + 2; row++)
            {
                for (int col = 1; col <= colCount - 1; col++)
                {
                    worksheet.Cells[row, col].Value = data[row - 3, col - 1];
                }
            }
            
            var allCells = worksheet.Cells[worksheet.Dimension.Address];
            var allStyle = allCells.Style;
            allStyle.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells.AutoFitColumns();

            // Сохраняем файл Excel
            package.Save();
        }

        private string[,] GetDataByPrice(string ans3_1, string ans3_2, string[,] data)
        {
            string[,] table = new string[data.GetLength(0), 8];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (int.TryParse(data[i, 7], out int outCost)) { }
                if (int.TryParse(ans3_1, out int fromCost)) { }
                if (int.TryParse(ans3_2, out int toCost)) { }
                Console.WriteLine(outCost + "  " + fromCost + "  " + toCost); 
                if (outCost >= fromCost && outCost <= toCost)
                {
                    table[i, 0] = data[i, 0];
                    table[i, 1] = data[i, 1];
                    table[i, 2] = data[i, 2];
                    table[i, 3] = data[i, 3];
                    table[i, 4] = data[i, 4];
                    table[i, 5] = data[i, 5];
                    table[i, 6] = data[i, 6];
                    table[i, 7] = data[i, 7];
                }
            }
            return remove_spaces_from_table(table);
        }

        private string[,] GetDataByGpu(string gpu, string[,] data)
        {
            string[,] table = new string[data.GetLength(0), 8];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (data[i, 3] == gpu)
                {
                    table[i, 0] = data[i, 0];
                    table[i, 1] = data[i, 1];
                    table[i, 2] = data[i, 2];
                    table[i, 3] = data[i, 4];
                    table[i, 4] = data[i, 5];
                    table[i, 5] = data[i, 6];
                    table[i, 6] = data[i, 7];
                    table[i, 7] = data[i, 8];
                }
            }
            return remove_spaces_from_table(table);
        }

        private string[,] GetDataByRam(string ram, string[,] data)
        {
            string[,] table = new string[data.GetLength(0), 8];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (data[i, 5] == ram)
                {
                    table[i, 0] = data[i, 0];
                    table[i, 1] = data[i, 1];
                    table[i, 2] = data[i, 2];
                    table[i, 3] = data[i, 3];
                    table[i, 4] = data[i, 4];
                    table[i, 5] = data[i, 6];
                    table[i, 6] = data[i, 7];
                    table[i, 7] = data[i, 8];
                }
            }
            return remove_spaces_from_table(table);
        }

        private string[,] GetDataByManufacturer(string manufacturer, string[,] data)
        {
            string[,] table = new string[data.GetLength(0), 8];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (data[i, 1] == manufacturer)
                {
                    table[i, 0] = data[i, 0];
                    table[i, 1] = data[i, 1];
                    table[i, 2] = data[i, 3];
                    table[i, 3] = data[i, 4];
                    table[i, 4] = data[i, 5];
                    table[i, 5] = data[i, 6];
                    table[i, 6] = data[i, 7];
                    table[i, 7] = data[i, 8];
                }   
            }
            return remove_spaces_from_table(table);
        }
        private string[,] GetDataByShop(int shopId, string[,] data)
        {
            
            List<ShopCard> SCards = db.ShopCards.ToList();
            List<int?> indexes = new List<int?>();
            for (int i = SCards.Count - 1; i >= 0; i--)
            {
                if (SCards[i].ShopId == shopId)
                {
                    indexes.Add(SCards[i].CardId);
                }
            }

            string[,] table = new string[data.GetLength(0), 9];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (int.TryParse(data[i, 0], out int outNum)) { }
                if (indexes.Contains(outNum))
                {
                    for (int j = 0; j < data.GetLength(1) - 1; j++)
                    {
                        table[i, j] = data[i, j];
                    }
                }
            }
            return remove_spaces_from_table(table);

        }
        public string[,] remove_spaces_from_table(string[,] array)
        {
            int rowCount = array.GetLength(0);
            int colCount = array.GetLength(1);

            // Создаем новый список для хранения строк с непустыми элементами
            List<string[]> nonEmptyRows = new List<string[]>();

            // Проходим по каждой строке массива
            for (int i = 0; i < rowCount; i++)
            {
                bool isEmptyRow = true;
                for (int j = 0; j < colCount; j++)
                {
                    if (array[i, j] != null)
                    {
                        isEmptyRow = false;
                        break;
                    }
                }
                if (!isEmptyRow)
                {
                    string[] row = new string[colCount];
                    for (int j = 0; j < colCount; j++)
                    {
                        row[j] = array[i, j];
                    }
                    nonEmptyRows.Add(row);
                }
            }
            string[,] newArray = new string[nonEmptyRows.Count, colCount];
            for (int i = 0; i < nonEmptyRows.Count; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    newArray[i, j] = nonEmptyRows[i][j];
                }
            }
            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                for (int j = 0; j < newArray.GetLength(1); j++)
                {
                    if (newArray[i, j] == null)
                    {
                        newArray[i, j] = "";
                    }
                }
            }
            return newArray;
        }
    }
}
