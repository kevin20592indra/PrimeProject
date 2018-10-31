using log4net;
using PrimeProject.Business.Entity;

namespace PrimeProject.Business.Application.Manager
{
    public class StockManager : ModuleManager<Stock>
    {
        public static ILog log = LogManager.GetLogger(typeof(StockManager).Name);

        private static StockManager singleton;

        private StockManager()
        {
        }

        public static StockManager GetInstance()
        {
            return singleton ?? (singleton = singleton = new StockManager());
        }
    }
}
