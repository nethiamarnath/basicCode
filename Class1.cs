using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
namespace Product.Models
{
    internal class Class1
    {
        public void PostCategoryDetails()
        {
            Guid guid = Guid.NewGuid();
            List<Category> categories = new List<Category>();
            Category c1 = new Category();
            string data = File.ReadAllText("Category.json");
            List<Category> category = JsonConvert.DeserializeObject<List<Category>>(data);
            c1.Id = guid.ToString();
            Console.WriteLine("Enter Category Name : ");
            c1.CategoryName = Console.ReadLine();
            c1.AddedOn = DateTime.Today;
            Console.WriteLine("Enter Vendors Id");
            c1.AddedBy = Console.ReadLine();
            category.Add(c1);
            string strObject = JsonConvert.SerializeObject(category);
            StreamWriter sw = new StreamWriter("Category.json");
            sw.WriteLine(strObject);
            sw.Close();
        }
        public void UpdateCategory(string id, string newCategory)
        {
            string data = File.ReadAllText("Category.json");
            List<Category> category = JsonConvert.DeserializeObject<List<Category>>(data);
            var findData = category.Find(x => x.AddedBy == id);
            if (findData != null)
            {
                findData.CategoryName = newCategory;
                Console.WriteLine("Category Name is updated");
            }
            else
            {
                Console.WriteLine(" vendor Id doesn't exist ");
            }
            string strObject = JsonConvert.SerializeObject(category);
            StreamWriter sw = new StreamWriter("Category.json");
            sw.WriteLine(strObject);
            sw.Close();
        }
        public string FindCategoryDetails(string name)
        {
            string data = File.ReadAllText("Category.json");
            List<Category> category = JsonConvert.DeserializeObject<List<Category>>(data);
            var findData = category.Find(x => x.CategoryName == name);
            if (findData != null)
            {
                return findData.Id;

            }
            else
            {
                return "new Category";

            }
        }
        public void PostProductDetails()
        {
            Guid guid = Guid.NewGuid();
            List<Products> products = new List<Products>();
            Products p1 = new Products();
            string data = File.ReadAllText("Products.json");
            List<Products> products1 = JsonConvert.DeserializeObject<List<Products>>(data);
            p1.Id = guid.ToString();
            Console.WriteLine("Enter Product Name :");
            p1.ProductName = Console.ReadLine();
            Console.WriteLine("Enter Category Name :");
            p1.CategoryName = Console.ReadLine();
            p1.CategoryId = FindCategoryDetails(p1.CategoryName);
            Console.WriteLine("Enter Price of the product");
            p1.Price = Convert.ToInt32(Console.ReadLine());
            p1.AddedOn = DateTime.Today;
            p1.IsInUse = true;
            Console.WriteLine("Name of the Retailer");
            p1.AddedBy = Console.ReadLine();
            products1.Add(p1);
            string strObject = JsonConvert.SerializeObject(products1);
            StreamWriter sw = new StreamWriter("Products.json");
            sw.WriteLine(strObject);
            sw.Close();
        }
        public void FindProductsByCategory(string name)
        {
            string data = File.ReadAllText("Products.json");
            List<Products> products1 = JsonConvert.DeserializeObject<List<Products>>(data);
            List<Products> user = products1.FindAll(x => x.CategoryName == name).ToList<Products>();
            if (user != null)
            {
                foreach (var d in user)
                {
                    Console.WriteLine(" Product Name : {0}            Price : {1}        Added By : {2}                   Date : {3}", d.ProductName, d.Price, d.AddedBy, d.AddedOn.ToShortDateString());
                }

            }
            else
            {
                Console.WriteLine("No Products Available in " + name);

            }
        }
        public void GetProducts()
        {
            string data = File.ReadAllText("Products.json");
            List<Products> products1 = JsonConvert.DeserializeObject<List<Products>>(data);
           
            if (products1 != null)
            {
                foreach (var d in products1)
                {
                    Console.WriteLine(" \n \n Product Name : {0} \n Price : {1} \n Category Name : {2} \n Added By : {3} \n Date : {4}", d.ProductName, d.Price,d.CategoryName, d.AddedBy, d.AddedOn.ToShortDateString());
                }

            }
            else
            {
                Console.WriteLine("No Products Available in ");

            }
        }



    }
    public class Products
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
        public int Price { get; set; }
        public DateTime AddedOn { get; set; }
        public bool IsInUse { get; set; }
        public string AddedBy { get; set; }

    }
    public class Category
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
    }









}
