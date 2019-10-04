using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nvpet_plagiarius
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.rtbMainOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbMainOutput
            // 
            this.rtbMainOutput.Location = new System.Drawing.Point(12, 12);
            this.rtbMainOutput.Name = "rtbMainOutput";
            this.rtbMainOutput.Size = new System.Drawing.Size(305, 344);
            this.rtbMainOutput.TabIndex = 0;
            this.rtbMainOutput.Text = "";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(691, 368);
            this.Controls.Add(this.rtbMainOutput);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringHelper sh = new StringHelper();
            PorterStemmerUkr stemmer = new PorterStemmerUkr();

            string wholetitty;

            wholetitty = sh.ReplaceJunk(sh.StringGet("C:\\lol.docx"));
            //rtbMainOutput.Text = sh.ReplaceJunk(sh.StringGet("C:\\lol.docx"));
            //rtbMainOutput.Text = sh.ReplaceJunk(rtbMainOutput.Text);
            rtbMainOutput.Text = wholetitty.ToLower();
            //stemmer.TransformingWord
        }
    }
}
