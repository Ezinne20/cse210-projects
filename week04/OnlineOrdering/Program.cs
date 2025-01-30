using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

public class Order
{
    private List<Product> _products;
    private double _totalPrice;

    public Order()
    {
        _products = new List<Product>();
        _totalPrice = 0.0;
    }

    // Add product to the order, and automatically update total price
    public void AddProduct(Product product)
    {
        _products.Add(product);
        _totalPrice += product.Price;
    }

    // Get the order details (encapsulating internal list of products)
    public void ShowOrderDetails()
    {
        Console.WriteLine("Order Details:");
        foreach (var product in _products)
        {
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
        }
        Console.WriteLine($"Total Price: {_totalPrice}");
    }
}

public class Customer
{
    public string Name { get; set; }
    public string Address { get; set; }

    public Customer(string name, string address)
    {
        Name = name;
        Address = address;
    }
}

public class OrderManager
{
    private Order _order;
    private Customer _customer;

    public OrderManager(Customer customer)
    {
        _customer = customer;
        _order = new Order();
    }

    public void AddProductToOrder(Product product)
    {
        _order.AddProduct(product);
    }

    public void ShowOrder()
    {
        Console.WriteLine($"Customer: {_customer.Name}, Address: {_customer.Address}");
        _order.ShowOrderDetails();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create customer and products
        Customer customer = new Customer("John Doe", "123 Main St");
        Product product1 = new Product("Laptop", 999.99);
        Product product2 = new Product("Headphones", 199.99);

        // Create order manager and add products
        OrderManager orderManager = new OrderManager(customer);
        orderManager.AddProductToOrder(product1);
        orderManager.AddProductToOrder(product2);

        // Show order details
        orderManager.ShowOrder();
    }
}
