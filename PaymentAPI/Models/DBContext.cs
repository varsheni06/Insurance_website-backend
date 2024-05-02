using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Models
{
    public class DBContext
    {
        private DbContextOptions options;

        public DBContext(DbContextOptions options)
        {
            this.options = options;
        }
    }
}