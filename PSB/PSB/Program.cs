using Microsoft.AspNetCore.Mvc;
using System;


namespace PSB
{
    [Route("api")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]
        public double Add(double a, double b)
        {
            return a + b;
        }

        [HttpGet("subtract")]
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        [HttpGet("multiply")]
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        [HttpGet("divide")]
        public double Divide(double a, double b)
        {
            // Добавляем проверку деления на ноль
            if (b == 0)
            {
                throw new DivideByZeroException("Деление на ноль невозможно");
            }
            return a / b;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
