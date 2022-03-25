using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Config
{
    public class DressMeDatabaseSettings : IDressMeDatabaseSettings
    {
        public string HautCollectionName { get; set; }
        public string BasCollectionName { get; set; }
        public string ChaussureCollectionName { get; set; }
        public string TenueCollectionName { get; set; }
        public string ArticleCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface IDressMeDatabaseSettings
    {
        
        public string HautCollectionName { get; set; }
        public string BasCollectionName { get; set; }
        public string ChaussureCollectionName { get; set; }
        public string TenueCollectionName { get; set; }
        public string ArticleCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}
