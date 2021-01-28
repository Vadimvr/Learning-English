using NUnit.Framework;
using LElWPF.Core;

namespace Tests
{
    public class Tests
    {
        [TestFixture]
        public class PathToMultimedia_Test
        {
            private LElWPF.Core.Models.PathToMultimedia _PathToMultimedia;

            [SetUp]
            public void SetUp()
            {
                _primeService = new PrimeService();
            }

            [Test]
            public void IsPrime_InputIs1_ReturnFalse()
            {
                var result = _primeService.IsPrime(1);

                Assert.IsFalse(result, "1 should not be prime");
            }
        }
    }
}