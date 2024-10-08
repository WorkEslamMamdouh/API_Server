using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Inv.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading;
using System.Data.Entity.Core.EntityClient;
using System.Web.Configuration;
using System.Net;
using System.Data.Entity; 
using Inv.API.Tools; 

namespace Inv.API.Tools
{
    public class BaseController : ApiController
    {
        bool singleDb = Convert.ToBoolean(WebConfigurationManager.AppSettings["singleDb"]);

        //protected InvEntities db = UnitOfWork.context(BuildConnectionString());

        //protected InvEntities db = UnitOfWork.context();


        //public static class GlopalSession // Replace 'YourClassName' with an appropriate class name
        //{
        //    public static string MODULE_CODE { get; set; }
        //    public static string UserCode { get; set; }
        //    public static string compCode { get; set; }
        //    public static string BranchCode { get; set; }
        //    public static string CurrentYear { get; set; }
        //}



        public string GetDataHeader(string key)
        {

            //try
            //{
            //    IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers = Request.Headers;


            //    foreach (var header in headers)
            //    {
            //        if (header.Key == key)
            //        {
            //            return string.Join(", ", header.Value);
            //        }
            //    }

            //}
            //catch (Exception)
            //{
            //    return "";
            //}
                    

            return "";

        }


        public void SetGlopalSession()
        {
            //GlopalSession.MODULE_CODE = GetDataHeader("MODULE_CODE");
            //GlopalSession.UserCode = GetDataHeader("UserCode");
            //GlopalSession.compCode = GetDataHeader("compCode");
            //GlopalSession.BranchCode = GetDataHeader("BranchCode");
            //GlopalSession.CurrentYear = GetDataHeader("CurrentYear");

        }
 

        public static string BuildConnectionString()
        { 

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = WebConfigurationManager.AppSettings["ServerName"];
            bool singleDb = Convert.ToBoolean(WebConfigurationManager.AppSettings["singleDb"]);

            //if (singleDb == false)
            //    //sqlBuilder.InitialCatalog = WebConfigurationManager.AppSettings["AbsoluteSysDbName"] + Shared.Session.SelectedYear;
            //else
            //    sqlBuilder.InitialCatalog = WebConfigurationManager.AppSettings["AbsoluteSysDbName"];

            sqlBuilder.UserID = WebConfigurationManager.AppSettings["DbUserName"];
            sqlBuilder.Password = WebConfigurationManager.AppSettings["DbPassword"];
            sqlBuilder.IntegratedSecurity = Convert.ToBoolean(WebConfigurationManager.AppSettings["UseIntegratedSecurity"]);
            sqlBuilder.MultipleActiveResultSets = true;

            string providerString = sqlBuilder.ToString();

            entityBuilder.ProviderConnectionString = "Persist Security Info=True;" + providerString;
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.Metadata = @"res://*/Domain.InvModel.csdl|res://*/Domain.InvModel.ssdl|res://*/Domain.InvModel.msl";

            return entityBuilder.ConnectionString;

        }




        public static string BuildConnectionStringReportsForm()
        {

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = WebConfigurationManager.AppSettings["ServerNameReportsForm"];
            bool singleDb = Convert.ToBoolean(WebConfigurationManager.AppSettings["singleDb"]);

            //if (singleDb == false)
            //    sqlBuilder.InitialCatalog = WebConfigurationManager.AppSettings["AbsoluteSysDbName"] + Shared.Session.SelectedYear;
            //else
            //    sqlBuilder.InitialCatalog = WebConfigurationManager.AppSettings["AbsoluteSysDbName"];

            sqlBuilder.UserID = WebConfigurationManager.AppSettings["DbUserNameReportsForm"];
            sqlBuilder.Password = WebConfigurationManager.AppSettings["DbPasswordReportsForm"];
            sqlBuilder.IntegratedSecurity = Convert.ToBoolean(WebConfigurationManager.AppSettings["UseIntegratedSecurity"]);
            sqlBuilder.MultipleActiveResultSets = true;

            string providerString = sqlBuilder.ToString();

            entityBuilder.ProviderConnectionString = "Persist Security Info=True;" + providerString;
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.Metadata = @"res://*/Domain.InvModel.csdl|res://*/Domain.InvModel.ssdl|res://*/Domain.InvModel.msl";

            return entityBuilder.ConnectionString;
        }

        protected IEnumerable<T> Get<T>(string SqlStatement)
        {

            //string connectionString = db.Database.Connection.ConnectionString;
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand command = new SqlCommand())
            //    {
            //        command.Connection = connection;
            //        command.CommandText = SqlStatement;
            //        connection.Open();
            //        DataTable table = new DataTable();
            //        table.Load(command.ExecuteReader());
            //        connection.Close();
            //        command.Dispose();
            //        connection.Dispose();

            //        var result = JsonConvert.DeserializeObject<IEnumerable<T>>(JsonConvert.SerializeObject(table));
            //        return result;
            //    }
            //}

            return null;
        }

        protected void InitalizeLanguage(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
        }

        protected string JsonSerialize(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string result = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
            return result;
        }

        protected T JsonDeserialize<T>(string obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            var objResult = (object)obj;
            var result = JsonConvert.DeserializeObject<T>(objResult.ToString(), settings);
            return result;
        }

        public object GetObjectClass(string jsonData, string NameClass)
        {
            Type type = AppDomain.CurrentDomain.GetAssemblies()
                     .SelectMany(x => x.GetTypes())
                     .FirstOrDefault(x => x.Name == "" + NameClass + "");

            object NewObj = JsonConvert.DeserializeObject("{}", type,
            new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects });

            var genericListType = typeof(List<>).MakeGenericType(new[] { NewObj.GetType() });

            object ObjClass = JsonConvert.DeserializeObject(jsonData, genericListType);

            return ObjClass;
        }
        //public object Get_Model(string query, string NameClass)
        //{
        //    Type type = AppDomain.CurrentDomain.GetAssemblies()
        //           .SelectMany(x => x.GetTypes())
        //           .FirstOrDefault(x => x.Name == "" + NameClass + "");

        //    if (type == null)
        //    {
        //        List<object> NewObjClass = new List<object>();
        //        return NewObjClass;
        //    }

        //    var res = db.Database.SqlQuery(type, query);
        //    string DataJson = JsonConvert.SerializeObject(res, Formatting.None);

        //    return GetObjectClass(DataJson, NameClass);

        //}

        //public DateTime GetCurrentDate(int comcode)
        //{
        //    var kControl = db.I_Control.Where(x => x.CompCode == comcode).First();
        //    DateTime utc = DateTime.UtcNow;
        //    DateTime res = utc.AddHours(int.Parse(kControl.UserTimeZoneUTCDiff.ToString()));
        //    return res;
        //}
    }
}
