using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using TestApplication.Application.IRepositories;

namespace TestApplication.Application.Items.GetItemsExcel;

public class GetItemsExcelHandler(
    ILogger<GetItemsExcelHandler> logger,
    IItemRepository repository)
{
    public async Task<byte[]?> Handle(CancellationToken cancellationToken)
    {
        logger.LogInformation("Начата генерация отчета Excel со списком товаров.");
        try
        {
            var items = await repository.GetAll(cancellationToken);

            logger.LogInformation($"Получено {items.Count} товаров из репозитория.");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            DateTime now = DateTime.Now;

            var today = now.Date.ToString();

            using (var package = new ExcelPackage())
            {
                var workSheetName = $"Список товаров на {today}";
                var worksheet = package.Workbook.Worksheets.Add(workSheetName);

                logger.LogInformation("Создан лист Excel с именем с именем {workSheetName}", workSheetName);

                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Имя";
                worksheet.Cells[1, 3].Value = "Описание";
                worksheet.Cells[1, 4].Value = "Цена";
                worksheet.Cells[1, 5].Value = "Количество";
                worksheet.Cells[1, 6].Value = "Категория";
                worksheet.Cells[1, 7].Value = "Время создания";
                worksheet.Cells[1, 8].Value = "Время обновления";

                for (int i = 0; i < items.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = items[i].Id;
                    worksheet.Cells[i + 2, 2].Value = items[i].Name;
                    worksheet.Cells[i + 2, 3].Value = items[i].Description;
                    worksheet.Cells[i + 2, 4].Value = items[i].Price;
                    worksheet.Cells[i + 2, 5].Value = items[i].Count;
                    worksheet.Cells[i + 2, 6].Value = items[i].CategoryName;
                    worksheet.Cells[i + 2, 7].Value = items[i].CreatedTime;
                    worksheet.Cells[i + 2, 8].Value = items[i].UpdatedTime;
                }

                logger.LogInformation("Данные о товарах успешно записаны в Excel.");

                var fileContent = package.GetAsByteArray();

                logger.LogInformation("Отчет Excel сгенерирован.");

                return fileContent;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при генерации отчета Excel.");
            return null;
        }
    }
}

