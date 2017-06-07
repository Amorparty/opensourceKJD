using System;
using System.Collections.Generic;
using WSE_Core;

namespace MorphemeParserLib
{
    public static class MorphemeParser
    {
        static string[] filters = { " ", ",", ".", "?", "!", "\r", "\n", "!", "?",
            "[", "]", ",", "<", ">", "{", "}","\"","`" };
        static string[] pf_filters = { "는", "은", "을", "를", "가", "에", "게",
            "에게", "입니다", "합니다" };

        public static List<Morpheme> Parse(string source)
        {
            List<Morpheme> mlist = new List<Morpheme>();
            string[] elems = source.Split(filters, StringSplitOptions.RemoveEmptyEntries);
            foreach (string elem in elems)
            {
                ParseElem(elem, mlist);
            }
            return mlist;
        }
        private static void ParseElem(string elem, List<Morpheme> mlist)
        {
            foreach (string pf_filter in pf_filters)
            {
                if (CheckPostfix(pf_filter, elem))
                {
                    MakeElem(pf_filter, elem, mlist);

                    return;
                }
            }

            RecordElem(elem, mlist);
        }

        private static void RecordElem(string elem, List<Morpheme> mlist)
        {
            foreach (Morpheme mo in mlist)
            {
                if (mo.Name == elem)
                {
                    mo.Count++;
                    return;
                }
            }

            Morpheme mor = new Morpheme(elem, 1);
            mlist.Add(mor);
        }
        private static void MakeElem(string pf_filter, string elem, List<Morpheme> mlist)
        {
            int pos = elem.Length - pf_filter.Length;
            string sub = elem.Substring(0, pos);
            RecordElem(sub, mlist);
        }
        private static bool CheckPostfix(string pf_filter, string elem)
        {
            if (elem.Contains(pf_filter))
            {
                int pos = elem.Length - pf_filter.Length;
                string sub = elem.Substring(pos);
                if (sub == pf_filter)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
