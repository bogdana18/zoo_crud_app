using System;
namespace zoo_mongo_labs
{
    public class ZooDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string EmployeeCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string PetCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string SaleCollectionName { get; set; }
    }

}

