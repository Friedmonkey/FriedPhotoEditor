using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeepAI;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Newtonsoft.Json;
using System.Net;

namespace DeepAI
{
    public class Ai
    {
        //    private FileStream ImageToStream(Image img) 
        //    {
        //        FileStream stream = new FileStream("output.jpg", FileMode.Create, FileAccess.Write);

        //        // Save the image to the FileStream
        //        img.Save(stream, ImageFormat.Jpeg);

        //        img 
        //        // Close the FileStream
        //        stream.Close();
        //    }
        //    public void upscale() 
        //    {
        //        DeepAI_API api = new DeepAI_API(apiKey: "quickstart-QUdJIGlzIGNvbWluZy4uLi4K");

        //        StandardApiResponse resp = api.callStandardApi("torch-srgan", new
        //        {
        //            image = File.OpenRead("C:\\path\\to\\your\\file.jpg"),
        //        });
        //        Console.Write(api.objectAsJsonString(resp));
        //    }
        public Image CombineImages(Image image1, Image image2)
        {
            // Replace "quickstart-QUdJIGlzIGNvbWluZy4uLi4K" with your own API key
            DeepAI_API api = new DeepAI_API(apiKey: "quickstart-QUdJIGlzIGNvbWluZy4uLi4K");

            // Call the DALL-E API and get the response
            StandardApiResponse resp = api.callStandardApi("image-alpha-compositing", new
            {
                image1 = image1,
                image2 = image2,
            });

            // Convert the response to a JSON string
            string jsonString = api.objectAsJsonString(resp);

            // Parse the JSON string to get the URL of the resulting image
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            string resultUrl = json.data.url;

            // Download the resulting image from the URL
            using (WebClient client = new WebClient())
            {
                byte[] imageData = client.DownloadData(resultUrl);
                using (MemoryStream stream = new MemoryStream(imageData))
                {
                    // Create an Image object from the downloaded data
                    return Image.FromStream(stream);
                }
            }
        }
    }
}
