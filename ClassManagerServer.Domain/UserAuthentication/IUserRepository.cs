using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassManagerServer.Db;

namespace ClassManagerServer.Domain.UserAuthentication
{
    public interface IUserRepository
    {
        private readonly ClassManagerDbContext _context;
    }
}
