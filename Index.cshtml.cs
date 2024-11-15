using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace aspnetcoreapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string? Num1 { get; set; }

        [BindProperty]
        public string? Num2 { get; set; }

        [BindProperty]
        public string? Operation { get; set; }

        public string? Result { get; set; }
        public string? Error { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (string.IsNullOrWhiteSpace(Num1) || (Operation != "SQUARE" && Operation != "CUBE" && string.IsNullOrWhiteSpace(Num2)))
            {
                Error = "Please fill in both Num1 and Num2.";
                Result = null;
                return;
            }

            if (Operation == "ADD")
            {
                PerformOperation((num1, num2) => num1 + num2);
            }
            else if (Operation == "SUBTRACT")
            {
                PerformOperation((num1, num2) => num1 - num2);
            }
            else if (Operation == "MULTIPLY")
            {
                PerformOperation((num1, num2) => num1 * num2);
            }
            else if (Operation == "SQUARE")
            {
                if (double.TryParse(Num1, out double num1))
                {
                    Result = (num1 * num1).ToString();
                    Error = null;
                }
                else
                {
                    Error = "Please enter a valid number to square.";
                    Result = null;
                }
            }
            else if (Operation == "CUBE")
            {
                if (double.TryParse(Num1, out double num1))
                {
                    Result = (num1 * num1 * num1).ToString();
                    Error = null;
                }
                else
                {
                    Error = "Please enter a valid number to cube.";
                    Result = null;
                }
            }
            else if (Operation == "SIN")
            {
                if (double.TryParse(Num1, out double num1))
                {
                    double radians = num1 * (Math.PI / 180); // Convert degrees to radians
                    Result = Math.Sin(radians).ToString("F4");
                    Error = null;
                }
                else
                {
                    Error = "Please enter a valid number for sine calculation.";
                    Result = null;
                }
            }
            else if (Operation == "COS")
            {
                if (double.TryParse(Num1, out double num1))
                {
                    double radians = num1 * (Math.PI / 180); // Convert degrees to radians
                    Result = Math.Cos(radians).ToString("F4");
                    Error = null;
                }
                else
                {
                    Error = "Please enter a valid number for cosine calculation.";
                    Result = null;
                }
            }
        }

        private void PerformOperation(Func<double, double, double> operation)
        {
            if (double.TryParse(Num1, out double num1) && double.TryParse(Num2, out double num2))
            {
                Result = operation(num1, num2).ToString();
                Error = null;
            }
            else
            {
                Error = "Please enter valid numbers.";
                Result = null;
            }
        }
    }
}