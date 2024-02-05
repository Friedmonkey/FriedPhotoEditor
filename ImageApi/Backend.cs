using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace ImageApi
{
    public class Backend
    {
        public Image RemoveBackground(Image img,string name)
        {
            //enter your api key here!
            #region apikey
            string apiKey = "vmGP4UFGytaj9L7oR2vg5nj8";
            #endregion

            //create a multipart form
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                //set the apikey
                formData.Headers.Add("X-Api-Key", apiKey);

                //convert image to stream, cus we need a stream
                MemoryStream ms = new MemoryStream();
                img.Save(ms,ImageFormat.Png);

                //add the stream as headers
                formData.Add(new ByteArrayContent(ms.ToArray()), "image_file", "file.jpg");
                formData.Add(new StringContent("auto"), "size");

                //post the form
                var response = client.PostAsync("https://api.remove.bg/v1.0/removebg", formData).Result;

                if (response.IsSuccessStatusCode)
                {
                    //if success then write it to an image file for later user (passing the entire image back will cause memory leak i dont know why)
                    FileStream fileStream = new FileStream(name+"-no-bg.png", FileMode.Create, FileAccess.Write, FileShare.None);

                    //copy the online api image to actual file
                    response.Content.CopyToAsync(fileStream).ContinueWith((copyTask) => {fileStream.Close(); });

                    //return null to indicate that there was NO error
                    return null;

                }
                else
                {
                    //return the input image to check if it is the same and then throw error
                    Console.WriteLine("Error: " + response.Content.ReadAsStringAsync().Result);
                    return img;
                }
            }
        }
        public ProjectFile GetProject()
        {
            //the stuff we need
            ProjectFile project = new ProjectFile();
            OpenFileDialog ofd = new OpenFileDialog();
            //filter
            ofd.Filter = "FPE file *.fpe|*.fpe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //open and deserialize
                string text = File.ReadAllText(ofd.FileName);
                project = JsonConvert.DeserializeObject<ProjectFile>(text);
                return project;
            }
            return null;
        }
        //save project as file
        public void SaveProject(ProjectFile project)
        {
            //make dialog and filtet
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "FPE file *.fpe|*.fpe";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //save the file and give feedback
                string text = JsonConvert.SerializeObject(project);
                File.WriteAllText(sfd.FileName, text);
                MessageBox.Show("File saved!");
            }
        }

        //encode an image to base64 text
        public string Encode(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);

            byte[] bytes = ms.ToArray();

            string base64 = Convert.ToBase64String(bytes);
            return FriedCompress.FCompress.Compress(base64);
        }
        //decode base64 text to an image

        public Bitmap Decode(string base64)
        {
            string decompressed = FriedCompress.FCompress.Decompress(base64);
            byte[] bytes = Convert.FromBase64String(decompressed);
            MemoryStream ms = new MemoryStream();
            ms.Write(bytes, 0, bytes.Count());
            return (Bitmap)Image.FromStream(ms);
        }

        //encode all the layers
        public List<TextLayer> EncodeLayers(List<Layer> layers) 
        {
            List<TextLayer> txtlayers = new List<TextLayer>();
            foreach (var layer in layers)
            {
                TextLayer layr = new TextLayer();
                layr.image = Encode(layer.image);
                layr.name = layer.name;
                layr.Visible = layer.Visible;
                txtlayers.Add(layr);
            }
            return txtlayers;
        }
        //decode all the layers
        public List<Layer> DecodeLayers(List<TextLayer> txtlayers)
        {
            List<Layer> layers = new List<Layer>();
            foreach (var layer in txtlayers)
            {
                Layer layr = new Layer();
                layr.image = Decode(layer.image);
                layr.name = layer.name;
                layr.Visible = layer.Visible;
                layers.Add(layr);
            }
            return layers;
        }
        //idk json but i think we need to serialize a single object and not a list of objects
        //so this is my workaround
        public class ProjectFile
        {
            public List<TextLayer> Layers {get;set;}
        }
        //a leyer with everything it needs
        public class Layer
        {
            public Bitmap image { get; set; }
            public string name { get; set; }
            public bool Visible { get; set; }
        }
        //a layer but string instead of bitmap for encoding
        public class TextLayer
        {
            public string image { get; set; }
            public string name { get; set; }
            public bool Visible { get; set; }
        }
    }
}
