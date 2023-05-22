using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace DAL
{
    public class UserDAL : BaseDAL<DefaultDbContext, User, int>
    {
        public UserDAL() { }
        public UserDAL(DefaultDbContext context) : base(context) { }

        protected override Expression<Func<User, int>> GetIdByEntityExpression()
        {
            return item => item.Id;
        }
    }
}
