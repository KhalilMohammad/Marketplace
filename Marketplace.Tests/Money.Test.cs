using Marketplace.Domain;
using System;
using Xunit;

namespace Marketplace.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_of_money_gives_full_amount()
        {
            var coin1 = new Money(1);
            var coin2 = new Money(2);
            var coin3 = new Money(2);
            var banknote = new Money(5);
            Assert.Equal(banknote, coin1 + coin2 + coin3);
        }
    }
}
