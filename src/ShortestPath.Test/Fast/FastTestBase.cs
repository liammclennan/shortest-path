using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace ShortestPath.Test.Fast
{
    public class FastTestBase
    {
        protected AutoMockContainer container = new AutoMockContainer(new MockFactory(MockBehavior.Loose));
    }
}
