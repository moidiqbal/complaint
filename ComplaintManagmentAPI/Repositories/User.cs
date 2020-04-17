using ComplaintManagmentAPI.Repositories.SqlServer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintManagmentAPI.Repositories
{
    public interface IUSer
    {
        Task<IEnumerable<Models.User>> GetAll();

        Task<Models.User> GetBy(Models.User obj);
        Task<int> Insert(Models.User obj);
        Task<bool> Update(Models.User obj);
        Task<bool> Delete(string id);
    }
    public class User : IUSer
    {

        protected IDbContext _dbContext = null;

        public User(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.User>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<Models.User> GetBy(Models.User obj)
        {
            var p = new DynamicParameters();
            p.Add("@Email", obj.Email);
            p.Add("@Password",obj.Password);

            var entity = await _dbContext.Connection.QuerySingleOrDefaultAsync<Models.User>
            ("User_Get", p, commandType: CommandType.StoredProcedure);

            return entity;
        }

        public async  Task<int> Insert(Models.User obj)
        {
            var p = new DynamicParameters();
            p.Add("@id", Guid.NewGuid().ToString());
            p.Add("@Password", obj.Password);
            p.Add("@Mobile", obj.Mobile);
            p.Add("@Email", obj.Email);
            var ok = await _dbContext.Connection.ExecuteAsync
             ("User_Insert", p, commandType: CommandType.StoredProcedure, transaction: _dbContext.Transaction);

            return 0;
        }

        public Task<bool> Update(Models.User obj)
        {
            throw new NotImplementedException();
        }
    }
}
