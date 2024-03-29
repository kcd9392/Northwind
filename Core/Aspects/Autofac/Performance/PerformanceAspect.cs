using System.Diagnostics;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Performance;

public class PerformanceAspect : MethodInterception
{
    private int _interval;

    public PerformanceAspect(int interval)
    {
        _interval = interval;
        _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
    }

    private Stopwatch _stopwatch;

    protected override void OnBefore(IInvocation invocation)
    {
        _stopwatch.Start();
    }

    protected override void OnAfter(IInvocation invocation)
    {
        if (_stopwatch.Elapsed.TotalSeconds > _interval)
        {
            Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
        }
        _stopwatch.Reset();
    }
}