using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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

        /* Функція отримання вмісту тексту у вигляді одного рядку*/
        public string StringGet(string sSource)
        {
            // Результативна строка, яку повинна повернути функція
            StringBuilder text = new StringBuilder();
            // Створення віртуального екемпляру програми MS Word
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            /* Створення потоку для отримання вмісту документу, 
             * використовується всередині віртуального екземпляру MS Word
             */
            Microsoft.Office.Interop.Word.Document docs = new Microsoft.Office.Interop.Word.Document();
            /* Заповнення необхідних системних параметрів для відкриття документу
             * НЕ ЧІПАТИ
             */
            object miss = System.Reflection.Missing.Value;
            object path = sSource;
            object readOnly = true;

            // Відкриття та завантаження документу
            try
            {
                docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss,
                       ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss,
                       ref miss, ref miss);
            }
            /* TODO: Створити повідомлення про неправильне відкриття документу, 
             * його відсутність або інші помилки самого процесу відкриття
             */
            catch
            {
                //Console.WriteLine("oof");
            }

            // Копіювання документу в строку
            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                text.Append(docs.Paragraphs[i + 1].Range.Text.ToString());
            }

            // Повернення результуючої строки
            return text.ToString();
        }

        public string ReplaceJunk(string sSource)
        {
            /* Словник замінюваних символів;
             * TODO: чи всі символи представлені?
             *       по можливості оптимізувати
             */
            Dictionary<string, string> dReplacements = new Dictionary<string, string>
                {
                    { "0", "" }, { "1", "" }, { "2", "" }, { "3", "" }, { "4", "" },
                    { "5", "" }, { "6", "" }, { "7", "" }, { "8", "" }, { "9", "" },
                    { ".", "" }, { ",", "" }, { "№", "" }, { "“", "" }, { "”", "" },
                    { "(", "" }, { ")", "" }, { ":", "" }, { ";", "" }, { "/", "" },
                    { "<", "" }, { ">", "" }, { "!", "" }, { "?", "" }, { "@", "" },
                    { "#", "" }, { "$", "" }, { "%", "" }, { "^", "" }, { "&", "" },
                    { "*", "" }, { "+", "" }, { "|", "" }, { "_", "" }, { "»", "" },
                    { "«", "" }, { "\\", ""}, { "\"", ""}, { "-", " "}, { "–", " "},
                    {"  ", " "}, {"\n", " "}, {"\t", " "}, {"\r", " "}, {"\f", " "},

                    { "новоград", "" },    { "волинський", "" }, {"промислово", ""},
                    { "економічний", "" }, { "технікум", "" }    
                };

            /* Затирання подвійних пробілів;
             * TODO: треба оптимізувати, занадто часто повторюється, треба зробити ранній вихід
             *       при відсутності подвійних проблів
             */
            foreach (var item in dReplacements)
            {
                sSource = sSource.Replace(item.Key, item.Value);
                //sSource = sSource.Replace("  ", " ");
            }//*/

            // Формування фінального рядку
            return sSource.ToString();
        }

        public bool isCommonWord(string sWord)
        {
            if (sWord == null || sWord.Length == 0)
            {
                return false;
            }
            else
            {
                Regex regex = new Regex("(диплом|дкк|технічна)$", RegexOptions.IgnoreCase);
                return regex.IsMatch(sWord);
            }
        }

        public List<string> DevideBySpace(string sSource)
        {
            // Результуючий масив рядків, кожен заповнений одним словом
            List<string> LsDevided = new List<string> { };

            String[] sAllWords = sSource.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> LsReplacements = new List<string> 
                { "а", "у", "і", "й", "в", "з", "на", "до", "та", "за", "для"};

            foreach (string s in sAllWords)
            {
                 LsDevided.Add(s);
            }

            foreach(string ritem in LsReplacements)
            {
                for(int i = 0; i < LsDevided.Count; i++)
                {
                    if (LsDevided[i] == ritem)
                        LsDevided.Remove(LsDevided[i]);
                    //LsDevided.RemoveAll(isCommonWord);
                }
            }
                
            // повернення масиву слів
            return LsDevided;
        }
    }
}