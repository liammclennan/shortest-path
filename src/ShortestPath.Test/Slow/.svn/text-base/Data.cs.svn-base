using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain.DB;
using ShortestPath.Test.Creators;

namespace ShortestPath.Test.Slow
{
    public interface ITestData
    {
        void Build(IRepository repository);
    }

    public class Data : ITestData
    {
        IRepository repository;

        public void Build(IRepository repository)
        {
            this.repository = repository;
            BuildRouteTimeCache();
        }

        private void BuildRouteTimeCache()
        {
            var ethelChannel= new RouteTimeBuilder().Build();
            var channelEthel = new RouteTimeBuilder().WithStart(ethelChannel.Finish).WithFinish(ethelChannel.Start).Build();
            repository.MakePersistent(ethelChannel);
            repository.MakePersistent(channelEthel);
        }

    }
}
