//using Microsoft.Extensions.Configuration;

namespace XUnitTestClubsCore
{
    /*
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //opts => opts.UseSqlServer(Configuration["ConnectionString:ClubsDb"])
            IConfiguration conf = Conf();
            string conn = conf["ConnectionString:ClubsDb"];
            //string conn = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=ClubsDb; Integrated Security=True; MultipleActiveResultSets=True; AttachDbFilename=C:\\Users\\Катя\\source\\repos\\ClubsCore\\ClubsCore\\bin\\Debug\\netcoreapp3.1\\ClubsDb.mdf";
            DbContextOptions options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), conn).Options;
            ClubsContext context = new ClubsContext(options);
            ClubManager manager = new ClubManager(context);
            ClubsController controller = new ClubsController(manager);

            // Test Clubs
            var result = controller.Get();
            Assert.NotNull(result);

            result = controller.Get(1);
            Assert.NotNull(result);

            // Test Students
            StudentManager m = new StudentManager(context);
            StudentsController c = new StudentsController(m);

            result = c.Get();
            Assert.NotNull(result);

            result = c.Get(1);
            Assert.NotNull(result);
        }

        private IConfiguration Conf()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", true, true)
              .AddEnvironmentVariables();

            return builder.Build();
        }
    }
    */
}