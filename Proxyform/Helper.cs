using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
namespace proxyform
{
    internal class Helper
    {
      private static Regex regIp = new Regex(@"(?:(?:1[0-9]{2}|2[0-4][0-9]|25[0-5]|[1-9][0-9]|[0-9])\.){3}(?:1[0-9]{2}|2[0-4][0-9]|25[0-5]|[1-9][0-9]|[0-9]):[0-9]{1,5}",
     RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        internal static void ExtractIpPort(string result, ref HashSet<string> list)
        {
            // List<object> links = new List<object>();

            try
            {
                // MatchCollection matchescol = Regex.Matches(src, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\:[0-9]{1,5}");
                MatchCollection matchescol = regIp.Matches(result);
                if (matchescol != null)
                {
                    if (matchescol.Count > 0)
                    {
                        //SORTIR DUPLICATE CONTENT
                        IEnumerator ENUM = matchescol.GetEnumerator();


                        while (ENUM.MoveNext())
                        {
                            if (!list.Contains(ENUM.Current.ToString()))
                            {

                                list.Add(ENUM.Current.ToString());
                            }

                        }
                        //ENUM = null;



                    }
                }
                // matchescol = null;


            }
            catch
            {

                list = null;
            }

            //return links;

        }
    }
}
