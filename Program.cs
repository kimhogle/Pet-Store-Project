// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.WriteLine("Hello, World!");

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Press 1 to add a product");
        Console.WriteLine("Type 'exit' to quit");

        string userInput = Console.ReadLine();

        while (userInput.ToLower() != "exit")
        {
            if (userInput == "1")
            {
                Console.WriteLine("What type of product would you like to add? (CatFood/DogLeash)");
                string productType = Console.ReadLine();

                if (productType.ToLower() == "catfood")
                {
                    var catFood = new CatFood();
                    Console.Write("Enter Name: ");
                    catFood.Name = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    catFood.Price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Quantity: ");
                    catFood.Quantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter Description: ");
                    catFood.Description = Console.ReadLine();
                    Console.Write("Enter Weight (in pounds): ");
                    catFood.WeightPounds = double.Parse(Console.ReadLine());
                    Console.Write("Is it Kitten Food? (true/false): ");
                    catFood.KittenFood = bool.Parse(Console.ReadLine());

                    Console.WriteLine(JsonSerializer.Serialize(catFood));
                }
                else if (productType.ToLower() == "dogleash")
                {
                    var dogLeash = new DogLeash();
                    Console.Write("Enter Name: ");
                    dogLeash.Name = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    dogLeash.Price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Quantity: ");
                    dogLeash.Quantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter Description: ");
                    dogLeash.Description = Console.ReadLine();
                    Console.Write("Enter Length (in inches): ");
                    dogLeash.LengthInches = int.Parse(Console.ReadLine());
                    Console.Write("Enter Material: ");
                    dogLeash.Material = Console.ReadLine();

                    Console.WriteLine(JsonSerializer.Serialize(dogLeash));
                }
                else
                {
                    Console.WriteLine("Invalid product type.");
                }
            }

            Console.WriteLine("Press 1 to add a product");
            Console.WriteLine("Type 'exit' to quit");
            userInput = Console.ReadLine();
        }

        Console.WriteLine("Exiting application...");
    }
}


public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
}


public class CatFood : Product
{
    public double WeightPounds { get; set; }
    public bool KittenFood { get; set; }
}


public class DogLeash : Product
{
    public int LengthInches { get; set; }
    public string Material { get; set; }
}


