using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SingularFrameworkCore.Serialization;
using Xunit;

namespace SingularFrameworkCore.Serialization.Newtonsoft.Json.Tests
{
    public class JsonSerializerTests
    {
        private readonly JsonSerializer<Person> _serializer = new JsonSerializer<Person>();

        [Fact]
        public void Serialize_ValidObject_ReturnsCorrectJson()
        {
            // Arrange
            var person = new Person { Name = "John Doe", Age = 30 };

            // Act
            string json = _serializer.Serialize(person);

            // Assert
            JObject jObject = JObject.Parse(json);
            Assert.Equal("John Doe", jObject["Name"]?.ToString());
            Assert.Equal(30, jObject["Age"]?.Value<int>());
        }

        [Fact]
        public void Deserialize_ValidJson_ReturnsCorrectObject()
        {
            // Arrange
            string json = @"{ ""Name"": ""Jane Doe"", ""Age"": 25 }";

            // Act
            Person result = _serializer.Deserialize(json);

            // Assert
            Assert.Equal("Jane Doe", result.Name);
            Assert.Equal(25, result.Age);
        }

        [Fact]
        public void RoundTrip_SerializeAndDeserialize_ReturnsEquivalentObject()
        {
            // Arrange
            var originalPerson = new Person { Name = "Test", Age = 100 };

            // Act
            string json = _serializer.Serialize(originalPerson);
            Person roundTripPerson = _serializer.Deserialize(json);

            // Assert
            Assert.Equal(originalPerson.Name, roundTripPerson.Name);
            Assert.Equal(originalPerson.Age, roundTripPerson.Age);
        }

        [Fact]
        public void Deserialize_InvalidJson_ThrowsJsonReaderException()
        {
            // Arrange
            string invalidJson = "{ Corrupted: JSON }";

            // Act & Assert
            Assert.Throws<JsonReaderException>(() => _serializer.Deserialize(invalidJson));
        }

        [Fact]
        public void Serialize_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            Person nullPerson = null!;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _serializer.Serialize(nullPerson));
        }

        // Test class
        private class Person
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
        }
    }
}
