using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Inv.API.Models;
using Inv.API.Tools;
using System; 
using System.Web.Http; 
using System.Text;
using System.IO;

namespace Inv.API.Controllers
{
  
    public class SystemController : BaseController
    {

      
        [HttpGet, AllowAnonymous]
        public IHttpActionResult GetDataFrom(string Name_txt, string MapPath)
        {

            string jsonData = "";

            try
            {


                // الحصول على مسار المجلد الأساسي للبرنامج
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                baseDirectory = baseDirectory + "DataBes";
                //Directory.CreateDirectory(baseDirectory);

                // إنشاء مسار الملف مع اسمه
                string filePath = Path.Combine(baseDirectory+ "\\", Name_txt + ".txt");

                


                jsonData = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.UrlPathEncode(filePath));


                string base64Encoded = jsonData;
                string base64Decoded;
                byte[] data = System.Convert.FromBase64String(base64Encoded);
                base64Decoded = Encoding.UTF8.GetString(data);

                return Ok(new BaseResponse(base64Decoded));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, AllowAnonymous]
        public IHttpActionResult SetDataFrom(string Name_txt, string jsonData, string MapPath)
        {
            try
            {
                // الحصول على مسار المجلد الأساسي للبرنامج
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                baseDirectory = baseDirectory + "DataBes";


                // Ensure the directory exists
                if (!Directory.Exists(baseDirectory))
                {
                    Directory.CreateDirectory(baseDirectory);
                }
                 
                // إنشاء مسار الملف مع اسمه
                string filePath = Path.Combine(baseDirectory + "\\", Name_txt + ".txt");



                string originalString = jsonData;
                byte[] bytes = Encoding.UTF8.GetBytes(originalString);
                string base64EncodedString = Convert.ToBase64String(bytes);
                System.IO.File.WriteAllText(filePath, base64EncodedString);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new BaseResponse("Done"));

        }



        [HttpPost, AllowAnonymous]
        public IHttpActionResult SetDataFromApi(string Name_txt, string jsonData, string MapPath)
        {
            try
            {
                // Get the base directory path
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                baseDirectory = Path.Combine(baseDirectory, "DataBes");

                // Ensure the directory exists
                if (!Directory.Exists(baseDirectory))
                {
                    Directory.CreateDirectory(baseDirectory);
                }

                // Create the file path
                string filePath = Path.Combine(baseDirectory, Name_txt + ".txt");

                // Write the jsonData directly to the file
                string originalString = jsonData;
                byte[] bytes = Encoding.UTF8.GetBytes(originalString);
                string base64EncodedString = Convert.ToBase64String(bytes);
                System.IO.File.WriteAllText(filePath, base64EncodedString);

                return Ok(new BaseResponse("Done"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}