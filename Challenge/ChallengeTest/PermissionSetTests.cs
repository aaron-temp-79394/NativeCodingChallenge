using AE.CoreUtility;
using Challenge;
using System;
using System.Linq;
using System.Text;
using Xunit;

namespace ChallengeTest
{
    public class PermissionSetTests
    {
        [Fact]
        public void SerializesCorrectly() {
            // arrange
            var permissions = new PermissionSet();
            var expected = Enumerable.Repeat(new byte(), 100);

            // act
            var actual = permissions.Serialize();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DeSerializesCorrectly() {
            // arrange
            var bytes = Enumerable.Repeat(new byte(), 100).ToArray();
            var expected = new PermissionSet() {
                Permissions = Enumerable.Repeat(new byte(), 100).ToArray()
            };

            // act
            var actual = PermissionSet.Deserialize(bytes);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
