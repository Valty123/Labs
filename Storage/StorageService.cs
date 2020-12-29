using LAB1.Models;

namespace LAB1.Storage
{
    public class StorageService 
    {
        private readonly IStorage<LAB1Data> _storage;

        public StorageService (IStorage<LAB1Data> storage)
        {
            _storage=storage;
        }

        public string GetStorageType()
        {
            return _storage.StorageType;
        }
        public int GetNumberOfItems()
        {
            return _storage.All.Count;
        }
    }
}