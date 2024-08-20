// See https://aka.ms/new-console-template for more information
using System.Text.Json;

Console.WriteLine("Hello, World!");

class Program
{
    static void Main(string[] args)
    {
        var productLogic = new ProductLogic();

        Console.WriteLine("Press 1 to add a product");
        Console.WriteLine("Press 2 to view a product by name");
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

                    productLogic.AddProduct(catFood);
                    Console.WriteLine("CatFood product added!");
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

                    productLogic.AddProduct(dogLeash);
                    Console.WriteLine("DogLeash product added!");
                }
                else
                {
                    Console.WriteLine("Invalid product type.");
                }
            }
            else if (userInput == "2")
            {
                Console.WriteLine("Enter the name of the product to view:");
                string productName = Console.ReadLine();

                var dogLeash = productLogic.GetDogLeashByName(productName);
                if (dogLeash != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(dogLeash));
                }
                else
                {
                    Console.WriteLine("DogLeash not found.");
                }
            }

            Console.WriteLine("Press 1 to add a product");
            Console.WriteLine("Press 2 to view a product by name");
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


public class DryCatFood : CatFood
{
    public double WeightPounds { get; set; } // Moving this property to DryCatFood

    public DryCatFood()
    {
        // Default constructor
    }
}


public class DogLeash : Product
{
    public int LengthInches { get; set; }
    public string Material { get; set; }
}


public class ProductLogic
{
    private List<Product> _products;
    private Dictionary<string, DogLeash> _dogLeashes;
    private Dictionary<string, CatFood> _catFoods;

    public ProductLogic()
    {
        _products = new List<Product>();
        _dogLeashes = new Dictionary<string, DogLeash>();
        _catFoods = new Dictionary<string, CatFood>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);

        if (product is DogLeash dogLeash)
        {
            _dogLeashes[dogLeash.Name] = dogLeash;
        }
        else if (product is CatFood catFood)
        {
            _catFoods[catFood.Name] = catFood;
        }
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public DogLeash GetDogLeashByName(string name)
    {
        try
        {
            return _dogLeashes[name];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public CatFood GetCatFoodByName(string name)
    {
        try
        {
            return _catFoods[name];
        }
        catch (Exception)
        {
            return null;
        }
    }
}


public List<Product> GetAllProducts()
    {
        return _products;
    }

    public DogLeash GetDogLeashByName(string name)
    {
        return _dogLeashes.ContainsKey(name) ? _dogLeashes[name] : null;
    }

    public CatFood GetCatFoodByName(string name)
    {
        return _catFoods.ContainsKey(name) ? _catFoods[name] : null;
    }
}

