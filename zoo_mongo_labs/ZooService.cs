using System;
using MongoDB.Driver;
using System.Collections.Generic;

namespace zoo_mongo_labs
{
    public class ZooService
    {
        private readonly IMongoCollection<Employee> _employees;
        private readonly IMongoCollection<Customer> _customers;
        private readonly IMongoCollection<Pet> _pets;
        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<Sale> _sales;

        public ZooService(ZooDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeeCollectionName);
            _customers = database.GetCollection<Customer>(settings.CustomerCollectionName);
            _pets = database.GetCollection<Pet>(settings.PetCollectionName);
            _products = database.GetCollection<Product>(settings.ProductCollectionName);
            _sales = database.GetCollection<Sale>(settings.SaleCollectionName);
        }

        // Create
        public void CreateEmployee(Employee employee) => _employees.InsertOne(employee);
        public void CreateCustomer(Customer customer) => _customers.InsertOne(customer);
        public void CreatePet(Pet pet) => _pets.InsertOne(pet);
        public void CreateProduct(Product product) => _products.InsertOne(product);
        public void CreateSale(Sale sale) => _sales.InsertOne(sale);

        // Read
        public List<Employee> GetEmployees() => _employees.Find(emp => true).ToList();
        public List<Customer> GetCustomers() => _customers.Find(cust => true).ToList();
        public List<Pet> GetPets() => _pets.Find(pet => true).ToList();
        public List<Product> GetProducts() => _products.Find(prod => true).ToList();
        public List<Sale> GetSales() => _sales.Find(sale => true).ToList();

        // Update
        public void UpdateEmployee(string id, Employee employee) => _employees.ReplaceOne(emp => emp.Id == id, employee);
        public void UpdateCustomer(string id, Customer customer) => _customers.ReplaceOne(cust => cust.Id == id, customer);
        public void UpdatePet(string id, Pet pet) => _pets.ReplaceOne(pet => pet.Id == id, pet);
        public void UpdateProduct(string id, Product product) => _products.ReplaceOne(prod => prod.Id == id, product);
        public void UpdateSale(string id, Sale sale) => _sales.ReplaceOne(sale => sale.Id == id, sale);

        // Delete
        public void DeleteEmployee(string id) => _employees.DeleteOne(emp => emp.Id == id);
        public void DeleteCustomer(string id) => _customers.DeleteOne(cust => cust.Id == id);
        public void DeletePet(string id) => _pets.DeleteOne(pet => pet.Id == id);
        public void DeleteProduct(string id) => _products.DeleteOne(prod => prod.Id == id);
        public void DeleteSale(string id) => _sales.DeleteOne(sale => sale.Id == id);
    }
}

