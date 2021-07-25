using DatabaseRefactoring.DataBase;
using DatabaseRefactoring.DataBase.Builder;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;

namespace DatabaseOperationsTests
{
    public class Tests
    {
        private IModelPropertyFiller<InjectionFactData> modelPropertyFiller;
        private IBuilder<InjectionFactData, KeyValuePair<DateTime, Dictionary<int, object>>> builder;
        private IDataBaseOperation<ICollection<InjectionFactData>, InjectionInputParametesModel, SqlConnection> operation;
        private IDatabaseConnectionProvider<SqlConnection> connectionProvider;

        [SetUp]
        public void Setup()
        {
            modelPropertyFiller = new InjectionFactDataPropertyFiller();
            builder = new InjectionFactDataBuilder(modelPropertyFiller);
            operation = new GetInjectionFromDb(builder);
            connectionProvider = new SqlServerConnectionProvider("Data Source=DESKTOP-H5IRS9N;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
        }

        [Test]
        public void Test1()
        {
            operation.Execute(new InjectionInputParametesModel(), connectionProvider.CreateConnection());
            Assert.Pass();
        }
    }
}