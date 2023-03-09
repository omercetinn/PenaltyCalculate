using Microsoft.EntityFrameworkCore;

namespace PenaltyCalculate.Models
{
    public class DataContext:DbContext
    {
        public DbSet<UserInformation> UserInformations { get; set; }
       
    }
}
