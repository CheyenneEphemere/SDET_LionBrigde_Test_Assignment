using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskEngineLib;

namespace TaskEngineTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Task TaskA, TaskB, TaskC, TaskD, TaskE;

            TaskA = new Task("A");
            TaskB = new Task("B");
            TaskC = new Task("C");
            TaskD = new Task("D");
            TaskE = new Task("E");

            TaskA.AddChildTask(TaskC);
            TaskA.AddChildTask(TaskB);

            TaskB.AddChildTask(TaskE);
            TaskB.AddChildTask(TaskD);

            TaskC.AddChildTask(TaskE);

        }


    }
}
