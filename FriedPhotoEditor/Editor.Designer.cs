
namespace FriedPhotoEditor
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picbxEdit = new System.Windows.Forms.PictureBox();
            this.lstbxLayers = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnOpenImageStrechted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnRemoveBG = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnObjectRemoval = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnUpscale = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnCombineImages = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnColorMap = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnStamp = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnResize = new System.Windows.Forms.ToolStripMenuItem();
            this.combineWithLayerBelowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnHideLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnShowLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.bttnNewLayer = new System.Windows.Forms.Button();
            this.bttnMoveUp = new System.Windows.Forms.Button();
            this.bttnMoveDown = new System.Windows.Forms.Button();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.bttnDelete = new System.Windows.Forms.Button();
            this.bttnCursor = new System.Windows.Forms.Button();
            this.bttnBlue = new System.Windows.Forms.Button();
            this.bttnRed = new System.Windows.Forms.Button();
            this.bttnYellow = new System.Windows.Forms.Button();
            this.bttnGreen = new System.Windows.Forms.Button();
            this.bttnPipet = new System.Windows.Forms.Button();
            this.bttnBrown = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.bttnBlack = new System.Windows.Forms.Button();
            this.bttnWhite = new System.Windows.Forms.Button();
            this.lstbxVersions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.bttnCombine = new System.Windows.Forms.Button();
            this.bttnPipetColour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbxEdit)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picbxEdit
            // 
            this.picbxEdit.Location = new System.Drawing.Point(93, 98);
            this.picbxEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picbxEdit.Name = "picbxEdit";
            this.picbxEdit.Size = new System.Drawing.Size(501, 288);
            this.picbxEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbxEdit.TabIndex = 0;
            this.picbxEdit.TabStop = false;
            this.picbxEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.picbxEdit_Paint);
            this.picbxEdit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picbxEdit_MouseClick);
            this.picbxEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picbxEdit_MouseDown);
            this.picbxEdit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbxEdit_MouseMove);
            this.picbxEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picbxEdit_MouseUp);
            // 
            // lstbxLayers
            // 
            this.lstbxLayers.FormattingEnabled = true;
            this.lstbxLayers.Location = new System.Drawing.Point(607, 209);
            this.lstbxLayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstbxLayers.Name = "lstbxLayers";
            this.lstbxLayers.Size = new System.Drawing.Size(177, 123);
            this.lstbxLayers.TabIndex = 1;
            this.lstbxLayers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstbxLayers_ItemCheck);
            this.lstbxLayers.SelectedIndexChanged += new System.EventHandler(this.lstbxLayers_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.actionsToolStripMenuItem1,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnOpenImage,
            this.bttnSaveImage,
            this.bttnOpenProject,
            this.bttnSaveProject,
            this.bttnNew,
            this.bttnOpenImageStrechted});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // bttnOpenImage
            // 
            this.bttnOpenImage.Name = "bttnOpenImage";
            this.bttnOpenImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.bttnOpenImage.Size = new System.Drawing.Size(323, 26);
            this.bttnOpenImage.Text = "Open image";
            this.bttnOpenImage.Click += new System.EventHandler(this.bttnOpenImage_Click);
            // 
            // bttnSaveImage
            // 
            this.bttnSaveImage.Name = "bttnSaveImage";
            this.bttnSaveImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.bttnSaveImage.Size = new System.Drawing.Size(323, 26);
            this.bttnSaveImage.Text = "Save as image";
            this.bttnSaveImage.Click += new System.EventHandler(this.bttnSaveImage_Click);
            // 
            // bttnOpenProject
            // 
            this.bttnOpenProject.Name = "bttnOpenProject";
            this.bttnOpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.bttnOpenProject.Size = new System.Drawing.Size(323, 26);
            this.bttnOpenProject.Text = "Open FPE File";
            this.bttnOpenProject.Click += new System.EventHandler(this.bttnOpenProject_Click);
            // 
            // bttnSaveProject
            // 
            this.bttnSaveProject.Name = "bttnSaveProject";
            this.bttnSaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.bttnSaveProject.Size = new System.Drawing.Size(323, 26);
            this.bttnSaveProject.Text = "Save as FPE File";
            this.bttnSaveProject.Click += new System.EventHandler(this.bttnSaveProject_Click);
            // 
            // bttnNew
            // 
            this.bttnNew.Name = "bttnNew";
            this.bttnNew.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.bttnNew.Size = new System.Drawing.Size(323, 26);
            this.bttnNew.Text = "New";
            this.bttnNew.Click += new System.EventHandler(this.bttnNew_Click);
            // 
            // bttnOpenImageStrechted
            // 
            this.bttnOpenImageStrechted.Name = "bttnOpenImageStrechted";
            this.bttnOpenImageStrechted.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.bttnOpenImageStrechted.Size = new System.Drawing.Size(323, 26);
            this.bttnOpenImageStrechted.Text = "Open Image Stretched";
            this.bttnOpenImageStrechted.Click += new System.EventHandler(this.bttnOpenImageStrechted_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apiToolStripMenuItem,
            this.bttnColorMap,
            this.bttnStamp});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // apiToolStripMenuItem
            // 
            this.apiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnRemoveBG,
            this.bttnObjectRemoval,
            this.bttnUpscale,
            this.bttnCombineImages});
            this.apiToolStripMenuItem.Name = "apiToolStripMenuItem";
            this.apiToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.apiToolStripMenuItem.Text = "Api";
            // 
            // bttnRemoveBG
            // 
            this.bttnRemoveBG.Name = "bttnRemoveBG";
            this.bttnRemoveBG.Size = new System.Drawing.Size(229, 26);
            this.bttnRemoveBG.Text = "Remove Background";
            this.bttnRemoveBG.Click += new System.EventHandler(this.bttnRemoveBG_Click);
            // 
            // bttnObjectRemoval
            // 
            this.bttnObjectRemoval.Name = "bttnObjectRemoval";
            this.bttnObjectRemoval.Size = new System.Drawing.Size(229, 26);
            this.bttnObjectRemoval.Text = "Object Removal";
            this.bttnObjectRemoval.Visible = false;
            this.bttnObjectRemoval.Click += new System.EventHandler(this.bttnObjectRemoval_Click);
            // 
            // bttnUpscale
            // 
            this.bttnUpscale.Name = "bttnUpscale";
            this.bttnUpscale.Size = new System.Drawing.Size(229, 26);
            this.bttnUpscale.Text = "Upscale";
            this.bttnUpscale.Visible = false;
            this.bttnUpscale.Click += new System.EventHandler(this.bttnUpscale_Click);
            // 
            // bttnCombineImages
            // 
            this.bttnCombineImages.Name = "bttnCombineImages";
            this.bttnCombineImages.Size = new System.Drawing.Size(229, 26);
            this.bttnCombineImages.Text = "Combine 2 images";
            this.bttnCombineImages.Visible = false;
            this.bttnCombineImages.Click += new System.EventHandler(this.bttnCombineImages_Click);
            // 
            // bttnColorMap
            // 
            this.bttnColorMap.Name = "bttnColorMap";
            this.bttnColorMap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.bttnColorMap.Size = new System.Drawing.Size(258, 26);
            this.bttnColorMap.Text = "Insert Color map";
            this.bttnColorMap.Click += new System.EventHandler(this.bttnColorMap_Click);
            // 
            // bttnStamp
            // 
            this.bttnStamp.Name = "bttnStamp";
            this.bttnStamp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.bttnStamp.Size = new System.Drawing.Size(258, 26);
            this.bttnStamp.Text = "Stamps";
            this.bttnStamp.Click += new System.EventHandler(this.bttnStamp_Click);
            // 
            // actionsToolStripMenuItem1
            // 
            this.actionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnUndo,
            this.bttnRedo});
            this.actionsToolStripMenuItem1.Name = "actionsToolStripMenuItem1";
            this.actionsToolStripMenuItem1.Size = new System.Drawing.Size(72, 24);
            this.actionsToolStripMenuItem1.Text = "Actions";
            // 
            // bttnUndo
            // 
            this.bttnUndo.Name = "bttnUndo";
            this.bttnUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.bttnUndo.Size = new System.Drawing.Size(179, 26);
            this.bttnUndo.Text = "Undo";
            this.bttnUndo.Click += new System.EventHandler(this.bttnUndo_Click_1);
            // 
            // bttnRedo
            // 
            this.bttnRedo.Name = "bttnRedo";
            this.bttnRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.bttnRedo.Size = new System.Drawing.Size(179, 26);
            this.bttnRedo.Text = "Redo";
            this.bttnRedo.Click += new System.EventHandler(this.bttnRedo_Click_1);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnDuplicate,
            this.bttnResize,
            this.combineWithLayerBelowToolStripMenuItem,
            this.deleteLayerToolStripMenuItem,
            this.newLayerToolStripMenuItem,
            this.bttnHideLayer,
            this.bttnShowLayer});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.actionsToolStripMenuItem.Text = "Layers";
            // 
            // bttnDuplicate
            // 
            this.bttnDuplicate.Name = "bttnDuplicate";
            this.bttnDuplicate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.bttnDuplicate.Size = new System.Drawing.Size(322, 26);
            this.bttnDuplicate.Text = "Duplicate Layer";
            this.bttnDuplicate.Click += new System.EventHandler(this.bttnDuplicate_Click);
            // 
            // bttnResize
            // 
            this.bttnResize.Name = "bttnResize";
            this.bttnResize.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.bttnResize.Size = new System.Drawing.Size(322, 26);
            this.bttnResize.Text = "Resize Layer";
            this.bttnResize.Click += new System.EventHandler(this.bttnResize_Click);
            // 
            // combineWithLayerBelowToolStripMenuItem
            // 
            this.combineWithLayerBelowToolStripMenuItem.Name = "combineWithLayerBelowToolStripMenuItem";
            this.combineWithLayerBelowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.combineWithLayerBelowToolStripMenuItem.Size = new System.Drawing.Size(322, 26);
            this.combineWithLayerBelowToolStripMenuItem.Text = "Combine With Layer Below";
            this.combineWithLayerBelowToolStripMenuItem.Click += new System.EventHandler(this.bttnCombine_Click);
            // 
            // deleteLayerToolStripMenuItem
            // 
            this.deleteLayerToolStripMenuItem.Name = "deleteLayerToolStripMenuItem";
            this.deleteLayerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteLayerToolStripMenuItem.Size = new System.Drawing.Size(322, 26);
            this.deleteLayerToolStripMenuItem.Text = "Delete Layer";
            this.deleteLayerToolStripMenuItem.Click += new System.EventHandler(this.bttnDelete_Click);
            // 
            // newLayerToolStripMenuItem
            // 
            this.newLayerToolStripMenuItem.Name = "newLayerToolStripMenuItem";
            this.newLayerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newLayerToolStripMenuItem.Size = new System.Drawing.Size(322, 26);
            this.newLayerToolStripMenuItem.Text = "New Layer";
            this.newLayerToolStripMenuItem.Click += new System.EventHandler(this.bttnNewLayer_Click);
            // 
            // bttnHideLayer
            // 
            this.bttnHideLayer.Name = "bttnHideLayer";
            this.bttnHideLayer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.bttnHideLayer.Size = new System.Drawing.Size(322, 26);
            this.bttnHideLayer.Text = "Hide Layer";
            this.bttnHideLayer.Click += new System.EventHandler(this.bttnHideLayer_Click);
            // 
            // bttnShowLayer
            // 
            this.bttnShowLayer.Name = "bttnShowLayer";
            this.bttnShowLayer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.bttnShowLayer.Size = new System.Drawing.Size(322, 26);
            this.bttnShowLayer.Text = "Show layer";
            this.bttnShowLayer.Click += new System.EventHandler(this.bttnShowLayer_Click);
            // 
            // bttnNewLayer
            // 
            this.bttnNewLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnNewLayer.Location = new System.Drawing.Point(652, 356);
            this.bttnNewLayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnNewLayer.Name = "bttnNewLayer";
            this.bttnNewLayer.Size = new System.Drawing.Size(41, 31);
            this.bttnNewLayer.TabIndex = 3;
            this.bttnNewLayer.Text = "new";
            this.bttnNewLayer.UseVisualStyleBackColor = true;
            this.bttnNewLayer.Click += new System.EventHandler(this.bttnNewLayer_Click);
            // 
            // bttnMoveUp
            // 
            this.bttnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnMoveUp.Location = new System.Drawing.Point(697, 356);
            this.bttnMoveUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnMoveUp.Name = "bttnMoveUp";
            this.bttnMoveUp.Size = new System.Drawing.Size(41, 31);
            this.bttnMoveUp.TabIndex = 4;
            this.bttnMoveUp.Text = "^";
            this.bttnMoveUp.UseVisualStyleBackColor = true;
            this.bttnMoveUp.Click += new System.EventHandler(this.bttnMoveUp_Click);
            // 
            // bttnMoveDown
            // 
            this.bttnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnMoveDown.Location = new System.Drawing.Point(741, 356);
            this.bttnMoveDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnMoveDown.Name = "bttnMoveDown";
            this.bttnMoveDown.Size = new System.Drawing.Size(41, 31);
            this.bttnMoveDown.TabIndex = 5;
            this.bttnMoveDown.Text = "V";
            this.bttnMoveDown.UseVisualStyleBackColor = true;
            this.bttnMoveDown.Click += new System.EventHandler(this.bttnMoveDown_Click);
            // 
            // txtbxName
            // 
            this.txtbxName.Location = new System.Drawing.Point(605, 180);
            this.txtbxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(177, 22);
            this.txtbxName.TabIndex = 6;
            this.txtbxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxName_KeyDown);
            // 
            // bttnDelete
            // 
            this.bttnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnDelete.Location = new System.Drawing.Point(607, 356);
            this.bttnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnDelete.Name = "bttnDelete";
            this.bttnDelete.Size = new System.Drawing.Size(41, 31);
            this.bttnDelete.TabIndex = 7;
            this.bttnDelete.Text = "del";
            this.bttnDelete.UseVisualStyleBackColor = true;
            this.bttnDelete.Click += new System.EventHandler(this.bttnDelete_Click);
            // 
            // bttnCursor
            // 
            this.bttnCursor.Location = new System.Drawing.Point(24, 393);
            this.bttnCursor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnCursor.Name = "bttnCursor";
            this.bttnCursor.Size = new System.Drawing.Size(63, 52);
            this.bttnCursor.TabIndex = 8;
            this.bttnCursor.Text = "None";
            this.bttnCursor.UseVisualStyleBackColor = true;
            this.bttnCursor.Click += new System.EventHandler(this.bttnCursor_Click);
            this.bttnCursor.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // bttnBlue
            // 
            this.bttnBlue.BackColor = System.Drawing.Color.DodgerBlue;
            this.bttnBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnBlue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bttnBlue.Location = new System.Drawing.Point(380, 391);
            this.bttnBlue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnBlue.Name = "bttnBlue";
            this.bttnBlue.Size = new System.Drawing.Size(63, 52);
            this.bttnBlue.TabIndex = 9;
            this.bttnBlue.Tag = "color";
            this.bttnBlue.Text = "Blue";
            this.bttnBlue.UseVisualStyleBackColor = false;
            this.bttnBlue.Click += new System.EventHandler(this.bttnColour_Click);
            this.bttnBlue.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // bttnRed
            // 
            this.bttnRed.BackColor = System.Drawing.Color.Red;
            this.bttnRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnRed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bttnRed.Location = new System.Drawing.Point(449, 391);
            this.bttnRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnRed.Name = "bttnRed";
            this.bttnRed.Size = new System.Drawing.Size(63, 52);
            this.bttnRed.TabIndex = 10;
            this.bttnRed.Tag = "color";
            this.bttnRed.Text = "Red";
            this.bttnRed.UseVisualStyleBackColor = false;
            this.bttnRed.Click += new System.EventHandler(this.bttnColour_Click);
            this.bttnRed.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // bttnYellow
            // 
            this.bttnYellow.BackColor = System.Drawing.Color.Yellow;
            this.bttnYellow.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnYellow.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bttnYellow.Location = new System.Drawing.Point(587, 391);
            this.bttnYellow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnYellow.Name = "bttnYellow";
            this.bttnYellow.Size = new System.Drawing.Size(63, 52);
            this.bttnYellow.TabIndex = 12;
            this.bttnYellow.Tag = "color";
            this.bttnYellow.Text = "Yellow";
            this.bttnYellow.UseVisualStyleBackColor = false;
            this.bttnYellow.Click += new System.EventHandler(this.bttnColour_Click);
            this.bttnYellow.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // bttnGreen
            // 
            this.bttnGreen.BackColor = System.Drawing.Color.LimeGreen;
            this.bttnGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnGreen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bttnGreen.Location = new System.Drawing.Point(517, 391);
            this.bttnGreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnGreen.Name = "bttnGreen";
            this.bttnGreen.Size = new System.Drawing.Size(63, 52);
            this.bttnGreen.TabIndex = 11;
            this.bttnGreen.Tag = "color";
            this.bttnGreen.Text = "Green";
            this.bttnGreen.UseVisualStyleBackColor = false;
            this.bttnGreen.Click += new System.EventHandler(this.bttnColour_Click);
            this.bttnGreen.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // bttnPipet
            // 
            this.bttnPipet.Location = new System.Drawing.Point(93, 393);
            this.bttnPipet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnPipet.Name = "bttnPipet";
            this.bttnPipet.Size = new System.Drawing.Size(63, 52);
            this.bttnPipet.TabIndex = 14;
            this.bttnPipet.Tag = "pipet";
            this.bttnPipet.Text = "Pipet";
            this.bttnPipet.UseVisualStyleBackColor = true;
            this.bttnPipet.Click += new System.EventHandler(this.bttnColour_Click);
            this.bttnPipet.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // bttnBrown
            // 
            this.bttnBrown.BackColor = System.Drawing.Color.Peru;
            this.bttnBrown.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnBrown.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bttnBrown.Location = new System.Drawing.Point(656, 391);
            this.bttnBrown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnBrown.Name = "bttnBrown";
            this.bttnBrown.Size = new System.Drawing.Size(63, 52);
            this.bttnBrown.TabIndex = 13;
            this.bttnBrown.Tag = "color";
            this.bttnBrown.Text = "Brown";
            this.bttnBrown.UseVisualStyleBackColor = false;
            this.bttnBrown.Click += new System.EventHandler(this.bttnColour_Click);
            this.bttnBrown.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(24, 334);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 52);
            this.button4.TabIndex = 17;
            this.button4.Tag = "size";
            this.button4.Text = "•";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.bttnSize_Click);
            this.button4.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button8.Location = new System.Drawing.Point(24, 214);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(63, 52);
            this.button8.TabIndex = 15;
            this.button8.Tag = "size";
            this.button8.Text = "•";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.bttnSize_Click);
            this.button8.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button9.Location = new System.Drawing.Point(24, 156);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(63, 52);
            this.button9.TabIndex = 16;
            this.button9.Tag = "size";
            this.button9.Text = "•";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.bttnSize_Click);
            this.button9.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button10.Location = new System.Drawing.Point(24, 98);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(63, 52);
            this.button10.TabIndex = 18;
            this.button10.Tag = "size";
            this.button10.Text = "•";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.bttnSize_Click);
            this.button10.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button11.Location = new System.Drawing.Point(24, 272);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(63, 52);
            this.button11.TabIndex = 19;
            this.button11.Tag = "size";
            this.button11.Text = "•";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.bttnSize_Click);
            this.button11.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // bttnBlack
            // 
            this.bttnBlack.BackColor = System.Drawing.Color.Black;
            this.bttnBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnBlack.ForeColor = System.Drawing.Color.White;
            this.bttnBlack.Location = new System.Drawing.Point(311, 391);
            this.bttnBlack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnBlack.Name = "bttnBlack";
            this.bttnBlack.Size = new System.Drawing.Size(63, 52);
            this.bttnBlack.TabIndex = 20;
            this.bttnBlack.Tag = "color";
            this.bttnBlack.Text = "Black";
            this.bttnBlack.UseVisualStyleBackColor = false;
            this.bttnBlack.Click += new System.EventHandler(this.bttnColour_Click);
            this.bttnBlack.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // bttnWhite
            // 
            this.bttnWhite.BackColor = System.Drawing.Color.White;
            this.bttnWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnWhite.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bttnWhite.Location = new System.Drawing.Point(243, 391);
            this.bttnWhite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnWhite.Name = "bttnWhite";
            this.bttnWhite.Size = new System.Drawing.Size(63, 52);
            this.bttnWhite.TabIndex = 21;
            this.bttnWhite.Tag = "color";
            this.bttnWhite.Text = "White";
            this.bttnWhite.UseVisualStyleBackColor = false;
            this.bttnWhite.Click += new System.EventHandler(this.bttnColour_Click);
            this.bttnWhite.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // lstbxVersions
            // 
            this.lstbxVersions.FormattingEnabled = true;
            this.lstbxVersions.ItemHeight = 16;
            this.lstbxVersions.Location = new System.Drawing.Point(635, 78);
            this.lstbxVersions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstbxVersions.Name = "lstbxVersions";
            this.lstbxVersions.Size = new System.Drawing.Size(120, 84);
            this.lstbxVersions.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Versions:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(708, 54);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(16, 17);
            this.lblVersion.TabIndex = 24;
            this.lblVersion.Text = "0";
            // 
            // bttnCombine
            // 
            this.bttnCombine.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnCombine.Location = new System.Drawing.Point(725, 391);
            this.bttnCombine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnCombine.Name = "bttnCombine";
            this.bttnCombine.Size = new System.Drawing.Size(63, 52);
            this.bttnCombine.TabIndex = 26;
            this.bttnCombine.Text = "combine layer V";
            this.bttnCombine.UseVisualStyleBackColor = true;
            this.bttnCombine.Click += new System.EventHandler(this.bttnCombine_Click);
            // 
            // bttnPipetColour
            // 
            this.bttnPipetColour.BackColor = System.Drawing.Color.White;
            this.bttnPipetColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnPipetColour.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bttnPipetColour.Location = new System.Drawing.Point(173, 393);
            this.bttnPipetColour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bttnPipetColour.Name = "bttnPipetColour";
            this.bttnPipetColour.Size = new System.Drawing.Size(63, 52);
            this.bttnPipetColour.TabIndex = 27;
            this.bttnPipetColour.Tag = "color";
            this.bttnPipetColour.Text = "PipetColor";
            this.bttnPipetColour.UseVisualStyleBackColor = false;
            this.bttnPipetColour.Click += new System.EventHandler(this.bttnColour_Click);
            this.bttnPipetColour.Paint += new System.Windows.Forms.PaintEventHandler(this.bttnDraw_Paint);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttnPipetColour);
            this.Controls.Add(this.bttnCombine);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstbxVersions);
            this.Controls.Add(this.bttnWhite);
            this.Controls.Add(this.bttnBlack);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.bttnPipet);
            this.Controls.Add(this.bttnBrown);
            this.Controls.Add(this.bttnYellow);
            this.Controls.Add(this.bttnGreen);
            this.Controls.Add(this.bttnRed);
            this.Controls.Add(this.bttnBlue);
            this.Controls.Add(this.bttnCursor);
            this.Controls.Add(this.bttnDelete);
            this.Controls.Add(this.txtbxName);
            this.Controls.Add(this.bttnMoveDown);
            this.Controls.Add(this.bttnMoveUp);
            this.Controls.Add(this.bttnNewLayer);
            this.Controls.Add(this.lstbxLayers);
            this.Controls.Add(this.picbxEdit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "Editor";
            this.Text = "Fried Photo Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbxEdit)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picbxEdit;
        private System.Windows.Forms.CheckedListBox lstbxLayers;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bttnOpenImage;
        private System.Windows.Forms.ToolStripMenuItem bttnSaveImage;
        private System.Windows.Forms.ToolStripMenuItem bttnOpenProject;
        private System.Windows.Forms.ToolStripMenuItem bttnSaveProject;
        private System.Windows.Forms.ToolStripMenuItem bttnNew;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bttnRemoveBG;
        private System.Windows.Forms.Button bttnNewLayer;
        private System.Windows.Forms.Button bttnMoveUp;
        private System.Windows.Forms.Button bttnMoveDown;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.Button bttnDelete;
        private System.Windows.Forms.ToolStripMenuItem bttnObjectRemoval;
        private System.Windows.Forms.ToolStripMenuItem bttnColorMap;
        private System.Windows.Forms.Button bttnCursor;
        private System.Windows.Forms.Button bttnBlue;
        private System.Windows.Forms.Button bttnRed;
        private System.Windows.Forms.Button bttnYellow;
        private System.Windows.Forms.Button bttnGreen;
        private System.Windows.Forms.Button bttnPipet;
        private System.Windows.Forms.Button bttnBrown;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button bttnBlack;
        private System.Windows.Forms.Button bttnWhite;
        private System.Windows.Forms.ListBox lstbxVersions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ToolStripMenuItem bttnStamp;
        private System.Windows.Forms.Button bttnCombine;
        private System.Windows.Forms.ToolStripMenuItem bttnUpscale;
        private System.Windows.Forms.ToolStripMenuItem bttnCombineImages;
        private System.Windows.Forms.ToolStripMenuItem bttnDuplicate;
        private System.Windows.Forms.ToolStripMenuItem bttnResize;
        private System.Windows.Forms.ToolStripMenuItem combineWithLayerBelowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bttnUndo;
        private System.Windows.Forms.ToolStripMenuItem bttnRedo;
        private System.Windows.Forms.ToolStripMenuItem newLayerToolStripMenuItem;
        private System.Windows.Forms.Button bttnPipetColour;
        private System.Windows.Forms.ToolStripMenuItem bttnHideLayer;
        private System.Windows.Forms.ToolStripMenuItem bttnShowLayer;
        private System.Windows.Forms.ToolStripMenuItem bttnOpenImageStrechted;
    }
}

