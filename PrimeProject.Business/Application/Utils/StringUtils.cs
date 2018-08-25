using System;
using System.Text;
using System.Text.RegularExpressions;

namespace PrimeProject.Business.Application.Utils
{

    public class StringUtils
    {
        public static string TruncateStringByWord(string txt, int maxLength)
        {
            if (!string.IsNullOrWhiteSpace(txt))
            {
                txt = Regex.Replace(txt, @"<(.|\n)*?>", " ");
                var words = txt.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (txt.Length <= maxLength)
                    return txt;

                var retVal = "";

                foreach (var word in words)
                {
                    if (retVal.Length + word.Length > maxLength)
                    {
                        retVal += "...";
                        break;
                    }

                    if (!string.IsNullOrEmpty(retVal))
                    {
                        retVal += " ";
                    }

                    retVal = retVal + word;
                }

                return retVal.TrimEnd();
            }

            return txt;
        }

        public static String GenerateFullExceptionTraceXml(String message, String stacktrace = null)
        {
            return String.Format("<Exception><Message>{0}</Message><StackTrace>{1}</StackTrace></Exception>", message, stacktrace);
        }

        public static String GenerateFullExceptionTraceXml(Exception e)
        {
            if (e.InnerException == null)
            {
                return String.Format("<Exception><Message>{0}</Message><StackTrace>{1}</StackTrace></Exception>", e.Message, e.StackTrace);
            }

            return String.Format("<Exception><Message>{0}</Message><StackTrace>{1}</StackTrace></Exception>{2}", e.Message, e.StackTrace, GenerateFullExceptionTraceXml(e.InnerException));
        }

        public static String GenerateHtmlFromExceptionXml(String errorXml)
        {
            StringBuilder sBuilder = new StringBuilder();

            var mc = Regex.Matches(errorXml, @"<Message>([.\s\S]*?)</Message><StackTrace>([.\s\S]*?)</StackTrace>",
                RegexOptions.Multiline);
            if (mc.Count > 0)
            {
                foreach (Match m in mc)
                {
                    String exceptionMessage = m.Groups[1].Value;
                    String exceptionStackTrace = m.Groups[2].Value;

                    sBuilder.Append(String.Format("<h3>{0}</h3>", exceptionMessage));

                    var mc2 = Regex.Matches(exceptionStackTrace, "(.*)?\n");
                    foreach (Match m2 in mc2)
                    {
                        String exceptionLine = String.Format("\n<p>{0}</p>", m2.Groups[1].Value);

                        Match lineNoMatch = Regex.Match(exceptionLine, "line [0-9]*");
                        if (lineNoMatch.Success)
                        {
                            String lineNo = lineNoMatch.Groups[0].Value;
                            exceptionLine = exceptionLine.Replace(lineNo,
                                String.Format("<b style='color:red'>{0}</b>", lineNo));
                        }

                        sBuilder.Append(exceptionLine);
                    }
                }
            }
            return sBuilder.ToString();
        }
    }
}
