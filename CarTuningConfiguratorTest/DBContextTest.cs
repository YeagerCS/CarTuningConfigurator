using CarTuningConfigurator;
using MySql.Data.MySqlClient;

namespace CarTuningConfiguratorTest
{
    [TestClass]
    public class DBContextTest
    {
        [TestMethod]
        public void TestDatabaseConnection()
        {
            DBContext dbContext = new DBContext();
            MySqlConnection conn = dbContext.GetDefaultConnection();

            Assert.AreNotEqual(conn, null);
        }
    }
}
