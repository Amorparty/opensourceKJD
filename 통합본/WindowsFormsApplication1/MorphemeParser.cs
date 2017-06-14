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
            "에게", "입니다", "합니다", "하는" };

        

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
        // 특정 단어들 분류해서 레벨 나누기 위함
        public static int lv_count(string tex)
        {
            int lv=0;
            Morpheme mo = new Morpheme();
            if (mo.Name.Contains("소풍"))
            {
                lv = 1;
            }
            if (mo.Name.Contains("여행"))
            {
                lv = 1;
            }
            if (mo.Name.Contains("데이트"))
            {
                lv = 1;
            }
            if (mo.Name.Contains("나들이"))
            {
                lv = 1;
            }
            if (mo.Name.Contains("피크닉"))
            {
                lv = 1;
            }
            if (mo.Name.Contains("야외활동"))
            {
                lv = 1;
            }
            if (mo.Name.Contains("date"))
            {
                lv = 1;
            }
            if (mo.Name.Contains("picnic"))
            {
                lv = 1;
            }
            if (mo.Name.Contains("레저"))
            {
                lv = 2;
            }
            if (mo.Name.Contains("탁구"))
            {
                lv = 2;
            }
            if (mo.Name.Contains("축구"))
            {
                lv = 2;
            }
            if (mo.Name.Contains("농구"))
            {
                lv = 2;
            }
            if (mo.Name.Contains("야구"))
            {
                lv = 2;
            }
            if (mo.Name.Contains("헬스"))
            {
                lv = 2;
            }
            if (mo.Name.Contains("달리기"))
            {
                lv = 2;
            }
            if (mo.Name.Contains("조깅"))
            {
                lv = 2;
            }
            return lv;

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
        // 여행 소풍 등 야외활동 형태소
        private static void SElem(string elem, List<Morpheme> mlist)
        {
            foreach (string out_filter in pf_filters)
            {
                if (CheckPostfix(out_filter, elem))
                {
                    MakeElem(out_filter, elem, mlist);

                    return;
                }
            }
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
