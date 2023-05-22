using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BL
{
    public class UserBL
    {
        public async Task<int> AddOrUpdateAsync(User entity)
        {
            return await new UserDAL().AddOrUpdateAsync(entity);
        }
    }
}
