//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;

//namespace BH.Engine.Environment.SAP.Convert.Enum
//{
//    public static class Convert
//    {
//        public static List<string> ToEnum(string enumFile)
//        {
//            string str1 = "<xs:simpleType name=\"";
//            string str2 = "</xs:simpleType>";
//            string str3 = "<xs:enumeration value=\"";
//            string str4 = ">\r\n\t\t\t\t<xs:annotation>";
//            List<string> info = Find(str1, str2, enumFile);
            

//            List<string> codeList = new List<string>();

//            for (int i = 0; i < info.Count; i ++)
//            {

//            }
//            //Dictionary<string,List<string>> 


            

//            return codeList;
//        }

//        public static List<string> Find(string Start, string End, string Text)
//        {
//            var tempText = Text;
//            List<string> occur = new List<string>();

//            while(tempText != null || tempText.Contains(Start))
//            {
//                var sPos = tempText.IndexOf(Start);
//                var ePos = tempText.IndexOf(End, sPos + Start.Length);

//                string s = "";
//                if (sPos >= 0 || ePos > sPos) 
//                {
//                    s = tempText.Substring(sPos+ Start.Length,ePos - sPos - Start.Length);
//                }
//                tempText = tempText.Substring(ePos+ End.Length, tempText.Length - ePos - End.Length);
//                occur.Add(s);
//            }
//            return occur;
//        }



//    }

//}


