using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Utils;
using NUnit.Framework;

namespace Guru99Tests.Utils
{
    public class TestDataFromDatabase
    {
        public static IEnumerable GetDataFromDatabase()
        {
            DataBaseUtils dbConnector = new DataBaseUtils("localhost", "testdata", "root", "Gurgaon21!!");
            dbConnector.OpenConnection();

            string sqlQuery = "select * from test_product";

            DataTable testData = dbConnector.ExecuteSelectSqlQuery(sqlQuery);

            dbConnector.CloseConnection();

            foreach (DataRow row in testData.Rows)
            {
                yield return new TestCaseData(row.ItemArray);

            }

        }
    }
}