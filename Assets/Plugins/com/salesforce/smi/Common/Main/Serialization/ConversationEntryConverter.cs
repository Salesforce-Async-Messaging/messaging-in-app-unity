using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Plugins.Salesforce.InApp
{
    public class ConversationEntryConverter : JsonCreationConverter<Payload>
    {
        protected override Payload Create(Type objectType, JObject jObject)
        {
            // XXX: Eventually we would use the type/format values to determine
            // the proper class to return but for this POC we're only handling
            // TextMessages.
            return new TextMessage();
        }
    }

    public abstract class JsonCreationConverter<P> : JsonConverter where P : Payload
    {
        protected abstract P Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(P).IsAssignableFrom(objectType);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                         object existingValue,
                                         JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            P target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}
