using LibraNET.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data.Tests.Mocks
{
    public class DatabaseMock
    {
        public static LibraNetDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<LibraNetDbContext>()
                    .UseInMemoryDatabase("LibraNETInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new LibraNetDbContext(dbContextOptions, false);
            }
        }
    }
}
