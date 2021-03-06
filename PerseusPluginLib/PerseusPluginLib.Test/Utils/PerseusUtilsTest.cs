﻿using System.IO;
using System.Text;
using NUnit.Framework;
using PerseusApi.Utils;
using PerseusPluginLib.Utils;

namespace PerseusPluginLib.Test.Utils
{
    [TestFixture]
    public class PerseusUtilsTest
    {
        [Test]
        public void TestWriteMultiNumericColumnWithNulls()
        {
            var data = PerseusFactory.CreateDataWithAnnotationColumns();
            data.AddMultiNumericColumn("Test", "", new double[1][]);
            data.AddStringColumn("Test2", "", new string[1]);
            Assert.AreEqual(1, data.RowCount);
            var writer = new StreamWriter(new MemoryStream());
            PerseusUtils.WriteDataWithAnnotationColumns(data, writer);
        }

        [Test]
        public void TestReadEmptyMatrixFromFile()
        {
            var data = PerseusFactory.CreateDataWithAnnotationColumns();
            PerseusUtils.ReadDataWithAnnotationColumns(data, BaseTest.CreateProcessInfo(), () =>
            {
                var memstream = new MemoryStream(Encoding.UTF8.GetBytes("Node\n#!{Type}T\n"));
                return new StreamReader(memstream);
            }, "test", '\t');
            Assert.AreEqual(0, data.RowCount);
        }

    }
}
