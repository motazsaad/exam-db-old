using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace exam_db.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<File> listOfFavoriteFile { get; set; }
        public int depatrmantId { get; set; }
        public virtual Department department { get; set; }
        public int collegeId { get; set; }
        public virtual College college { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<exam_db.Models.University> Universities { get; set; }

        public System.Data.Entity.DbSet<exam_db.Models.College> Colleges { get; set; }

        public System.Data.Entity.DbSet<exam_db.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<exam_db.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<exam_db.Models.File> Files { get; set; }
    }
}