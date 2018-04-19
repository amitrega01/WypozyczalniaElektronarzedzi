using System;

namespace UI.Interfaces
{
    public interface IService : IDisposable
    {
        void AddEntity<T>(T entity);
        int GetMax();
    }
}