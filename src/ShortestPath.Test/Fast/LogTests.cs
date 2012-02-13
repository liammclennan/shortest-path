using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using ShortestPath.Core.Domain.DB;
using ShortestPath.Core.Domain.Persisted;
using ShortestPath.Core.Services;
using SpecUnit;

namespace ShortestPath.Test.Fast
{
    [Concern("Logging")]
    public class when_saving_a_log : BaseSpec
    {
        private ILogService logService;

        protected override void Given()
        {
            container.GetMock<IThreadCache>().Expect(tc => tc.IP).Returns("192.168.200.50");
            container.GetMock<IRepository>()
                .Expect(r => r.MakePersistent(It.IsAny<Log>())).Callback((Log log) => Assert.IsTrue(DateTime.Now - log.Timestamp < new TimeSpan(0,0, 10)));
            logService = container.Create<LogService>();
        }

        protected override void Do()
        {
            logService.Write(Log.LogType.SEARCH, "data");
        }

        [Observation]
        public void should_have_a_time()
        {
        }
    }
}
