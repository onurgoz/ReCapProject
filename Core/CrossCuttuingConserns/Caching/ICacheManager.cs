using System;

namespace Core.CrossCuttuingConserns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        Object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
