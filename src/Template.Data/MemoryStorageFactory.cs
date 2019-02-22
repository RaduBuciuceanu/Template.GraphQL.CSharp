namespace Template.Data
{
    public class MemoryStorageFactory : IStorageFactory
    {
        private IStorage _instance;

        public IStorage Make()
        {
            if (_instance == null)
            {
                _instance = new MemoryStorage();
            }

            return _instance;
        }
    }
}
