using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyGlance.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProjectContext>>()))
            {
                // Look for any projects.
                if (context.Project.Any())
                {
                    return;   // DB has been seeded
                }

                context.Project.AddRange(
                    new Project
                    {
                        Title = "Web application using .NET Core",
                        StartDate = DateTime.Parse("2018-9-28"),
                        ReleaseDate = DateTime.Parse("2018-10-30")
                    },

                    new Project
                    {
                        Title = "Android App",
                        StartDate = DateTime.Parse("2017-9-28"),
                        ReleaseDate = DateTime.Parse("2017-12-10")
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
