namespace mdsales
{
    partial class Sales
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            this.label1 = new System.Windows.Forms.Label();
            this.btnMgm = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productDataSet1 = new mdsales.productDataSet();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDataSet = new mdsales.productDataSet();
            this.productTableAdapter = new mdsales.productDataSetTableAdapters.productTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "McDonald Sales";
            // 
            // btnMgm
            // 
            this.btnMgm.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnMgm.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnMgm.ForeColor = System.Drawing.Color.Black;
            this.btnMgm.Location = new System.Drawing.Point(362, 12);
            this.btnMgm.Name = "btnMgm";
            this.btnMgm.Size = new System.Drawing.Size(166, 44);
            this.btnMgm.TabIndex = 1;
            this.btnMgm.Text = "Management";
            this.btnMgm.UseVisualStyleBackColor = false;
            this.btnMgm.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSales
            // 
            this.btnSales.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnSales.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnSales.Location = new System.Drawing.Point(542, 12);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(168, 44);
            this.btnSales.TabIndex = 1;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(655, 355);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataMember = "product";
            this.productBindingSource1.DataSource = this.productDataSet1;
            // 
            // productDataSet1
            // 
            this.productDataSet1.DataSetName = "productDataSet";
            this.productDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "product";
            this.productBindingSource.DataSource = this.productDataSet;
            // 
            // productDataSet
            // 
            this.productDataSet.DataSetName = "productDataSet";
            this.productDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(722, 409);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnMgm);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Sales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMgm;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.PictureBox pictureBox1;
        private productDataSet productDataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private productDataSetTableAdapters.productTableAdapter productTableAdapter;
        private productDataSet productDataSet1;
        private System.Windows.Forms.BindingSource productBindingSource1;
    }
}

