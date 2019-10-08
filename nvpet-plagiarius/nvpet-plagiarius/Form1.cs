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
        public StringHelper sh = new StringHelper();
        public PorterStemmerUkr stemmer = new PorterStemmerUkr();

        public List<string> LsDevided = new List<string> { };

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.rtbMainOutput = new System.Windows.Forms.RichTextBox();
            this.rtbWordsOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbMainOutput
            // 
            this.rtbMainOutput.Location = new System.Drawing.Point(12, 12);
            this.rtbMainOutput.Name = "rtbMainOutput";
            this.rtbMainOutput.Size = new System.Drawing.Size(332, 344);
            this.rtbMainOutput.TabIndex = 0;
            this.rtbMainOutput.Text = "";
            // 
            // rtbWordsOutput
            // 
            this.rtbWordsOutput.Location = new System.Drawing.Point(350, 12);
            this.rtbWordsOutput.Name = "rtbWordsOutput";
            this.rtbWordsOutput.Size = new System.Drawing.Size(329, 344);
            this.rtbWordsOutput.TabIndex = 1;
            this.rtbWordsOutput.Text = "";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(691, 397);
            this.Controls.Add(this.rtbWordsOutput);
            this.Controls.Add(this.rtbMainOutput);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtbMainOutput.Text = sh.ReplaceJunk(sh.StringGet(@"C:\lol.docx")).ToLower();

            LsDevided = sh.DevideBySpace(rtbMainOutput.Text);

            foreach (var i in LsDevided)
                rtbWordsOutput.AppendText(stemmer.TransformingWord(i) + "\n");
        }
    }
}
