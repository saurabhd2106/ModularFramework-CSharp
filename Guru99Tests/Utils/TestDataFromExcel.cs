using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Utils;
using NUnit.Framework;

namespace Guru99Tests.Utils
{
    public class TestDataFromExcel
    {
        static string  excelFilename;


        public static IEnumerable VerifyData()
        {
            yield return new TestCaseData("mngr288178", "meqajyp");


        }

        public static IEnumerable getDataFromExcel()
        {
            var workingDirectory = Environment.CurrentDirectory;


           var  currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            excelFilename = currentProjectDirectory +"/TestData/TestDataFromExcel.xlsx";

            DataTable testData = ExcelDriver.ReadDataFromExcel(excelFilename, "Credentials");

            foreach (DataRow row in testData.Rows)
            {
                yield return new TestCaseData(row.ItemArray);

            }

        }

    }
}