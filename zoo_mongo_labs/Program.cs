using System;
using zoo_mongo_labs;

class Program
{
    static void Main(string[] args)
    {
        var settings = new ZooDatabaseSettings
        {
            ConnectionString = "mongodb://localhost:27017",
            DatabaseName = "zooDB",
            EmployeeCollectionName = "employee",
            CustomerCollectionName = "customer",
            PetCollectionName = "pet",
            ProductCollectionName = "product",
            SaleCollectionName = "sale"
        };

        var service = new ZooService(settings);
        bool running = true;

        while (running)
        {
            Console.WriteLine("Zoo Database Application");
            Console.WriteLine("1. Create Document");
            Console.WriteLine("2. Read Documents");
            Console.WriteLine("3. Update Document");
            Console.WriteLine("4. Delete Document");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateDocument(service);
                    break;
                case "2":
                    ReadDocuments(service);
                    break;
                case "3":
                    UpdateDocument(service);
                    break;
                case "4":
                    DeleteDocument(service);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateDocument(ZooService service)
    {
        Console.WriteLine("Select entity to create:");
        Console.WriteLine("1. Employee");
        Console.WriteLine("2. Customer");
        Console.WriteLine("3. Pet");
        Console.WriteLine("4. Product");
        Console.WriteLine("5. Sale");
        var entityOption = Console.ReadLine();

        switch (entityOption)
        {
            case "1":
                var newEmployee = new Employee
                {
                    EmployeeId = GetIntInput("Enter Employee ID: "),
                    Name = GetStringInput("Enter Name: "),
                    Position = GetStringInput("Enter Position: "),
                    Email = GetStringInput("Enter Email: "),
                    Salary = GetDoubleInput("Enter Salary: ")
                };
                service.CreateEmployee(newEmployee);
                Console.WriteLine("Employee created.");
                break;
            case "2":
                var newCustomer = new Customer
                {
                    CustomerId = GetIntInput("Enter Customer ID: "),
                    Name = GetStringInput("Enter Name: "),
                    Email = GetStringInput("Enter Email: "),
                    Phone = GetStringInput("Enter Phone: "),
                    Address = GetStringInput("Enter Address: ")
                };
                service.CreateCustomer(newCustomer);
                Console.WriteLine("Customer created.");
                break;
            case "3":
                var newPet = new Pet
                {
                    PetId = GetIntInput("Enter Pet ID: "),
                    Species = GetStringInput("Enter Species: "),
                    Name = GetStringInput("Enter Name: "),
                    Breed = GetStringInput("Enter Breed: "),
                    Birthdate = GetDateInput("Enter Birthdate (yyyy-MM-dd): "),
                    HealthStatus = GetStringInput("Enter Health Status: ")
                };
                service.CreatePet(newPet);
                Console.WriteLine("Pet created.");
                break;
            case "4":
                var newProduct = new Product
                {
                    ProductId = GetIntInput("Enter Product ID: "),
                    Name = GetStringInput("Enter Name: "),
                    Price = GetDoubleInput("Enter Price: "),
                    Category = GetStringInput("Enter Category: "),
                    StockQuantity = GetIntInput("Enter Stock Quantity: ")
                };
                service.CreateProduct(newProduct);
                Console.WriteLine("Product created.");
                break;
            case "5":
                var newSale = new Sale
                {
                    SaleId = GetIntInput("Enter Sale ID: "),
                    Customer = new Customer
                    {
                        CustomerId = GetIntInput("Enter Customer ID: "),
                        Name = GetStringInput("Enter Customer Name: "),
                        Email = GetStringInput("Enter Customer Email: "),
                        Phone = GetStringInput("Enter Customer Phone: "),
                        Address = GetStringInput("Enter Customer Address: ")
                    },
                    Employee = new Employee
                    {
                        EmployeeId = GetIntInput("Enter Employee ID: "),
                        Name = GetStringInput("Enter Employee Name: "),
                        Position = GetStringInput("Enter Employee Position: "),
                        Email = GetStringInput("Enter Employee Email: "),
                        Salary = GetDoubleInput("Enter Employee Salary: ")
                    },
                    Pet = new Pet
                    {
                        PetId = GetIntInput("Enter Pet ID: "),
                        Species = GetStringInput("Enter Pet Species: "),
                        Name = GetStringInput("Enter Pet Name: "),
                        Breed = GetStringInput("Enter Pet Breed: "),
                        Birthdate = GetDateInput("Enter Pet Birthdate (yyyy-MM-dd): "),
                        HealthStatus = GetStringInput("Enter Pet Health Status: ")
                    },
                    Product = new Product
                    {
                        ProductId = GetIntInput("Enter Product ID: "),
                        Name = GetStringInput("Enter Product Name: "),
                        Price = GetDoubleInput("Enter Product Price: "),
                        Category = GetStringInput("Enter Product Category: "),
                        StockQuantity = GetIntInput("Enter Product Stock Quantity: ")
                    },
                    SaleDate = GetDateInput("Enter Sale Date (yyyy-MM-dd): "),
                    TotalAmount = GetDoubleInput("Enter Total Amount: "),
                    PaymentMethod = GetStringInput("Enter Payment Method: ")
                };
                service.CreateSale(newSale);
                Console.WriteLine("Sale created.");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static void ReadDocuments(ZooService service)
    {
        Console.WriteLine("Select entity to read:");
        Console.WriteLine("1. Employee");
        Console.WriteLine("2. Customer");
        Console.WriteLine("3. Pet");
        Console.WriteLine("4. Product");
        Console.WriteLine("5. Sale");
        var entityOption = Console.ReadLine();

        switch (entityOption)
        {
            case "1":
                var employees = service.GetEmployees();
                foreach (var emp in employees)
                {
                    Console.WriteLine($"ID: {emp.EmployeeId}, Name: {emp.Name}, Position: {emp.Position}, Email: {emp.Email}, Salary: {emp.Salary}");
                }
                break;
            case "2":
                var customers = service.GetCustomers();
                foreach (var cust in customers)
                {
                    Console.WriteLine($"ID: {cust.CustomerId}, Name: {cust.Name}, Email: {cust.Email}, Phone: {cust.Phone}, Address: {cust.Address}");
                }
                break;
            case "3":
                var pets = service.GetPets();
                foreach (var pet in pets)
                {
                    Console.WriteLine($"ID: {pet.PetId}, Species: {pet.Species}, Name: {pet.Name}, Breed: {pet.Breed}, Birthdate: {pet.Birthdate}, HealthStatus: {pet.HealthStatus}");
                }
                break;
            case "4":
                var products = service.GetProducts();
                foreach (var prod in products)
                {
                    Console.WriteLine($"ID: {prod.ProductId}, Name: {prod.Name}, Price: {prod.Price}, Category: {prod.Category}, StockQuantity: {prod.StockQuantity}");
                }
                break;
            case "5":
                var sales = service.GetSales();
                foreach (var sale in sales)
                {
                    Console.WriteLine($"ID: {sale.SaleId}, Customer: {sale.Customer.Name}, Employee: {sale.Employee.Name}, Pet: {sale.Pet.Name}, Product: {sale.Product.Name}, SaleDate: {sale.SaleDate}, TotalAmount: {sale.TotalAmount}, PaymentMethod: {sale.PaymentMethod}");
                }
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static void UpdateDocument(ZooService service)
    {
        Console.WriteLine("Select entity to update:");
        Console.WriteLine("1. Employee");
        Console.WriteLine("2. Customer");
        Console.WriteLine("3. Pet");
        Console.WriteLine("4. Product");
        Console.WriteLine("5. Sale");
        var entityOption = Console.ReadLine();

        Console.Write("Enter the ID of the document to update: ");
        var id = Console.ReadLine();

        switch (entityOption)
        {
            case "1":
                var updatedEmployee = new Employee
                {
                    Id = id,
                    EmployeeId = GetIntInput("Enter Employee ID: "),
                    Name = GetStringInput("Enter Name: "),
                    Position = GetStringInput("Enter Position: "),
                    Email = GetStringInput("Enter Email: "),
                    Salary = GetDoubleInput("Enter Salary: ")
                };
                service.UpdateEmployee(id, updatedEmployee);
                Console.WriteLine("Employee updated.");
                break;
            case "2":
                var updatedCustomer = new Customer
                {
                    Id = id,
                    CustomerId = GetIntInput("Enter Customer ID: "),
                    Name = GetStringInput("Enter Name: "),
                    Email = GetStringInput("Enter Email: "),
                    Phone = GetStringInput("Enter Phone: "),
                    Address = GetStringInput("Enter Address: ")
                };
                service.UpdateCustomer(id, updatedCustomer);
                Console.WriteLine("Customer updated.");
                break;
            case "3":
                var updatedPet = new Pet
                {
                    Id = id,
                    PetId = GetIntInput("Enter Pet ID: "),
                    Species = GetStringInput("Enter Species: "),
                    Name = GetStringInput("Enter Name: "),
                    Breed = GetStringInput("Enter Breed: "),
                    Birthdate = GetDateInput("Enter Birthdate (yyyy-MM-dd): "),
                    HealthStatus = GetStringInput("Enter Health Status: ")
                };
                service.UpdatePet(id, updatedPet);
                Console.WriteLine("Pet updated.");
                break;
            case "4":
                var updatedProduct = new Product
                {
                    Id = id,
                    ProductId = GetIntInput("Enter Product ID: "),
                    Name = GetStringInput("Enter Name: "),
                    Price = GetDoubleInput("Enter Price: "),
                    Category = GetStringInput("Enter Category: "),
                    StockQuantity = GetIntInput("Enter Stock Quantity: ")
                };
                service.UpdateProduct(id, updatedProduct);
                Console.WriteLine("Product updated.");
                break;
            case "5":
                var updatedSale = new Sale
                {
                    Id = id,
                    SaleId = GetIntInput("Enter Sale ID: "),
                    Customer = new Customer
                    {
                        CustomerId = GetIntInput("Enter Customer ID: "),
                        Name = GetStringInput("Enter Customer Name: "),
                        Email = GetStringInput("Enter Customer Email: "),
                        Phone = GetStringInput("Enter Customer Phone: "),
                        Address = GetStringInput("Enter Customer Address: ")
                    },
                    Employee = new Employee
                    {
                        EmployeeId = GetIntInput("Enter Employee ID: "),
                        Name = GetStringInput("Enter Employee Name: "),
                        Position = GetStringInput("Enter Employee Position: "),
                        Email = GetStringInput("Enter Employee Email: "),
                        Salary = GetDoubleInput("Enter Employee Salary: ")
                    },
                    Pet = new Pet
                    {
                        PetId = GetIntInput("Enter Pet ID: "),
                        Species = GetStringInput("Enter Pet Species: "),
                        Name = GetStringInput("Enter Pet Name: "),
                        Breed = GetStringInput("Enter Pet Breed: "),
                        Birthdate = GetDateInput("Enter Pet Birthdate (yyyy-MM-dd): "),
                        HealthStatus = GetStringInput("Enter Pet Health Status: ")
                    },
                    Product = new Product
                    {
                        ProductId = GetIntInput("Enter Product ID: "),
                        Name = GetStringInput("Enter Product Name: "),
                        Price = GetDoubleInput("Enter Product Price: "),
                        Category = GetStringInput("Enter Product Category: "),
                        StockQuantity = GetIntInput("Enter Product Stock Quantity: ")
                    },
                    SaleDate = GetDateInput("Enter Sale Date (yyyy-MM-dd): "),
                    TotalAmount = GetDoubleInput("Enter Total Amount: "),
                    PaymentMethod = GetStringInput("Enter Payment Method: ")
                };
                service.UpdateSale(id, updatedSale);
                Console.WriteLine("Sale updated.");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static void DeleteDocument(ZooService service)
    {
        Console.WriteLine("Select entity to delete:");
        Console.WriteLine("1. Employee");
        Console.WriteLine("2. Customer");
        Console.WriteLine("3. Pet");
        Console.WriteLine("4. Product");
        Console.WriteLine("5. Sale");
        var entityOption = Console.ReadLine();

        Console.Write("Enter the ID of the document to delete: ");
        var id = Console.ReadLine();

        switch (entityOption)
        {
            case "1":
                service.DeleteEmployee(id);
                Console.WriteLine("Employee deleted.");
                break;
            case "2":
                service.DeleteCustomer(id);
                Console.WriteLine("Customer deleted.");
                break;
            case "3":
                service.DeletePet(id);
                Console.WriteLine("Pet deleted.");
                break;
            case "4":
                service.DeleteProduct(id);
                Console.WriteLine("Product deleted.");
                break;
            case "5":
                service.DeleteSale(id);
                Console.WriteLine("Sale deleted.");
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static string GetStringInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    static int GetIntInput(string prompt)
    {
        Console.Write(prompt);
        return int.Parse(Console.ReadLine());
    }

    static double GetDoubleInput(string prompt)
    {
        Console.Write(prompt);
        return double.Parse(Console.ReadLine());
    }

    static DateTime GetDateInput(string prompt)
    {
        Console.Write(prompt);
        return DateTime.Parse(Console.ReadLine());
    }
}
