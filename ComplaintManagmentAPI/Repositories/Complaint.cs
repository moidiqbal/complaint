using ComplaintManagmentAPI.Repositories.SqlServer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintManagmentAPI.Repositories
{

    public interface IComplaint
    {
        Task<IEnumerable<Models.Complaint>> GetAll();

        Task<Models.Complaint> GetBy(string id);
        Task<int> Insert(Models.Complaint obj);
        Task<bool> Update(Models.Complaint obj);
        Task<bool> Delete(string id);
    }
    public class Complaint : IComplaint
    {

        protected IDbContext _dbContext = null;

        public Complaint(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.Complaint>> GetAll() 
        {
            var entities = await _dbContext.Connection.QueryAsync<Models.Complaint> ("Compaint_GetAll", commandType: CommandType.StoredProcedure);
            return entities;
        }

        public async Task<Models.Complaint> GetBy(string id)
        {
            var p = new DynamicParameters();
            p.Add("@id", id);

            var entity = await _dbContext.Connection.QuerySingleOrDefaultAsync<Models.Complaint>
            ("Compaint_GetBYid", p, commandType: CommandType.StoredProcedure);

            return entity;
        }

        public async Task<int> Insert(Models.Complaint obj)
        {
            var p = new DynamicParameters();
            p.Add("@id", Guid.NewGuid().ToString());
            p.Add("@userid", obj.userid);
            p.Add("@title", obj.title);
            p.Add("@Mobile", obj.Mobile);
            p.Add("@Email", obj.Email);
            p.Add("@description", obj.description);
            p.Add("@Date", DateTime.Now);
            var ok = await _dbContext.Connection.ExecuteAsync
          ("Complaint_insert", p, commandType: CommandType.StoredProcedure, transaction: _dbContext.Transaction);

            return 0;
        }

        public async Task<bool> Update(Models.Complaint obj)
        {
            var p = new DynamicParameters();
            p.Add("@id", obj.id);
            p.Add("@userid", obj.userid);
            p.Add("@title", obj.title);
            p.Add("@Mobile", obj.Mobile);
            p.Add("@Email", obj.Email);
            p.Add("@description", obj.description);
            p.Add("@Date", DateTime.Now.Date);
            var ok = await _dbContext.Connection.ExecuteAsync
              ("Complaint_Update", p, commandType: CommandType.StoredProcedure, transaction: _dbContext.Transaction);

            return true;
        }
    }
}
