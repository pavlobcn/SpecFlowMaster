using MbUnit.Framework;

// ReSharper disable once CheckNamespace
namespace PB.SpecFlowMaster.Examples
{
    public class Steps
    {
        protected void AreEqual(object expected, object actual)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
