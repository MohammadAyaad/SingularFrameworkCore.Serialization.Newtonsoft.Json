# SingularFrameworkCore.Serialization.Newtonsoft.Json

A C# library that provides a JSON serializer implementation for the SingularFrameworkCore serialization interface. This library leverages the popular Newtonsoft.Json library to offer robust serialization and deserialization capabilities.

## Features

- **Generic Input Type**: Supports serialization and deserialization of any object type.
- **Newtonsoft.Json**: Utilizes the widely-used Newtonsoft.Json library for JSON operations.
- **Bidirectional Support**: Implements both serialization and deserialization.

## Installation

The package is available on NuGet. To install it, use the following command:

```bash
Install-Package SingularFrameworkCore.Serialization.Newtonsoft.Json
```

Or using the .NET CLI:

```bash
dotnet add package SingularFrameworkCore.Serialization.Newtonsoft.Json
```

## Usage

### Serialization and Deserialization

```csharp
using SingularFrameworkCore.Serialization.Newtonsoft.Json;

// Declare our example model
class MyClass {
    public string Name;
    public int Age;
}

// Create an instance of the JsonSerializer for your specific type
var jsonSerializer = new JsonSerializer<MyClass>();

// Create an object to serialize
var myObject = new MyClass { Name = "John", Age = 30 };

// Serialize the object to a JSON string
string jsonString = jsonSerializer.Serialize(myObject);

// Deserialize the JSON string back to an object
MyClass deserializedObject = jsonSerializer.Deserialize(jsonString);
```

## Integration with SingularFrameworkCore

This library implements the `IEntitySerializer<I, O>` interface from SingularFrameworkCore, making it ideal for use within the Singular pipeline:

```csharp
var singular = new Singular<MyClass, string>(
    repository,
    new JsonSerializer<MyClass>(), // Use the JSON serializer
    preProcessors,
    postProcessors
);
```

## Requirements

- .NET Standard 8.0+
- Newtonsoft.Json

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## Author

Created by Mohammad Ayaad

## Related Projects

- [SingularFrameworkCore](https://github.com/MohammadAyaad/SingularFrameworkCore) - The core framework this implementation is built for
- [Newtonsoft.Json](https://www.newtonsoft.com/json) - The JSON library used for serialization