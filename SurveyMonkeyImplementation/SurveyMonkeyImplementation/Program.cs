using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using System.Net;
using System.Diagnostics;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;

namespace SurveyMonkeyImplementation
{
    class Program
    {
        static SurveyList survlist;
        static SurveyList hola;
        static SurveyForm surv;
        static List<string> SurveyIDs;
        static void Main(string[] args)
        {
            fillSurveyIDs();
            List<SurveyForm> SurveyFormDetailsList = new List<SurveyForm>();
            for (int i = 0; i < SurveyIDs.Count; i++)
            {
                SurveyFormDetailsList.Add(GetSurveyDetails(SurveyIDs[i]));
            }
            for (int i = 0; i < SurveyFormDetailsList.Count; i++)
            {
                Console.WriteLine(SurveyFormDetailsList[i].title);
                Console.WriteLine(SurveyFormDetailsList[i].preview);
                Console.WriteLine(SurveyFormDetailsList[i].language);
                Console.WriteLine(SurveyFormDetailsList[i].question_count);
                Console.WriteLine(SurveyFormDetailsList[i].page_count);
                Console.WriteLine(SurveyFormDetailsList[i].date_created);
                Console.WriteLine(SurveyFormDetailsList[i].date_modified);
                Console.WriteLine(SurveyFormDetailsList[i].id);
                Console.WriteLine("---------------------------------------------------------------------");
            }
        }
        static bool fillSurveyIDs()
        {
            GetSurveys();
            SurveyIDs = new List<string>();
            for (int i = 0; i < survlist.data.Count; i++)
            {
                SurveyIDs.Add(survlist.data[i].id);
            }

            return true;
        }

        static string getHeader()
        {
            var AuthHeader = "bearer yd9L90lFyr2f3FxQ273ZdyXBh6V3Yj02VXd6H0jQd2MkLEYDoaGvDzPDDNrLiKDyQ5LUSeEkgPedKDRkcxfAfuHOrs9ax7gu48NRXgHyP2iTavhcDadqLtOLPbT20deVykxxDLAX2xtpDdI8CvCC4dWnc.bzX4U2rsseKlhIEYUiKe76GwOI72Q9CMlX4wjFDw6NRYp-3xVRFcy-0P-oHaUX8kY5UKm94nnk00xwZOA=";

            return AuthHeader;
        }
        static string getApiKey()
        {

            return "qkzc3tjbennyw82xwndxepnf";
        }
        static WebRequest GetSurveys()
        {

            var request = WebRequest.Create("https://api.surveymonkey.net/v3/surveys?api_key="+getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            //Console.WriteLine(responseFromServer);//Debo meter los IDs a un arreglo
            survlist = new SurveyList();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            survlist = serializer.Deserialize<SurveyList>(responseFromServer);
            reader.Close();
            response.Close();

            return request;
        }
        static SurveyForm GetSurveyDetails(string survey_id)
        {
            var request = WebRequest.Create("https://api.surveymonkey.net/v3/surveys/"+survey_id+"/details?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            //Console.WriteLine(responseFromServer);//Parsear a la clase
            surv = new SurveyForm();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            surv = serializer.Deserialize<SurveyForm>(responseFromServer);
            reader.Close();
            response.Close();

            return surv;
        }

    }
}
