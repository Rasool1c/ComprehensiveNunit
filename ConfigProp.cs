using NPOI.Util;
using NPOI.Util.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ComprehensiveNunit
{
    public class ConfigProp
    {
        public static void PropURL()
        {
            string UrL = ConfigurationManager.AppSettings["url"];
            

        }


    }
    //    public static Properties property;
    //    private static String configpath = ("C:/Users/mindc1may214/source/repos/ComprehensiveNunit/TideData.properties");

    //    public static void InitialPropertyFile()
    //    {
    //        property= new Properties();
    //        InputStream instm = new FileInputStream("configpath");
    //        property.Load(instm);
    //    }

}
