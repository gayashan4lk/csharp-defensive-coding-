// See https://aka.ms/new-console-template for more information
using ACME.BL.Models;
using ACME.BL.Services;

Console.WriteLine("Programe Starting...");
Console.WriteLine("Enter the Price:");
var price = Console.ReadLine();
Console.WriteLine("Enter the Cost:");
var cost = Console.ReadLine();

if (!string.IsNullOrEmpty(price) && !string.IsNullOrEmpty(cost))
{
    Console.WriteLine("Calculating product margine...");
    var myProduct = new Product(Decimal.Parse(price), Decimal.Parse(cost));
    var margin = ProductService.calculateMargin(myProduct);
    Console.WriteLine(margin);
}

Console.WriteLine("\nPress any key to exit.");
Console.ReadLine();

