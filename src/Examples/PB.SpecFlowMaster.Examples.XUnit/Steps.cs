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
            try
            {
                Assert.Equal(expected, actual);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
