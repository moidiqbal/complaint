﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintManagmentAPI.Repositories.SqlServer
{
    public interface IDbContext : IDisposable
    {

        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        Task<IDbTransaction> OpenTransaction();
        Task<IDbTransaction> OpenTransaction(IsolationLevel level);
        void CommitTransaction(bool disposeTrans = true);
        void RollbackTransaction(bool disposeTrans = true);


        //Mazaad.Repository.ICityRepo CityRepo { get; }
        //Mazaad.Repository.ICountryRepo CountryRepo { get; }
        //Mazaad.Repository.IGenderRepo GenderRepo { get; }
        //Mazaad.Repository.IStatesRepo StatesRepo { get; }
        //Mazaad.Repository.IStatusRepo StatusRepo { get; }
     

    }





    public class DbContext : IDbContext
    {


        protected readonly IConfiguration _config;


        protected IDbConnection _cn = null;
        public IDbConnection Connection
        {
            get => _cn;
        }


        protected IDbTransaction _trans = null;
        public IDbTransaction Transaction
        {
            get => _trans;
        }






        /// <summary>
        /// Main constructor, inject standard config : Default connection string
        /// Need to be reviewed to be more generic (choose the connection string to inject)
        /// </summary>
        public DbContext()
        {

            DefaultTypeMap.MatchNamesWithUnderscores = true;
            _cn = new SqlConnection("Server=50.62.22.68;Database=ComplaintManagment;User id =sa ; Password=Secr3t123!#$");
        }


        /// <summary>
        /// Open a transaction
        /// </summary>
        public async Task<IDbTransaction> OpenTransaction()
        {
            if (_trans != null)
                throw new Exception("A transaction is already open, you need to use a new DbContext for parallel job.");

            if (_cn.State == ConnectionState.Closed)
            {
                if (!(_cn is DbConnection))
                    throw new Exception("Connection object does not support OpenAsync.");

                await (_cn as DbConnection).OpenAsync();
            }

            _trans = _cn.BeginTransaction();

            return _trans;
        }


        /// <summary>
        /// Open a transaction with a specified isolation level
        /// </summary>
        public async Task<IDbTransaction> OpenTransaction(IsolationLevel level)
        {
            if (_trans != null)
                throw new Exception("A transaction is already open, you need to use a new DbContext for parallel job.");

            if (_cn.State == ConnectionState.Closed)
            {
                if (!(_cn is DbConnection))
                    throw new Exception("Connection object does not support OpenAsync.");

                await (_cn as DbConnection).OpenAsync();
            }

            _trans = _cn.BeginTransaction(level);

            return _trans;
        }


        /// <summary>
        /// Commit the current transaction, and optionally dispose all resources related to the transaction.
        /// </summary>
        public void CommitTransaction(bool disposeTrans = true)
        {
            if (_trans == null)
                throw new Exception("DB Transaction is not present.");

            _trans.Commit();
            if (disposeTrans) _trans.Dispose();
            if (disposeTrans) _trans = null;
        }

        /// <summary>
        /// Rollback the transaction and all the operations linked to it, and optionally dispose all resources related to the transaction.
        /// </summary>
        public void RollbackTransaction(bool disposeTrans = true)
        {
            if (_trans == null)
                throw new Exception("DB Transaction is not present.");

            _trans.Rollback();
            if (disposeTrans) _trans.Dispose();
            if (disposeTrans) _trans = null;
        }

        /// <summary>
        /// Will be call at the end of the service (ex : transient service in api net core)
        /// </summary>
        public void Dispose()
        {
            _trans?.Dispose();
            _cn?.Close();
            _cn?.Dispose();
        }


    }
}
