using System.Text;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using ExpressFoodApplicationAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExpressFoodApplicationAdmin.Controllers
{
    public class FoodItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private List<FoodItem> getAllFoodItemsFromFile(string fileName)
        {
            List<FoodItem> foodItems = new List<FoodItem>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
             decimal TryParseDecimal(string value)
            {
                decimal result;
                if (decimal.TryParse(value, out result))
                {
                    return result;
                }
                else
                {
                    return 0m; 
                }
            }


            Guid TryParseGuid(string value)
            {
                Guid result;
                if (Guid.TryParse(value, out result))
                {
                    return result;
                }
                else
                {
                    return Guid.Empty; 
                }
            }

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        foodItems.Add(new Models.FoodItem

                        {
                            Name = reader.GetValue(0).ToString(),
                            Description = reader.GetValue(1).ToString(),
                            Price = TryParseDecimal(reader.GetValue(2).ToString()),
                            FoodItemImage = reader.GetValue(3).ToString(),
                            RestaurantId = TryParseGuid(reader.GetValue(4).ToString())
                        });
                    }

                }
            }
            return foodItems;
        }

        public IActionResult ImportFoodItems(IFormFile file)
        {
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            List<FoodItem> foodItems = getAllFoodItemsFromFile(file.FileName);
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5192/api/Admin/ImportFoodItems";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(foodItems), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index", "Order");
        }
    }
}
