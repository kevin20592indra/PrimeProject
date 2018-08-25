using log4net;
using PrimeProject.Business.Entity;

namespace PrimeProject.Business.Application.Manager
{
    public class ItemManager : ModuleManager<Item>
    {
        public static ILog log = LogManager.GetLogger(typeof(ItemManager).Name);

        private static ItemManager singleton;

        private ItemManager()
        {
        }

        public static ItemManager GetInstance()
        {
            return singleton ?? (singleton = singleton = new ItemManager());
        }
    }
}
