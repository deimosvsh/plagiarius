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
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                text.Append(" \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString());
            }

            return text.ToString();
        }
    }
}
