﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SingularFrameworkCore.Serialization;

namespace SingularFrameworkCore.Serialization.Newtonsoft.Json;

class JsonSerializer<T> : IEntitySerializer<T, string>
{
    public string Serialize(T entity)
    {
        return JObject.FromObject(entity!).ToString();
    }

    public T Deserialize(string json)
    {
        return JObject.Parse(json).ToObject<T>()!;
    }
}
