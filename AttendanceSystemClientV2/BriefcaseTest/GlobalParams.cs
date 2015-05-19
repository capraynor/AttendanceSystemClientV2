using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriefcaseTest {
    public static class GlobalParams {


        public static string RootDir {
            //get { return Environment.CurrentDirectory; }
            get { return Environment.GetFolderPath ( Environment.SpecialFolder.MyDocuments ); }

        }



        public static string BriefcasePath {
            get {
                if (!Directory.Exists ( RootDir + @"\Briefcase\" )) {
                    Directory.CreateDirectory ( RootDir + @"\Briefcase\" );
                }
                return (RootDir + @"\Briefcase\");
            }


        }

    }
}
