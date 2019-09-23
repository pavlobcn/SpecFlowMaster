using System;
using Xunit;

[assembly:CollectionBehavior(DisableTestParallelization = true)]

// ReSharper disable once CheckNamespace
namespace PB.SpecFlowMaster.Examples
{
    public class Steps
    {
        protected void AreEqual(object expected, object actual)
        {
            Assert.Equal(expected, actual);
        }
    }
}
