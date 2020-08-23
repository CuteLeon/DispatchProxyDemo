using System;
using System.Reflection;
using InternalLibrary;

namespace DispatchProxyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // 创建公开 Worker 的代理
            IPublicWorker publicProxy = DispatchProxy.Create<IPublicWorker, LogDispatchProxy>();
            publicProxy.DoWork();
            ((LogDispatchProxy)publicProxy).TargetInstance = new PublicWorker();
            publicProxy.DoWork();

            // 创建内部 Worker 的代理
            var internalInterfaceType = typeof(IPublicWorker).Assembly.GetType("InternalLibrary.IInternalWorker");
            var internalWorkerType = typeof(IPublicWorker).Assembly.GetType("InternalLibrary.InternalWorker");

            var internalProxy = typeof(DispatchProxy)
                .GetMethod(
                    nameof(DispatchProxy.Create),
                    BindingFlags.Public | BindingFlags.Static)
                .MakeGenericMethod(internalInterfaceType, typeof(LogDispatchProxy))
                .Invoke(null, null);

            Console.Read();
        }
    }
}
