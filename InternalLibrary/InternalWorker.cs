using System;

namespace InternalLibrary
{
    internal class InternalWorker : IInternalWorker
    {
        public void DoWork()
        {
            Console.WriteLine($"内部 Worker 开始执行...");
        }
    }
}
