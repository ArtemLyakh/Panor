using System;
namespace Panor.Dependencies
{
    public interface ICrypt
    {
        string Encrypt(string key, string data);
    }
}
