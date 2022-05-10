using System;
using System.Reflection;

namespace MethodLib.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Method m = TestClass.TMInfo;
            Func<bool> pref = () =>
            {
                Console.WriteLine("Gotcha!");
                return false;
            };
            Action act = () => Console.WriteLine("Postfix");
            Action<string, string> act2 = (arg1, arg2) => Console.WriteLine($"Postfix {arg1} {arg2}");
            m.AddPrefix(pref);
            m.AddPostfix(act);
            m.AddPostfix(act2, true);
            var copy4 = m.Copy().Copy().Copy().Copy();
            copy4.Invoke(null, "nice", "nice");
            TestClass.TestMethod("arefwefewfewfg1", "arwefewfewfg2");
        }
    }
    public static class TestClass
    {
        public static MethodInfo TMInfo = typeof(TestClass).GetMethod("TestMethod");
        public static void TestMethod(string arg1, string arg2)
        {
            Console.WriteLine("Jesus");
        }
    }
}
