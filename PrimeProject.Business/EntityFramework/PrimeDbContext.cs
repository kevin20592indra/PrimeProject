using System.Web;

namespace PrimeProject.Business.EntityFramework
{
    public class PrimeDbContext
    {
        public static PrimeContext GetDbContext()
        {
            var DbLoginContext = HttpContext.Current.Items["DbLoginContext"] as PrimeContext;

            if (DbLoginContext == null)
            {
                DbLoginContext = new PrimeContext();
                HttpContext.Current.Items["DbLoginContext"] = DbLoginContext;
            }

            return DbLoginContext;
        }

        public static void DisposeDbContext()
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            var DbContext = HttpContext.Current.Items["DbLoginContext"] as PrimeContext;

            if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }

        public static void ExecuteSQLCommand(string cmd)
        {
            GetDbContext().Database.SqlQuery<string>(cmd);
        }
    }
}
