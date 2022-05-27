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
            new User{UserID=1,Username="test",Password="test",},
            };
            foreach (User s in students)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var courses = new Patient[]
            {
            new Patient{PatientID=1050,FirstName="Abdullah",LastName="Ali"},
            new Patient{PatientID=4041,FirstName="Mohammed",LastName="Saleh"},
            };
            foreach (Patient c in courses)
            {
                context.Patients.Add(c);
            }
            context.SaveChanges();
        }
    }
}