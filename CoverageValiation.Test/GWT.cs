using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoverageValiation.Test
{
    [TestClass]
    public abstract class GWT
    {
        protected abstract void Given();
        protected abstract void When();

        [TestInitialize]
        public void Initialize()
        {
            Given();
            When();
        }
    }
}
