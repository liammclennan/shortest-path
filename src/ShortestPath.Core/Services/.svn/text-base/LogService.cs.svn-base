using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain.Persisted;
using ShortestPath.Core.Domain.DB;
using ShortestPath.Core.Domain;

namespace ShortestPath.Core.Services
{
    public interface ILogService
    {
        void Write(Log.LogType type, string data);
    }

    public class LogService : ILogService
    {
        IRepository repository;
        IThreadCache cache;

        public LogService(IRepository repository, IThreadCache cache)
        {
            this.repository = repository;
            this.cache = cache;
        }

        public void Write(Log.LogType type, string data)
        {
            Log log = new Log { Type = type, IP = cache.IP, Data = data };
            repository.MakePersistent(log);
        }
    }
}
