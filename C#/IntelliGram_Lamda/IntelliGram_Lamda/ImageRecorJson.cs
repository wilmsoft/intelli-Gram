// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ImageRecordJson;
//
//    var data = ImageRecordJson.FromJson(jsonString);

namespace ImageRecordJson
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class ImageRecord
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        public override bool Equals(object obj)
        {
            ImageRecord target = obj as ImageRecord;
            if (target.Id != this.Id) return false;
            if (target.Image != this.Image) return false;
            if (target.Title != this.Title) return false;

            return base.Equals(obj);
        }
    }

    public partial class ImageRecord
    {
        public static ImageRecord FromJson(string json) => JsonConvert.DeserializeObject<ImageRecord>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ImageRecord self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
