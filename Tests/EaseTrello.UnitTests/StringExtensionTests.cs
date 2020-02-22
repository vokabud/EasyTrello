using EaseTrello.Extension;
using EaseTrello.Models;
using Xunit;

namespace EaseTrello.UnitTests
{
    public class StringExtensionTests
    {
        [Fact]
        public void AddTrelloIdentity_ClientGrand_ReturnsCorrectResult()
        {
            // arrange
            var expected = "?key=[apiKey]&token=[token]";

            // act
            var result = "?".AddTrelloIdentity(new ClientGrand("[apiKey]", "[token]"));

            // assert
            Assert.Equal(expected, result);
        }
    }
}
