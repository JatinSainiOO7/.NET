     using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicConceptsClasses
{

    // Demo entry point for the generic repository example
    public static class GenericDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Application Started ---\n");

            ProductRepository repo = new ProductRepository();
            Random random = new Random();

            // ==========================================
            // GENERATING N PRODUCTS
            // ==========================================
            Console.WriteLine("Enter Product Numbers... ");
            int In = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= In; i++)
            {
                // Create a random price between 1 and In
                // Note: Random.Next's upper bound is exclusive, so the maximum possible value is In - 1
                decimal randomPrice = random.Next(1, In);

                repo.Add(new Product
                {
                    Id = i,
                    Name = $"Product_Item_{i}",
                    Price = randomPrice
                });
            }

            Console.WriteLine("Success! "+In+" Products added to the repository.\n");

            // ==========================================
            // DISPLAY DATA
            // ==========================================

            // 1. Count total
            Console.WriteLine($"Total count in DB: {repo.GetAll().Count}");

            // 2. Use the Specific Filter (Budget items below a given price)
            Console.WriteLine("Enter your Budget Products Price: ");
            int minPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n--- Showing Budget Products (Less then $"+minPrice+") ---");
     
            // Despite the method name, this returns items with price less than the provided value
            var expensiveItems = repo.GetExpensiveProducts(minPrice);

            foreach (var p in expensiveItems)
            {
                Console.WriteLine($"ID: Pro{p.Id} | {p.Name} | ${p.Price}");
            }

            Console.WriteLine($"\nFound {expensiveItems.Count} Budget items out of $"+minPrice);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }

    // ==========================================
    // 1. THE BASE ENTITIES
    // ==========================================
    public abstract class BaseEntity
    {
        // Common identifier for entities stored in repositories
        public int Id { get; set; }
    }

    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    // ==========================================
    // 2. THE GENERIC BASE (The "Parent")
    // ==========================================
    // Generic repository contract for entities that derive from BaseEntity
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        List<T> GetAll();
    }

    // A simple in-memory implementation of IRepository<T>
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        // 'protected' means child classes can access this, but outside code cannot.
        protected readonly List<T> _database = new List<T>();

        public void Add(T item)
        {
            _database.Add(item);
        }

        public List<T> GetAll()
        {
            return _database;
        }
    }

    // ==========================================
    // 3. THE SPECIFIC EXTENSION (The "Child")
    // ==========================================

    // This interface inherits all generic rules + adds specific rules for Product
    public interface IProductRepository : IRepository<Product>
    {
        // Returns products below the given price (budget items)
        List<Product> GetExpensiveProducts(decimal minPrice);
    }

    // This class inherits Generic logic + implements specific logic for Product
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public List<Product> GetExpensiveProducts(decimal minPrice)
        {
            // We can access '_database' because we marked it as 'protected' in the parent
            // NOTE: This returns products with Price < minPrice (i.e. budget/cheaper items)
            return _database.Where(p => p.Price < minPrice).ToList();
        }
    }
}