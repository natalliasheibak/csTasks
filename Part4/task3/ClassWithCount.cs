using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task3
{
    class ClassWithCount
    {
        public ClassWithCount()
        {
            addExemplar();
        }

        public static int ExemplarCount { get; private set; }

        public static int addExemplar()
        {
            return ++ExemplarCount;
        }
    }

    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod1()
        {
            Assert.AreEqual(ClassWithCount.ExemplarCount, 0);
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            ClassWithCount class1=new ClassWithCount();
            ClassWithCount class2 = new ClassWithCount();
            ClassWithCount class3 = new ClassWithCount();
            Assert.AreEqual(ClassWithCount.ExemplarCount, 3);
        }

    }
}
