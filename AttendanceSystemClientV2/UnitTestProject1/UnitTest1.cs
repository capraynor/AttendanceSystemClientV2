using System;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AttendanceSystemClientV2;
namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {

        /// <summary>
        /// 获取班级表并提取其中一个班级名称
        /// 测试数据: BJID:201304 BJNAME:2013级软件工程4班
        /// </summary>
        [TestMethod]
        public void GetClassNameTest ( ) {

            //Console.WriteLine(Environment.CurrentDirectory);

            var dr = GlobalParams.ClassTable.Select (@"BJID = 201304");//拿出班级表

            Assert.AreEqual((string)dr.First()[@"BJNAME"] , "2013级软件工程4班");//比对结果 若结果与预期不一致则宣告失败


        }


    }
}
