using justice_technical_assestment.Infrastructure.Models;
using System;
using System.Linq;

namespace justice_technical_assestment.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClinicContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var students = new User[]
            {
            new User{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new User{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new User{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new User{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new User{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new User{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new User{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new User{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (User s in students)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var courses = new Patient[]
            {
            new Patient{PatientID=1050,Title="Chemistry",Credits=3},
            new Patient{PatientID=4022,Title="Microeconomics",Credits=3},
            new Patient{PatientID=4041,Title="Macroeconomics",Credits=3},
            new Patient{PatientID=1045,Title="Calculus",Credits=4},
            new Patient{PatientID=3141,Title="Trigonometry",Credits=4},
            new Patient{PatientID=2021,Title="Composition",Credits=3},
            new Patient{PatientID=2042,Title="Literature",Credits=4}
            };
            foreach (Patient c in courses)
            {
                context.Patients.Add(c);
            }
            context.SaveChanges();
        }
    }
}