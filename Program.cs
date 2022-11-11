using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
namespace Product
{
    internal class Start
    {
        static void Main(String[] args)
        {
            Class1 productCate = new Class1();

        Top:

            Console.WriteLine("\n ******  Welcome to Products  ******");
            Console.WriteLine("1.Get Product List");
            Console.WriteLine("2.Insert new Product ");
            Console.WriteLine("3.Find Products By Category");
            Console.WriteLine("4.Insert new Category");
            Console.WriteLine("5.Update Category name");
            Console.WriteLine("6.Exit the Application");
            Console.WriteLine("Choose any option :");

            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    productCate.GetProducts();
                    break;
                case 2:
                    productCate.PostProductDetails();
                    break;
                case 3:
                    Console.WriteLine("enter category name");
                    string name = Console.ReadLine();
                    productCate.FindProductsByCategory(name);
                    break;
                case 4:
                    productCate.PostCategoryDetails();
                    break;
                case 5:
                    Console.WriteLine("Enter vendor Id :");
                    string id = Console.ReadLine();
                    Console.WriteLine("Enter Category name :");
                    string newCategory = Console.ReadLine();
                    productCate.UpdateCategory(id, newCategory);
                    break;
                case 6:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Entered Invalid choose ");
                    break;

            }
            goto Top;
        }
    }
}
