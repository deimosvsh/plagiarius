using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace nvpet_plagiarius
{
    public class StringHelper
    {
        public StringHelper()
        {
        }

        public StringHelper(string sFilePath)
        {
            StringGet(sFilePath);
        }

        public string ReverseString(string sSource)
        {
            char[] arr = sSource.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public string StringGet(string sSource)
        {
            StringBuilder text = new StringBuilder();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = sSource;
            object readOnly = true;

            Microsoft.Office.Interop.Word.Document docs = new Microsoft.Office.Interop.Word.Document();

           // docs.FormattingShowClear = false;

            try
            {
                 docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            }
            catch
            {
                Console.WriteLine("oof");
            }

            //docs.FormattingShowClear = false;

            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                text.Append(" \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString());
            }

            return text.ToString();
        }

        public string ReplaceJunk(string sSource)
        {
            StringBuilder text = new StringBuilder();

            Dictionary<string, string> replacements = new Dictionary<string, string>
                {
                    { "0", "" },
                    { "1", "" },
                    { "2", "" },
                    { "3", "" },
                    { "4", "" },
                    { "5", "" },
                    { "6", "" },
                    { "7", "" },
                    { "8", "" },
                    { "9", "" },
                    { ".", "" },
                    { ",", "" },
                    { "№", "" },
                    { "“", "" },
                    { "”", "" },
                    { "(", "" },
                    { ")", "" },
                    { ":", "" },
                    { ";", "" },
                    { "/", "" },
                    { "<", "" },
                    { ">", "" },
                    { "!", "" },
                    { "?", "" },
                    { "@", "" },
                    { "#", "" },
                    { "$", "" },
                    { "%", "" },
                    { "^", "" },
                    { "&", "" },
                    { "*", "" },
                    { "+", "" },
                    { "|", "" },
                    { "_", "" },
                    { "»", "" },
                    { "«", "" },
                    { "\\", "" },
                    { "\"", "" },
                    { "-", " " },
                    { "–", " " },
                    { "  ", " " }
                };

            char[] denied = new[] { '\n', '\t', '\r' };
            StringBuilder newString = new StringBuilder();
            foreach (var ch in sSource) 
            {
                for (int i = 0; i < 3; i++)
                {
                    if (sSource[ch] != denied[i])
                    {
                        newString.Append(ch);
                        break;
                    }
                    else
                    {
                        newString.Append(" ");
                        break;
                    }
                }
                    //if (!denied.Contains(ch))
                    
                
            }
            sSource = newString.ToString();
            foreach (var item in replacements)
            {
                sSource = sSource.Replace(item.Key, item.Value);
                sSource = sSource.Replace("  ", " ");
            }

            /*for(int i = 0; i < sSource.Length; i++)
            {
                /*sSource = sSource.Replace(Environment.NewLine, " ");
                sSource = sSource.Replace(@",\r?\n", " ");
                sSource = sSource.Replace(@" \n", " ");
                sSource = sSource.Replace(@" \t", " ");//*/
                /*sSource = sSource.Replace("  ", " ");
                Console.WriteLine(i);
            }//*/
            /*for (int i = 0; i < sSource.Length; i++)
            {
                sSource = sSource.Replace(" \\n", " ");
            }
            //Environment.
            //sSource = sSource.Replace(Environment.NewLine, " ");
            //sSource = sSource.Replace(@",\r?\n", "");//*/


            return sSource.ToString();
        }
    }
}