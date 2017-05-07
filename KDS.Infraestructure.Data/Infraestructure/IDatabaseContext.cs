using KDS.Infraestructure.Data.Entities;
using System;

namespace KDS.Infraestructure.Data
{
    public interface IDatabaseContext : IDisposable
    {
        MainModelContext Get();
    }
}
