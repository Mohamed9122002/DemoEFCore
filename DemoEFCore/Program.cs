using DemoEFCore.DbContexts;

namespace DemoEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Database Connection [Unmanaged Resourse]
            using CompanyDbContext companyDb = new CompanyDbContext();

        }
    }
}
