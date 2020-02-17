namespace EaseTrello.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using OfficeOpenXml;
    using Interfaces;
    using Models;

    internal class BoardLoader : IBoardLoader
    {
        public IEnumerable<CardRow> Load(string filePath)
        {
            var result = new List<CardRow>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[1];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var cardName = this.GetCellValue(worksheet.Cells, row, 1);
                    var label = this.GetCellValue(worksheet.Cells, row, 2).Split(',', StringSplitOptions.RemoveEmptyEntries);
                    var description = this.GetCellValue(worksheet.Cells, row, 3);
                    var checkList = this.GetCellValue(worksheet.Cells, row, 4).Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    var list = this.GetCellValue(worksheet.Cells, row, 5);

                    var cardRow = new CardRow(
                        name: cardName,
                        labels: label,
                        description: description,
                        items: checkList,
                        list: list);
                        
                    result.Add(cardRow);
                }
            }

            return result;
        }

        private string GetCellValue(ExcelRange cells, int row, int column)
        {
            var value = cells[row, column].Value;

            if (value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }
    }
}
