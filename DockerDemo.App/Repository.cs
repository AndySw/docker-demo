using System.Data.SqlClient;
using System.Collections.Generic;

namespace DockerDemo.App
{
    public class Repository
    {
        public Repository() {
            var x = new SqlConnection("Server=localhost;Database=TestDB;User Id=sa;Password=12345;");
        }

        public IEnumerable<string> GetData(){
            var data = new List<string>(){ "Test Value 1", "Test Value 2","Test Value 3"};
            return data;
        }
    }
}