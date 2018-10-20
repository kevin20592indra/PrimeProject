using log4net;
using PrimeProject.Business.Entity;

namespace PrimeProject.Business.Application.Manager
{
    public class TransactionManager : ModuleManager<Transaction>
    {
        public static ILog log = LogManager.GetLogger(typeof(TransactionManager).Name);

        private static TransactionManager singleton;

        private TransactionManager()
        {
        }

        public static TransactionManager GetInstance()
        {
            return singleton ?? (singleton = singleton = new TransactionManager());
        }
    }
}
