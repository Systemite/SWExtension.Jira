namespace SWExtension.Jira
{
    partial class TheModuleController
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
            this.components = new System.ComponentModel.Container();
            this.smallImages = new System.Windows.Forms.ImageList(this.components);
            this.largeImages = new System.Windows.Forms.ImageList(this.components);
            // 
            // smallImages
            // 
            this.smallImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.smallImages.ImageSize = new System.Drawing.Size(16, 16);
            this.smallImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // largeImages
            // 
            this.largeImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.largeImages.ImageSize = new System.Drawing.Size(16, 16);
            this.largeImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ModuleController
            // 
            this.LargeImages = this.largeImages;
            this.SmallImages = this.smallImages;

        }

        #endregion

        private System.Windows.Forms.ImageList smallImages;
        private System.Windows.Forms.ImageList largeImages;
    }
}