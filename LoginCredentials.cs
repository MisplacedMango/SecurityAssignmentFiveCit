using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAssignmentFiveCit.Login
{
    public class LoginCredentials
    {
        
        public static string filepath = "\"C:\\Users\\nikol\\OneDrive - Roskilde Universitet\\Documents\\NotAtAllPostGres.txt\"/";

        public static readonly string filecontent; 

        static LoginCredentials()
        {
            try
            {
                filecontent = File.ReadAllText(filepath);
            }
            catch (FileNotFoundException) 
            {
                throw new InvalidOperationException("File not found at specific path. Ensure File path is correct and contains correct information");

            }
            catch (Exception ex) 
            {
                throw new InvalidOperationException($"An error occured while reading the file: {ex.Message} ");
            }
        }
      
        
    }
    
}
