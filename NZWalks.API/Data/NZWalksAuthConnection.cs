using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthConnection: IdentityDbContext<IdentityUser>
    {
        public NZWalksAuthConnection(DbContextOptions<NZWalksAuthConnection> options):base(options)
        { 
       
        
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "0134faf3-ab5d-4a45-9b5c-a835f687958e";
            var writerRoleId = "b3f7f7a6-c54e-4de0-bd68-c8ef6a75d2ae";



            var roles = new List<IdentityRole>
            {
               new IdentityRole
               {
                   Id = readerRoleId,
                   ConcurrencyStamp=readerRoleId,
                   Name="Reader",
                   NormalizedName="Reader".ToUpper()
               },
               new IdentityRole
               {
                   Id = writerRoleId,
                   ConcurrencyStamp=writerRoleId,
                   Name="Writer",
                   NormalizedName="Writer".ToUpper()
               }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
