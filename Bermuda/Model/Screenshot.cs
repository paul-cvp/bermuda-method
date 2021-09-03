using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    //https://stackoverflow.com/questions/44370046/how-do-i-serialize-object-to-json-using-json-net-which-contains-an-image-propert
    public class ImageConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var base64 = (string)reader.Value;
            // convert base64 to byte array, put that into memory stream and feed to image
            return Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var img = (Image)value;
            var image = new Bitmap(img);
            // save to memory stream in original format
            var ms = new MemoryStream();
            image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = ms.ToArray();
            // write byte array, will be converted to base64 by JSON.NET
            writer.WriteValue(imageBytes);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Image);
        }
    }
    public class Screenshot
    {
        public Guid ScreenshotID { get; set; }
        public string ImagePath { get; set; }

        [JsonConverter(typeof(ImageConverter))]
        public Image ImageData { get; set; }

        public Screenshot()
        {

        }

        public Screenshot(Image image)
        {
            ImageData = image;
            ScreenshotID = new Guid();
        }
        public Screenshot(Image image, string path)
        {
            ImagePath = path;
            ImageData = image;
            ScreenshotID = new Guid();
        }
    }
}
