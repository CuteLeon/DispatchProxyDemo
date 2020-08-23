using System;
using System.Reflection;

namespace DispatchProxyDemo
{
    public class LogDispatchProxy : DispatchProxy
    {
        public object TargetInstance { get; set; }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Console.WriteLine($"==> Dispatch Proxy start invoke: {targetMethod.Name} => {targetMethod.ReturnType.Name}");

            object result = default;
            if (TargetInstance != null)
            {
                targetMethod.Invoke(TargetInstance, args);
            }
            else
            {
                Console.WriteLine($"Dispatch Proxy have no target instance.");
            }

            Console.WriteLine($"<== Dispatch Proxy finish invoke: {targetMethod.Name} => {targetMethod.ReturnType.Name}");
            return result;
        }
    }
}
