using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "London",  "Uk");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Davis", address1);
        Customer customer2 = new Customer("Jane Beer", address2);

        // Create products
        Product product1 = new Product("Laptop", "P001", 800, 1);
        Product product2 = new Product("Mouse", "P002", 20, 2);
        Product product3 = new Product("Keyboard", "P003", 50, 1);
        Product product4 = new Product("Monitor", "P004", 200, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display order details
        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}");
        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}

class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingLabel()
    {
        return $"{_name} (ID: {_productId})";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUK()
    {
        return _address.IsInUk();
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;
    private string v1;
    private string v2;
    private string v3;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public Address(string v1, string v2, string v3)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }

    public bool IsInUk()
    {
        return _country.ToLower() == "uk";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;
    private const double ShippingCostUk = 5.0;
    private const double ShippingCostInternational = 35.0;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        total += _customer.LivesInUK() ? ShippingCostUk : ShippingCostInternational;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in _products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}
