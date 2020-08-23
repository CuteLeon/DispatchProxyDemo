using System;

namespace InternalLibrary
{
    public class PublicWorker : IPublicWorker
    {
        public void DoWork()
        {
            Console.WriteLine($"公开 Worker 开始执行...");
        }
    }
}
