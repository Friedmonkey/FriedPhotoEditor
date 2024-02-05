using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using ImageApi;
using System.Drawing.Drawing2D;
using System.Net.Http;

using System.Linq;

//goed gekeurt door hans jasper 13/12/2022 11:40

namespace FriedPhotoEditor
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        //project and layers
        Backend api = new Backend();
        List<Backend.Layer> layers = new List<Backend.Layer>();
        public bool ading;

        //current selected colour as button
        Button CurrentColour;

        //drawing
        private Color _penColour = Color.Black;
        private int _penSize = 5;
        private bool pipetMode = false;
        private bool colormapMode = false;
        private bool Stretch = false;

        //stamps
        private Bitmap Cursr;
        private int size = 100;


        //Version Control
        private bool Swapping;
        private int CurrentVersion = 0;
        private List<Backend.ProjectFile> Versions = new List<Backend.ProjectFile>();
        private void Form1_Load(object sender, EventArgs e)
        {
            //standart pen
            _penColour = Color.White;
            UnselectColour();
            bttnPipetColour.Enabled = false;

            CurrentColour = bttnPipetColour;

            _penSize = 5;
            UnselectSize();
            button10.Enabled = false;

            this.MouseWheel += Form1_MouseWheel;

            #region new empty layer
            //make new empty bitmap
            Bitmap bmp = new Bitmap(picbxEdit.Width, picbxEdit.Height, PixelFormat.Format32bppArgb);
            bmp.MakeTransparent();
            //new layer
            Backend.Layer lay = new Backend.Layer()
            {
                image = bmp,
                name = "Start Layer",
                Visible = true
            };
            //add the layer and refresh
            int loc = 0;
            ading = true;
            lstbxLayers.Items.Add((lstbxLayers.Items.Count + ".New Layer"), true);
            ading = false;
            layers.Insert(loc, lay);
            RefreshImage();
            lstbxLayers.SelectedIndex = loc;
            #endregion
        }

        //Handle Files, open img save img, open project, save project, and new project
        #region -----------File Handeling-------------

        #region -----------Usefull Functions----------
        //save to a project function
        private Backend.ProjectFile SaveProject() 
        {
            //for a project all we need are the layers 🤷‍
            Backend.ProjectFile project = new Backend.ProjectFile()
            {
                Layers = api.EncodeLayers(layers)
            };
            return project;
        }
        //load a project function
        private void LoadProject(Backend.ProjectFile project) 
        {
            //clear all
            layers.Clear();
            lstbxLayers.Items.Clear();
            picbxEdit.Image = null;

            //add all
            layers = api.DecodeLayers(project.Layers);
            ading = true;
            for (int i = 0; i < layers.Count; i++)
            {
                Backend.Layer layer = layers[i];
                lstbxLayers.Items.Add(i + "." + layer.name, layer.Visible);
            }
            ading = false;
            RefreshImage();
        }
        #endregion

        //open image  and put on a layer
        private void bttnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK) 
            {
                Bitmap smal = (Bitmap)Image.FromFile(ofd.FileName);
                Bitmap img;

                if (!Stretch)
                {
                    // Create a new bitmap with the dimensions of the control
                    img = new Bitmap(picbxEdit.Width, picbxEdit.Height);

                    // Calculate the ratio between the dimensions of the control and the image
                    var panel_ratio = picbxEdit.Width / (float)picbxEdit.Height;
                    var image_ratio = smal.Width / (float)smal.Height;

                    int width, height;

                    // Resize the image to fit within the control while preserving the aspect ratio
                    if (panel_ratio > image_ratio)
                    {
                        // The control is wider than the image, so we will fit the image to the height of the control
                        height = picbxEdit.Height;
                        width = (int)(image_ratio * height);
                    }
                    else
                    {
                        // The control is taller than the image, so we will fit the image to the width of the control
                        width = picbxEdit.Width;
                        height = (int)(width / image_ratio);
                    }

                    // Draw the resized image at the center of the control
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.DrawImage(smal, (picbxEdit.Width - width) / 2, (picbxEdit.Height - height) / 2, width, height);
                    }
                }
                else 
                {
                    img = new Bitmap(smal, picbxEdit.Width, picbxEdit.Height);

                }


                //if we have no layers
                if (layers.Count == 0)
                #region no layers
                {
                    addVersion("Add Image");

                    Backend.Layer lay = new Backend.Layer()
                    {
                        image = img,
                        name = "Background",
                        Visible = true


                    };
                    ading = true;
                    lstbxLayers.Items.Add("0.Background", true);
                    ading = false;
                    layers.Add(lay);
                }
                #endregion
                else
                {
                    //check weather we update a selected image
                    if (lstbxLayers.SelectedItem != null)
                    {
                        addVersion("Set Image");

                        Backend.Layer lay = layers[lstbxLayers.SelectedIndex];
                        layers[lstbxLayers.SelectedIndex] = new Backend.Layer()
                        {
                            image = img,
                            name = lay.name,
                            Visible = lay.Visible
                        };
                    }
                    //or add a new layer for the image
                    else
                    {
                        addVersion("Open image");

                        Backend.Layer lay = new Backend.Layer()
                        {
                            image = img,
                            name = "Opened Layer",
                            Visible = true


                        };
                        ading = true;
                        lstbxLayers.Items.Add("0.Opened Layer", true);
                        ading = false;
                        layers.Add(lay);
                    }
                }
                RefreshImage();
                lstbxLayers.SelectedIndex = 0;
            }
        }

        private void bttnOpenImageStrechted_Click(object sender, EventArgs e)
        {
            Stretch = true;
            bttnOpenImage_Click(sender, e);
            Stretch = false;
        }

        //save the image
        private void bttnSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //picbxEdit.Image.Save(sfd.FileName);
                compileImage().Save(sfd.FileName);
            }

        }

        //reset everything to make a new project
        private void bttnNew_Click(object sender, EventArgs e)
        {
            addVersion("New project");

            layers.Clear();
            lstbxLayers.Items.Clear();
            picbxEdit.Image = null;

            //make new empty bitmap
            Bitmap bmp = new Bitmap(picbxEdit.Width, picbxEdit.Height, PixelFormat.Format32bppArgb);
            bmp.MakeTransparent();

            //make new empty layer
            Backend.Layer lay = new Backend.Layer()
            {
                image = bmp,
                name = "Start Layer",
                Visible = true
            };

            //again this code is probaly not needed 🤣🤣🤣🤣🤣🤣🤣🤣🤣🤣🤣
            ading = true;
            lstbxLayers.Items.Add((lstbxLayers.Items.Count + ".New Layer"), true);
            ading = false;

            //cus we load all items in the refresh image function
            layers.Insert(0, lay);
            RefreshImage();
            lstbxLayers.SelectedIndex = 0;
        }

        //open a project button
        private void bttnOpenProject_Click(object sender, EventArgs e)
        {
            Backend.ProjectFile project = api.GetProject();
            if (project == null)
                return;
            LoadProject(project);
        }
        //load a project button
        private void bttnSaveProject_Click(object sender, EventArgs e)
        {
            api.SaveProject(SaveProject());
        }
        #endregion

        //use api, remove background
        #region-----------------Api------------------
        //remove the background using api
        private void bttnRemoveBG_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null) 
            {
                //get the name and attempt to remove the background
                string name = lstbxLayers.SelectedItem.ToString();
                Image newIMG = api.RemoveBackground(layers[lstbxLayers.SelectedIndex].image,name);

                //if the image hasnt changed
                if (newIMG == layers[lstbxLayers.SelectedIndex].image)
                {
                    MessageBox.Show("Something went wrong :(");
                }
                else 
                {
                    //only add version if something actually changes
                    addVersion("Remove BG");

                    layers[lstbxLayers.SelectedIndex].image = (Bitmap)Image.FromFile(name + "-no-bg.png");
                    //File.Delete("no-bg.png");
                    RefreshImage();
                }
            }
        }

        #region-----------Not working Api------------

        //Ai ai = new Ai();
        private void bttnUpscale_Click(object sender, EventArgs e)
        {
            //ai.upscale();
        }
        private void bttnCombineImages_Click(object sender, EventArgs e)
        {
            //if (lstbxLayers.SelectedItem != null)
            //{
            //    Bitmap Image1 = new Bitmap(layers[lstbxLayers.SelectedIndex].image);
            //    Bitmap Image2 = null;
            //    int Image2Index = 0;
            //    for (int i = 0; i < layers.Count; i++)
            //    {
            //        var layer = layers[i];
            //        if (layer.name == "Image2")
            //        {
            //            Image2 = new Bitmap(layer.image);
            //            Image2Index = i;
            //            break;
            //        }
            //    }
            //    if (Image2 == null)
            //    {
            //        MessageBox.Show("No Second Image Layer found, Click add new layer, rename the layer to \"Image2\" and then click on open image and set the second image to any image");
            //        return;
            //    }
            //    Image retImage = ai.CombineImages((Image)Image1, (Image)Image2);
            //    Bitmap result = new Bitmap(retImage);
            //    layers[lstbxLayers.SelectedIndex].image = result;
            //    layers.RemoveAt(Image2Index);
            //    RefreshImage();

            //}
            //else
            //{
            //    MessageBox.Show("No Layer selected to impaint!");
            //}
        }
        private async Task<Bitmap> RemoveObject(Bitmap Photo,Bitmap Mask) 
        {
            // Set up the HTTP client and request headers
            //old api
            string apiKey = "0bb3ea8bc7cabd788abae4d02b458d83d04674f894d813cf4bf564116de682f1779d00a53d44b512e95fcff7f33d9e77";
            //new api
            apiKey = "0c6224f0ea5f950a457bb76d11c9a691c325c7d5";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);

            // Create a new FormDataContent object to hold the image and mask files
            var form = new MultipartFormDataContent();

            // Save the Photo Bitmap to a MemoryStream
            using (MemoryStream stream = new MemoryStream())
            {
                Photo.Save(stream, ImageFormat.Jpeg);
                stream.Position = 0;

                // Add the image data to the form as a ByteArrayContent object
                form.Add(new ByteArrayContent(stream.ToArray()), "image_file", "photo.jpg");
            }

            // Save the Mask Bitmap to a MemoryStream
            using (MemoryStream stream = new MemoryStream())
            {
                Mask.Save(stream, ImageFormat.Png);
                stream.Position = 0;

                // Add the image data to the form as a ByteArrayContent object
                form.Add(new ByteArrayContent(stream.ToArray()), "mask_file", "mask.png");
            }
            // Send the POST request to the API
            HttpResponseMessage response = await client.PostAsync("https://clipdrop-api.co/cleanup/v1", form);



            Bitmap bmp = new Bitmap(picbxEdit.Width, picbxEdit.Height, PixelFormat.Format32bppArgb);

            // Set the Bitmap's transparency key to full transparency
            bmp.MakeTransparent();

            // Check the response status code
            if (response.IsSuccessStatusCode)
            {
                // Get the binary image data from the response
                byte[] imageData = await response.Content.ReadAsByteArrayAsync();

                // Save the image data to a MemoryStream
                using (MemoryStream stream = new MemoryStream(imageData))
                {
                    // Load the image from the MemoryStream into a Bitmap object
                    Bitmap image = new Bitmap(stream);

                    bmp = new Bitmap(image);
                    // Do something with the image here (e.g. save it to a file)
                }
            }
            else
            {
                // Handle the error here
            }
            return bmp;
        }
        private async void bttnObjectRemoval_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null)
            {
                Bitmap Photo = new Bitmap(layers[lstbxLayers.SelectedIndex].image);
                Bitmap Mask = null;
                int MaskIndex = 0;
                for (int i = 0; i < layers.Count; i++)
                {
                    var layer = layers[i];
                    if (layer.name == "Mask") 
                    {
                        Mask = new Bitmap(layer.image);
                        MaskIndex = i;
                        break;
                    }
                }
                if (Mask == null) 
                {
                    MessageBox.Show("No Mask Layer found, Click add new layer, rename the layer to \"Mask\" and then use any colour to fill in everything that you want to KEEP");
                    return;
                }
                Bitmap result = await RemoveObject(Photo,Mask);
                layers[lstbxLayers.SelectedIndex].image = result;
                layers.RemoveAt(MaskIndex);
                RefreshImage();

            }
            else 
            {
                MessageBox.Show("No Layer selected to impaint!");
            }
            //// Set up the HTTP client and request headers
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("x-api-key", YOUR_API_KEY);

            //// Create a new FormDataContent object to hold the image and mask files
            //var form = new MultipartFormDataContent();
            //form.Add(new ByteArrayContent(photo), "image_file", "photo.jpg");
            //form.Add(new ByteArrayContent(mask), "mask_file", "mask.png");

            //// Send the POST request to the API
            //HttpResponseMessage response = await client.PostAsync("https://clipdrop-api.co/cleanup/v1", form);

            //// Check the response status code
            //if (response.IsSuccessStatusCode)
            //{
            //    // Get the binary image data from the response
            //    byte[] imageData = await response.Content.ReadAsByteArrayAsync();

            //    // Save the image data to a MemoryStream
            //    using (MemoryStream stream = new MemoryStream(imageData))
            //    {
            //        // Load the image from the MemoryStream into a Bitmap object
            //        Bitmap image = new Bitmap(stream);

            //        // Do something with the image here (e.g. save it to a file)
            //    }
            //}
            //else
            //{
            //    // Handle the error here
            //}
        }
        #endregion
        #endregion

        //handle the layers, create layer, delete layer, duplicate layer, show/hide layer, combine layer, move up/down layer and rename layer
        #region -----------Layer Handeling------------
        //Combine 2 Layers into 1 Layer
        private void bttnCombine_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null)
            {
                if (lstbxLayers.Items.Count > lstbxLayers.SelectedIndex+1)
                {
                    #region init variables and checked for data loss
                    int indx = lstbxLayers.SelectedIndex;
                    Backend.Layer LayerTop = layers[lstbxLayers.SelectedIndex];
                    Backend.Layer LayerBottom = layers[lstbxLayers.SelectedIndex+1];
                    if (!LayerTop.Visible || !LayerBottom.Visible) 
                    {
                        DialogResult dr = MessageBox.Show("Some Layers were invisible, if you combine an invisale layer you will loose the image, Either make all layers visible or cancel or continue anyways,Want to make all layers visible and combine?", "Image will be lost", MessageBoxButtons.YesNoCancel);

                        if (dr == DialogResult.Cancel)
                            return;
                        if (dr == DialogResult.Yes) 
                        {
                            LayerTop.Visible = true;
                            LayerBottom.Visible = true;
                        }
                    }
                    #endregion

                    addVersion("Layers combined");

                    //make new empty bitmap
                    Bitmap bmp = new Bitmap(picbxEdit.Width, picbxEdit.Height, PixelFormat.Format32bppArgb);
                    bmp.MakeTransparent();

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        RectangleF f = new RectangleF(0, 0, picbxEdit.Width, picbxEdit.Height);
                        g.CompositingMode = CompositingMode.SourceOver;

                        //draw the layers if visible
                        if (LayerBottom.Visible)
                            g.DrawImage(LayerBottom.image, f);
                        if (LayerTop.Visible)
                            g.DrawImage(LayerTop.image, f);
                    }

                    //update the layer
                    layers[lstbxLayers.SelectedIndex].image = bmp;
                    //remove old layer
                    layers.RemoveAt(lstbxLayers.SelectedIndex+1);

                    RefreshImage();
                    lstbxLayers.SelectedIndex = indx;
                }
                else 
                {
                    MessageBox.Show("No layer to add to!");
                }
            }

        }

        //duplicate a layer
        private void bttnDuplicate_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null)
            {
                addVersion("layer Duplicated");

                Backend.Layer layr = new Backend.Layer() 
                {
                    image = layers[lstbxLayers.SelectedIndex].image,
                    name = layers[lstbxLayers.SelectedIndex].name+"2",
                    Visible = layers[lstbxLayers.SelectedIndex].Visible
                };

                ading = true;
                lstbxLayers.Items.Add(lstbxLayers.Items.Count + ".Duplicated Layer", layr.Visible);
                ading = false;

                layers.Add(layr);
                RefreshImage();
                lstbxLayers.SelectedIndex = lstbxLayers.Items.Count - 1;
            }
        }

        //hide currently selected layer
        private void bttnHideLayer_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null)
            {
                ading = true;
                lstbxLayers.SetItemChecked(lstbxLayers.SelectedIndex,false);
                layers[lstbxLayers.SelectedIndex].Visible = false;
                ading = false;
                picbxEdit.Image = compileImage();
            }
        }
        //show currently selected layer
        private void bttnShowLayer_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null)
            {
                ading = true;
                lstbxLayers.SetItemChecked(lstbxLayers.SelectedIndex, true);
                layers[lstbxLayers.SelectedIndex].Visible = true;
                ading = false;
                picbxEdit.Image = compileImage();
            }
        }

        //when we change the checked state of a layer (visible or hidden)
        private void lstbxLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //weird crash bug fix
            if(!ading)
            {

                if (lstbxLayers.SelectedItem != null)
                {

                    int oldindex = lstbxLayers.SelectedIndex;

                    //add a version if the layer got checked or not
                    addVersion("Layer "+(!lstbxLayers.GetItemChecked(lstbxLayers.SelectedIndex)).ToString());
                    //create a new layer

                    //i dont think we need to do it like this, my code sucks
                    Backend.Layer lay = layers[lstbxLayers.SelectedIndex];
                    layers[lstbxLayers.SelectedIndex] = new Backend.Layer()
                    {
                        image = lay.image,
                        name = lay.name,
                        Visible = !lstbxLayers.GetItemChecked(lstbxLayers.SelectedIndex)
                    };

                    //anyways refresh all
                    RefreshImage();
                    lstbxLayers.SelectedIndex = oldindex;
                }
            }
        }

        //create a layer
        private void bttnNewLayer_Click(object sender, EventArgs e)
        {
            addVersion("new layer");

            //make new empty bitmap
            Bitmap bmp = new Bitmap(picbxEdit.Width, picbxEdit.Height, PixelFormat.Format32bppArgb);

            // Set the Bitmap's transparency key to full transparency
            bmp.MakeTransparent();

            //make new empty layer
            Backend.Layer lay = new Backend.Layer()
            {
                image = bmp,
                name = "New Layer",
                Visible = true
            };
            //standardly add the layer to the topmost
            int loc = 0;
            //if we have a layer selected, add the layer 1 above the selected layer
            if (lstbxLayers.SelectedItem != null) 
            {
                loc = lstbxLayers.SelectedIndex;
            }

            //add the layer in genereal
            //now that i think about it, this is probally not needed
            ading = true;
            lstbxLayers.Items.Add((lstbxLayers.Items.Count + ".New Layer"),true);
            ading = false;

            //insert the layer into the correct position
            layers.Insert(loc,lay);

            //refresh all layers and images
            RefreshImage();

            //select the newly added layer
            lstbxLayers.SelectedIndex = loc;

        }

        //move the selected layer up
        private void bttnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null) 
            {

                int index = lstbxLayers.SelectedIndex; // The index of the layer to move.
                //if we can move up
                if (index > 0 && index < layers.Count)
                {
                    addVersion("Layer up");
                    // Move the second layer down.
                    Backend.Layer layer = layers[index]; // The layer to move.
                    layers.RemoveAt(index); // Remove the layer from its current position.
                    layers.Insert(index - 1, layer); // Insert the layer into its new position.
                    RefreshImage();
                    lstbxLayers.SelectedIndex = index - 1;
                }
            }

        }

        //move the selected layer down
        private void bttnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null)
            {

                int index = lstbxLayers.SelectedIndex; // The index of the layer to move.
                //if we can move down
                if (index >= 0 && index < layers.Count - 1)
                {
                    addVersion("Layer down");
                    // Move the second layer down.
                    Backend.Layer layer = layers[index]; // The layer to move.
                    layers.RemoveAt(index); // Remove the layer from its current position.
                    layers.Insert(index + 1, layer); // Insert the layer into its new position.
                    RefreshImage();
                    lstbxLayers.SelectedIndex = index + 1;
                }
            }

        }

        //Used for renaming
        private void lstbxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null)
            {
                txtbxName.Text = layers[lstbxLayers.SelectedIndex].name;
                //this.Text = lstbxLayers.SelectedIndex+"";
            }
            else 
            {
                txtbxName.Text = "";
            }
        }

        //rename a layer        
        private void txtbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                // Enter or Return key was pressed
                if (lstbxLayers.SelectedItem != null)
                {
                    addVersion("Rename layer");
                    layers[lstbxLayers.SelectedIndex].name = txtbxName.Text;
                    RefreshImage();
                }
            }
        }

        //delete a layer
        private void bttnDelete_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null)
            {
                addVersion("Delete layer");

                layers.RemoveAt(lstbxLayers.SelectedIndex);
                RefreshImage();
            }
        }

        #endregion

        //handle the final picturebox image, refresh and compile and import colour map
        #region -----------Image Handeling------------
        //import the colour map to pick any colour using the colourpicker
        private void bttnColorMap_Click(object sender, EventArgs e)
        {
            string EncodedColorMap = "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";
            picbxEdit.Image = api.Decode(EncodedColorMap);
            pipetMode = true;
            colormapMode = true;
        }

        //refresh the page, by reloading all layers
        private void RefreshImage()
        {
            //clear the listbox
            lstbxLayers.Items.Clear();
            //for each layer just add the layer back
            for (int i = 0; i < layers.Count; i++)
            {
                Backend.Layer layer = layers[i];
                ading = true;
                lstbxLayers.Items.Add(i + "." + layer.name, layer.Visible);
                ading = false;

            }
            picbxEdit.Image = compileImage();
        }

        //combine all visible layers to an image
        public Image compileImage() 
        {
            //create a new clear bitmap
            Bitmap bmp = new Bitmap(picbxEdit.Width, picbxEdit.Height, PixelFormat.Format32bppArgb);

            // Set the Bitmap's transparency key to full transparency
            bmp.MakeTransparent();

            using (Graphics g = Graphics.FromImage(bmp))
            {
                //reverse the order of the layers, because whatever it on top in the listbox
                //should be on top of all the images, and should be drawn last
                layers.Reverse();
                foreach (var layer in layers)
                {
                    //only add the image if it is visible
                    if (layer.Visible)
                    {
                        RectangleF f = new RectangleF(0, 0, picbxEdit.Width, picbxEdit.Height);
                        g.CompositingMode = CompositingMode.SourceOver;
                        g.DrawImage(layer.image, f);
                    }
                }
                layers.Reverse();
                //of cource put it back

                return (Image)bmp;
            }
        }
        #endregion

        //handle the version to go forward backward, or add a new version
        #region ----------Version Handeling-----------
        //go back a version
        private void bttnUndo_Click_1(object sender, EventArgs e)
        {
            //if there is a version to go to
            if (CurrentVersion > 0)
            {
                //when unddo, it is nice to keep the same layer selected
                int oldidx = 0;
                if (lstbxLayers.SelectedItem != null)
                {
                    oldidx = lstbxLayers.SelectedIndex;
                }

                //if we are going back, save the current version also
                if (CurrentVersion == Versions.Count)
                {
                    addVersion("Newest");
                    //we want to atcually go back
                    CurrentVersion--;
                }
                Swapping = true;
                //go back one version
                LoadProject(Versions[CurrentVersion - 1]);
                Swapping = false;
                CurrentVersion--;
                lblVersion.Text = CurrentVersion + "";
                //if  we went back while we selected a layer that we created a version further
                if (oldidx <= lstbxLayers.Items.Count)
                {
                    try
                    {
                        lstbxLayers.SelectedIndex = oldidx;
                    }
                    catch { }
                }
            }
        }

        //go forward a version if possible
        private void bttnRedo_Click_1(object sender, EventArgs e)
        {
            //if there is a version to go to
            if (Versions.Count - 1 > CurrentVersion)
            {
                Swapping = true;
                //load older version
                LoadProject(Versions[CurrentVersion + 1]);
                Swapping = false;
                CurrentVersion++;
                lblVersion.Text = CurrentVersion + "";

            }
        }

        //ad a new version, use this BEFORE doing anyhing
        public void addVersion(string Description = "Version") 
        {
            if (!Swapping) 
            {
                //if we are in older version
                if (CurrentVersion < Versions.Count) 
                {
                    //start from back, so the index does not change
                    for (int i = lstbxVersions.Items.Count - 1; i >= CurrentVersion; i--)
                    {
                        lstbxVersions.Items.RemoveAt(i);
                    }
                    Versions.RemoveRange(CurrentVersion,Versions.Count - CurrentVersion);
                    CurrentVersion = Versions.Count;
                }
                // if we are not swapping add new version
                Backend.ProjectFile project = SaveProject();
                Versions.Add(project);
                CurrentVersion++;
                lstbxVersions.Items.Add(CurrentVersion+" "+ Description);
                lblVersion.Text = CurrentVersion + "";

            }
        }

        #endregion

        //handle drawing actual stuff onto the picturebox/canvas
        //pen colour and pensize, Draw onto screen, Stamp place and resize
        //and all mouse events, click, mousedown, mouseup, mousemove, mousescroll
        #region ------------Draw Handeling------------

        private void SetPipette(MouseEventArgs e) 
        {
            Bitmap bmp2 = new Bitmap(picbxEdit.Image);
            try
            {
                if (CurrentColour.Text != "None") 
                {
                    Color col = bmp2.GetPixel(e.X, e.Y);
                    CurrentColour.BackColor = col;
                    CurrentColour.Text = ColorHelper.GetClosestColorName(col);
                }
            }
            catch { }
        }

        //when you select a new colour
        private void bttnColour_Click(object sender, EventArgs e)
        {
            //if we selected a colour
            if ((sender as Button).Tag.ToString() == "color") 
            {
                pipetMode = false;
                if (colormapMode) 
                {
                    colormapMode = false;
                    picbxEdit.Image = compileImage();
                }
            }
            //if we selected pipet
            if ((sender as Button).Tag.ToString() == "pipet")
            {
                (sender as Button).Enabled = false;
                pipetMode = true;
            }
            else 
            {
                CurrentColour = (sender as Button);
                _penColour = (sender as Button).BackColor;
                UnselectColour();
                (sender as Button).Enabled = false;
            }
        }
        //when you select a new size
        private void bttnSize_Click(object sender, EventArgs e)
        {
            _penSize = Convert.ToInt32(((sender as Button).Font.Size - 19) * 5);
            UnselectSize();
            (sender as Button).Enabled = false;
        }
        //when you select nothing
        private void bttnCursor_Click(object sender, EventArgs e)
        {
            _penColour = Color.Empty;
            UnselectColour();
            (sender as Button).Enabled = false;
        }

        //unselect all colours
        private void UnselectColour() 
        {
            bttnWhite.Enabled = true;
            bttnBlack.Enabled = true;
            bttnBlue.Enabled = true;
            bttnGreen.Enabled = true;
            bttnRed.Enabled = true;
            bttnYellow.Enabled = true;
            bttnBrown.Enabled = true;

            bttnPipet.Enabled = true;
            bttnPipetColour.Enabled = true;

            bttnCursor.Enabled = true;
        }
        //unselect all sizes
        private void UnselectSize() 
        {
            button10.Enabled = true;
            button9.Enabled = true;
            button8.Enabled = true;
            button11.Enabled = true;
            button4.Enabled = true;
        }


        //clearly mark the borders of the picturebox/canvas
        private void picbxEdit_Paint(object sender, PaintEventArgs e)
        {
            //draw a border around the picturebox/canvas
            Rectangle borderRectangle = picbxEdit.ClientRectangle;
            ControlPaint.DrawBorder(e.Graphics, borderRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        //clearly see what colour and pensize you have selected
        private void bttnDraw_Paint(object sender, PaintEventArgs e)
        {
            //draw a border around the pen settings if they are clicked

            if (!(sender as Button).Enabled) 
            {
                if ((sender as Button).Name.ToString() == "bttnPipet")
                {
                    Rectangle borderRectangle = (sender as Button).ClientRectangle;
                    ControlPaint.DrawBorder(e.Graphics, borderRectangle, Color.Blue, ButtonBorderStyle.Solid);
                }
                else
                { 
                    Rectangle borderRectangle = (sender as Button).ClientRectangle;
                    ControlPaint.DrawBorder(e.Graphics, borderRectangle, Color.Red, ButtonBorderStyle.Solid);
                }
            }
        }


        //actually drawing to wherever the mouse is
        private void Draw(MouseEventArgs e, bool remove = false)
        {
            if (lstbxLayers.SelectedItem != null)
            {
                //bmp = currect layer image
                Bitmap bmp = new Bitmap(layers[lstbxLayers.SelectedIndex].image);
                #region Draw and erease
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    if (remove)
                    {
                        // Set the compositing mode to SourceCopy to allow drawing over the image
                        g.CompositingMode = CompositingMode.SourceCopy;

                        // Get the location and size of the circle
                        Point pt = e.Location;
                        int x = pt.X;
                        int y = pt.Y;
                        int width = _penSize;
                        int height = _penSize;

                        // Draw a transparent circle over the area you want to remove
                        using (Pen pen = new Pen(Color.FromArgb(0, 0, 0, 0), _penSize))
                        {
                            g.FillEllipse(pen.Brush, x - (width / 2), y - (height / 2), width, height);
                        }
                    }
                    else
                    {
                        //new pen from out colour
                        using (Pen pen = new Pen(_penColour, _penSize))
                        {
                            Point pt = e.Location;
                            int x = pt.X;
                            int y = pt.Y;

                            g.FillEllipse(pen.Brush, x - (_penSize / 2), y - (_penSize / 2), _penSize, _penSize);
                        }
                    }
                }

                #endregion

                //update the image im memory and visually
                layers[lstbxLayers.SelectedIndex].image = bmp;
                picbxEdit.Image = compileImage();
            }
        }

        public static class ColorHelper
        {
            private static readonly Color[] NamedColors = (Color[])typeof(Color).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Public)
                .Where(p => p.PropertyType == typeof(Color)).Select(p => (Color)p.GetValue(null, null)).ToArray();

            public static string GetClosestColorName(Color color)
            {
                Color closestColor = NamedColors.OrderBy(c => GetEuclideanDistance(c, color)).First();
                return closestColor.Name;
            }

            private static double GetEuclideanDistance(Color c1, Color c2)
            {
                int r = c1.R - c2.R;
                int g = c1.G - c2.G;
                int b = c1.B - c2.B;
                return Math.Sqrt(r * r + g * g + b * b);
            }
        }

        //create stamp
        private void bttnStamp_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null)
            {
                addVersion("Resize");

                //the cursor to make
                Bitmap customCursor = layers[lstbxLayers.SelectedIndex].image;

                //bad code again 🤣🤣🤣🤣🤣🤣🤣🤣
                // Set the current cursor to the new cursor
                Cursr = customCursor;

                //resize the bitmap with another really bad calculation
                Bitmap Cursr2 = ResizeBitmap(Cursr, (Cursr.Width / 100) * (size + 30), (Cursr.Height / 100) * (size + 30));
                picbxEdit.Cursor = new Cursor(Cursr2.GetHicon());
            }
        }
        //create stamp and delete current layer
        private void bttnResize_Click(object sender, EventArgs e)
        {
            if (lstbxLayers.SelectedItem != null) 
            {
                addVersion("Resize-Cut");

                //the cursor to make
                Bitmap customCursor = layers[lstbxLayers.SelectedIndex].image;

                //create new empty bitmap
                Bitmap bmp = new Bitmap(picbxEdit.Width, picbxEdit.Height, PixelFormat.Format32bppArgb);
                bmp.MakeTransparent();


                //old code

                // Set the Bitmap's transparency key to full transparency
                //Bitmap bmp = new Bitmap(picbxEdit.Width, picbxEdit.Height);
                //using (Graphics graph = Graphics.FromImage(bmp))
                //{
                //    Rectangle ImageSize = new Rectangle(0, 0, picbxEdit.Width, picbxEdit.Height);
                //    graph.FillRectangle(Brushes.Transparent, ImageSize);
                //}

                //update the image to the empty image
                layers[lstbxLayers.SelectedIndex].image = bmp;
                picbxEdit.Image = compileImage();


                //bad code again 🤣🤣🤣🤣🤣🤣🤣🤣
                // Set the current cursor to the new cursor
                Cursr = customCursor;

                //resize the bitmap with another really bad calculation
                Bitmap Cursr2 = ResizeBitmap(Cursr, (Cursr.Width / 100) * (size + 30), (Cursr.Height / 100) * (size + 30));
                picbxEdit.Cursor = new Cursor(Cursr2.GetHicon());

            }
        }

        //when you scroll the mouse wheel, used for stams
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Cursr != null)
            {
                //always create a new bitmap, otherwise you scaling down and then back up, the quality has gone down too far
                Bitmap Cursr2 = new Bitmap(Cursr.Width, Cursr.Height);
                //scroll up?
                if (e.Delta > 0)
                {
                    size++;
                }
                //scroll down?
                if (e.Delta < 0)
                {
                    size--;
                }
                if ((Cursr.Width > size) && (Cursr.Height > size))
                {
                    Cursr2 = ResizeBitmap(Cursr, (Cursr.Width / 100) * (size+30), (Cursr.Height / 100) * (size+30));
                    //update the cursor as a visual que
                    picbxEdit.Cursor = new Cursor(Cursr2.GetHicon());
                }
            }
        }

        //resize a bitmap
        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            //really bad code 🤣🤣🤣🤣🤣
            try
            {
                Bitmap result = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.DrawImage(bmp, 0, 0, width, height);
                }
                return result;
            }
            catch 
            {
                try
                {
                    Bitmap result = new Bitmap(Math.Abs(width), Math.Abs(height));
                    using (Graphics g = Graphics.FromImage(result))
                    {
                        g.DrawImage(bmp, 0, 0, width, height);
                    }
                    return result;
                }
                catch 
                {
                    return bmp;
                }
            }

        }
        //private Bitmap SizeBitmapProcentage(Bitmap bmp, float procentage)
        //{
        //    Calculate the aspect ratio
        //    float aspectRatio = (float)bmp.Width / (float)bmp.Height;

        //    Determine the new width and height based on the percentage value
        //    int newWidth = (int)(bmp.Width * (size / procentage));
        //    int newHeight = (int)(bmp.Height * (size / procentage));

        //    If the aspect ratio is not preserved, adjust the width or height to maintain the aspect ratio
        //    if ((float)newWidth / (float)newHeight != aspectRatio)
        //    {
        //        if (newWidth > newHeight)
        //        {
        //            newWidth = (int)(newHeight * aspectRatio);
        //        }
        //        else
        //        {
        //            newHeight = (int)(newWidth / aspectRatio);
        //        }
        //    }

        //    Resize the image using the new width and height
        //    Bitmap result = new Bitmap(newWidth, newHeight);
        //    return result;

        //}

        //when you click, mostly for stamps
        private void picbxEdit_MouseClick(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is pressed
            if (e.Button == MouseButtons.Left)
            {
                if (lstbxLayers.SelectedItem != null) 
                {
                    //if stamp
                    //If cursor is NOT null, so if you currently DO have a stamp
                    if (Cursr != null)
                    {
                        addVersion("Picture placed");
                        //current selected image
                        Bitmap bmp = new Bitmap(layers[lstbxLayers.SelectedIndex].image);
                        Bitmap sec = ResizeBitmap(Cursr, (Cursr.Width / 100) * (size + 30), (Cursr.Height / 100) * (size + 30));

                        //add the stamp to the currently selected image
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawImage(sec, e.X - (sec.Width) / 2, e.Y - (sec.Height) / 2);
                        }
                        //update the image
                        layers[lstbxLayers.SelectedIndex].image = bmp;
                        picbxEdit.Image = compileImage();

                        //remove the stamp if you are not holding ctrl
                        if (!ModifierKeys.HasFlag(Keys.Control))
                        {
                            Cursr = new Bitmap(Cursr.Width, Cursr.Height);
                            Cursr = null;
                            size = 100;
                            picbxEdit.Cursor = DefaultCursor;
                        }
                    }
                    
                }
            }
        }

        //when you start clicking (Add new version before drawing)
        private void picbxEdit_MouseDown(object sender, MouseEventArgs e)
        {
            #region colour picking
            // Check if the left mouse button is pressed
            if (pipetMode)
            {
                SetPipette(e);
                return;
            }
            if (e.Button == MouseButtons.Middle)
            {
                SetPipette(e);
                return;
            }
            #endregion
            if (lstbxLayers.SelectedItem != null)
            {
                if (Cursr == null)
                {
                    #region drawing and ereasing + versions
                    if (e.Button == MouseButtons.Left)
                    {
                        if (_penColour != Color.Empty)
                        {
                            addVersion("Start Draw");
                            Draw(e);
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        addVersion("Erease Draw");
                        Draw(e, true);
                    }
                    #endregion
                }
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        //we know it is happening, just not here, version only
                        addVersion("Picture Draw Start");
                    }
                }
            }
            else
            {
                MessageBox.Show("No layer selected");
            }
        }

        //when you are clicking and dragging
        private void picbxEdit_MouseMove(object sender, MouseEventArgs e)
        {
            #region colour pick
            if (pipetMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    try
                    {
                        SetPipette(e);
                    }
                    catch { }
                }
                return;
            }
            if (e.Button == MouseButtons.Middle)
            {
                Bitmap bmp2 = new Bitmap(picbxEdit.Image);
                try
                {
                    SetPipette(e);
                }
                catch { }
                return;
            }
            #endregion
            if (lstbxLayers.SelectedItem != null)
            {
                #region drawing and ereasing
                if (Cursr == null)
                {
                    // Check if the left mouse button is pressed
                    if (e.Button == MouseButtons.Left)
                    {
                        if (_penColour != Color.Empty)
                        {
                            Draw(e);
                        }
                    }
                    //delete
                    else if (e.Button == MouseButtons.Right)
                    {
                        Draw(e, true);
                    }
                }
                #endregion
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        #region Stamp as Cursor
                        Bitmap bmp = new Bitmap(layers[lstbxLayers.SelectedIndex].image);
                        Bitmap sec = ResizeBitmap(Cursr, (Cursr.Width / 100) * (size + 30), (Cursr.Height / 100) * (size + 30));

                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.DrawImage(sec, e.X - (sec.Width) / 2, e.Y - (sec.Height) / 2);
                        }
                        layers[lstbxLayers.SelectedIndex].image = bmp;
                        picbxEdit.Image = compileImage();

                        if (ModifierKeys.HasFlag(Keys.Control))
                        {
                        }
                        else
                        {
                            Cursr = new Bitmap(Cursr.Width, Cursr.Height);
                            Cursr = null;
                            size = 100;
                            picbxEdit.Cursor = DefaultCursor;
                        }
                        #endregion
                    }
                }
            }
        }

        //when you are done clicking
        private void picbxEdit_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                if (pipetMode) 
                {
                    pipetMode = false;
                    UnselectColour();
                    CurrentColour.Enabled = false;
                    _penColour = CurrentColour.BackColor;
                }
            }
            if (e.Button == MouseButtons.Middle)
            {

                pipetMode = false;
                UnselectColour();
                CurrentColour.Enabled = false;
                _penColour = CurrentColour.BackColor;
            }
            if (colormapMode)
            {
                colormapMode = false;
                picbxEdit.Image = compileImage();
            }
        }
        #endregion

    }
}
