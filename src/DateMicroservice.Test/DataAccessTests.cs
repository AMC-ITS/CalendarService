using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateMicroservice.Data;

namespace DateMicroservice.Test
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        public void ShouldRunQuery()
        {
            var connectionString = "Server=devdatalk01;Database=ODS;Integrated Security=SSPI";
            var commandText = "SELECT TOP 10 * FROM [ODS].[dbo].[DimDate]";
            BaseDataAccess bda = new BaseDataAccess(connectionString);
            var results = bda.RunQuery<DateModel>(commandText);
            Assert.IsTrue(results.Count == 10);
        }

        [TestMethod]
        public void ShouldRunSingleRowQuery()
        {
            var connectionString = "Server=devdatalk01;Database=ODS;Integrated Security=SSPI";
            var commandText = "SELECT * FROM [ODS].[dbo].[DimDate] WHERE CONVERT(date, [DateKey]) = CONVERT(date, @MyDate)";
            var commandParameters = new List<SqlParameter>();
            var dateParameter = new SqlParameter("@MyDate", SqlDbType.DateTime) {Value = new DateTime(2018, 1, 1)};
            commandParameters.Add(dateParameter);
            BaseDataAccess bda = new BaseDataAccess(connectionString);
            var results = bda.RunSingleRowQuery<DateModel>(commandText, commandParameters);
            Assert.IsNotNull(results);
        }
    }
}
