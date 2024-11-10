using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAssignmentFiveCit.Login
{
    public class LoginCredentials
    {
        
        public static string filepath = "\"C:\\Users\\nikol\\OneDrive - Roskilde Universitet\\Documents\\NotAtAllPostGres.txt\"/";

        public static string filecontent = File.ReadAllText(filepath);
      
        
    }
    
}
