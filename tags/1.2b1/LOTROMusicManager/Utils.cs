using System;
using System.Collections.Generic;
using System.Text;

namespace LotroMusicManager
{
    class StringExtensions
    {
        public static String RightOf(String str, String strSep)
        {//====================================================================
            if (strSep.Length > 0) str = str.Substring(str.IndexOf(strSep) + strSep.Length).Trim();
            return str.Trim();
        }
        public static String ConcatList(String strOld, String strNew, String strSep)
        {//--------------------------------------------------------------------
            if (strOld.Length > 0) return strOld + ", " + RightOf(strNew, strSep);
            return RightOf(strNew, strSep);
        }

        public static String ConcatLines(String strOld, String strNew, String strSep)
        {//--------------------------------------------------------------------
            if (strOld.Length > 0) return strOld + "\n" + RightOf(strNew, strSep);
            return RightOf(strNew, strSep);
        }

        public static String ConvertNonDosFile(String str)
        {//====================================================================
            // If we have any dos newlines, use the file as-is
            if (str.IndexOf('\r') != -1) return str;

            // split on unix newlines and join with dos newlines
            Char[]   aLF = {'\n'};
            String[] aLines = str.Split(aLF, StringSplitOptions.None);
            return String.Join(Environment.NewLine, aLines);
        }

    }
}
