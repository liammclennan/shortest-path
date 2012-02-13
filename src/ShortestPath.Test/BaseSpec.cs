using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using ShortestPath.Core.Domain;
using SpecUnit;

namespace ShortestPath.Test
{
    /// <summary>
    /// Base class to use for BDD style tests.
    /// </summary>
    public abstract class BaseSpec : ContextSpecification
    {
        protected AutoMockContainer container = new AutoMockContainer(new MockFactory(MockBehavior.Loose));

        protected override void Context()
        {
            Given();
        }

        protected override void Because()
        {
            Do();
        }

        protected abstract void Given();

        protected abstract void Do();

        protected void AssertIsView(ActionResult result, string viewName)
        {
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(typeof(ViewResult), result);
            var view = (ViewResult)result;
            Assert.AreEqual(viewName, view.ViewName);
        }

        protected void AssertRoute(Route route, Point from, Point to)
        {
            Assert.AreEqual(route.From, from);
            Assert.AreEqual(route.To, to);
        }
    }
}