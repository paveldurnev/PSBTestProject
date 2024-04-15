using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PSBClient
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task<double> CallCalculatorApi(string operation, double a, double b)
        {
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5010/api/{operation}?a={a}&b={b}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return double.Parse(responseBody);
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the operator and variables like: <'a' value> <operator> <'b' value>");
            Console.WriteLine("Operator can be +, -, * or /");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string data, operation="", val="";
            double a = 0, b = 0;
            while (true)
            {
                data = Console.ReadLine();
                try
                {
                    string pattern = @"(-?\d+(\.\d+)?)\s*([-+*/])\s*(-?\d+(\.\d+)?)";
                    Match match = Regex.Match(data, pattern);
                    a = double.Parse(match.Groups[1].Value);
                    val = match.Groups[3].Value;
                    b = double.Parse(match.Groups[4].Value);
                    switch (val[0])
                    {
                        case '+':
                            operation = "add";
                            break;
                        case '-':
                            operation = "subtract";
                            break;
                        case '*':
                            operation = "multiply";
                            break;
                        case '/':
                            operation = "divide";
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(await CallCalculatorApi(operation, a, b));
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"{data}: Error! Enter the correct data to calculate.");
                }
            }
        }
    }
}
