using Core;
using Core.helper.Enums;
using Core.helper.Exceptions;

namespace ConsoleApp1
{
   public class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            while (true)
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Filter Products by Type");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddProduct(store);
                        break;
                    case "2":
                        FilterByType(store);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void AddProduct(Store store)
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.WriteLine("Invalid price.");
                return;
            }
            Console.WriteLine("Choose product type: 0 - Baker, 1 - Drink, 2 - Meat, 3 - Diary");
            if (!Enum.TryParse(Console.ReadLine(), out Types type))
            {
                Console.WriteLine("Invalid product type.");
                return;
            }

            try
            {
                Product product = new Product( type, name, price);
                store.AddProduct(product);
                Console.WriteLine($"Product '{name}' added successfully ");
            }
            catch (PriceMustBeGratherThanZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void FilterByType(Store store)
        {
            Console.WriteLine("Choose product type to filter: 0 - Baker, 1 - Drink, 2 - Meat, 3 - Diary");
            if (Enum.TryParse(Console.ReadLine(), out Types type))
            {
                Product[] filteredProducts = store.FilterProductsByType(type);
                if (filteredProducts.Any())
                {
                    Console.WriteLine("\nFiltered Products:");
                    foreach (var product in filteredProducts)
                    {
                        Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
                    }
                }
                else
                {
                    Console.WriteLine("No products found for this type.");
                }
            }
            else
            {
                Console.WriteLine("Invalid type.");
            }

        }
    }
}


/*
PriceMustBeGratherThanZeroException - exception yaradirsiniz.

Product class
- No -> her obyekt yarananda +1 vahid artacaq
- Name
- Price -> encapsulation edirsiniz, eger price 0dan ashagi gonderilibse, PriceMustBeGratherThanZeroException geriye qaytarirsiniz

- Type (Baker,Drink,Meat,Diary) Enums

Store class
- Products
- AddProduct()
- RemoveProductByNo() - no dəyəri qəbul edir və həmin dəyərli product obyektini products siyahısından çıxarır
- GetProduct() -> nullable int No deyeri qebul edir eger hemin no'ya uygun product varsa geriye qaytarir
- FilterProductsByType() - type dəyəri qəbul edir və həmin dəyərli productlardan ibarət array qaytarır
- FilterProductByName() - string dəyər qəbul edir və name dəyərində həmin string dəyər olan bütün productlardan ibarət siyahı qaytarır

Name, Price, Type deyeri olmadan, Product yarana bilmez.

Program.cs -də menu hissə qurmağınız lazımdır. Layihə run olanda Product əlavə etmək,Type-a görə filterlemək seçimləri olmalıdır menuda


*/