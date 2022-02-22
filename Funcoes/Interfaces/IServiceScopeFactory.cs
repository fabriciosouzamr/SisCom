using System;
using System.Collections.Generic;

namespace Funcoes.Interfaces
{
    public interface IServiceScopeFactory<T> where T : class
    {
        IServiceScope<T> CreateScope();
    }

    public interface IServiceScope<T> : IDisposable where T : class
    {
        T GetRequiredService();
        T GetService();
        IEnumerable<T> GetServices();
    }
}