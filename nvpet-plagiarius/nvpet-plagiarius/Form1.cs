using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace nvpet_plagiarius
{
    public struct stOccurances
    {
        public string sWord;
        public int iNumOfOcc;
        public stOccurances(string s, int i)
        { sWord = s; iNumOfOcc = i; }
    }//*/
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
            this.button1 = new System.Windows.Forms.Button();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Form1_Load);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(691, 397);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbWordsOutput);
            this.Controls.Add(this.rtbMainOutput);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //rtb - rich text box
            //int iStartTime = DateTime.Now.Millisecond;
            
            List<string> slistEnroledText = new List<string>();
            //string testing = sh.StringGet(@"C:\tests\РИРИРИРРИ.docx");


            //rtbMainOutput.Text = sh.ReplaceJunk(sh.StringGet(@"C:\lol.docx")).ToLower();
            //rtbMainOutput.Text = sh.ReplaceJunk(sh.StringGet(@"C:\tests\РИРИРИРРИ.docx"));//.ToLower();
            //rtbMainOutput.Text = sh.ReplaceJunk(testing).ToLower();
            rtbMainOutput.Text = sh.ReplaceJunk(sh.StringGetGemBox(@"C:\tests\війна.docx")).ToLower();

            LsDevided = sh.DevideBySpace(rtbMainOutput.Text);

            /*foreach (var i in LsDevided)
            {
                //rtbWordsOutput.AppendText(stemmer.TransformingWord(i) + "\n");
                slistEnroledText.Add(stemmer.TransformingWord(i));
            }//*/

            Parallel.For(0, LsDevided.Count, (i) =>
            {
                slistEnroledText.Add(stemmer.TransformingWord(LsDevided[i]));
            });//*/


            LsDevided = sh.DevideBySpace(rtbMainOutput.Text);
            //MessageBox.Show("Sort start");

            //slistEnroledText.TrimExcess();
            slistEnroledText.Sort();


            //List<stOccurances> loccNumberOfOccurances = sh.CountOccurances(slistEnroledText);

            //List<stOccurances> loccNumberOfOccurances2 = new List<stOccurances>();

            /*foreach (var s in loccNumberOfOccurances)
            {
                if (s.sWord.Length > 3)
                    loccNumberOfOccurances2.Add(s);
            }//*/
            /*string testing = "";

            Parallel.For(0, slistEnroledText.Count, (i) =>
            {
                rtbWordsOutput.AppendText(slistEnroledText[i]);
            });//*/

            /*foreach (var i in slistEnroledText)
            //foreach (var i in loccNumberOfOccurances)
            {
                //rtbWordsOutput.AppendText(i.sWord + " " + i.iNumOfOcc + "\n");
                //rtbWordsOutput.AppendText(i + "\n");
                testing = $"{testing}{i}\n";
                //MessageBox.Show("Sort finish");
            }//*/

            //rtbWordsOutput.AppendText(testing);
            MessageBox.Show("holly cow");
        }
    }
}
