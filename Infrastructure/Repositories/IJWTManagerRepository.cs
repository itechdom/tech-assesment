using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using justice_technical_assestment.Infrastructure.Models;

namespace justice_technical_assestment.Infrastructure.Repositories
{
   public interface IJWTManagerRepository
    {
        Tokens Authenticate(User user); 
    }
   
}