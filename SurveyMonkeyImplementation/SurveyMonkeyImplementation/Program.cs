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
using System.Xml;
using System.Windows.Forms;

namespace SurveyMonkeyImplementation
{
    class Program
    {
        static string apikey = "nada";
        static string token = "nada";
        static int responsePageAct = 1;
        static int ResponsePages = 1;
        static SurveyList survlist;
        static PageList pagelist;
        static QuestionList questlist;
        static ResponseList resplist;
        static SurveyForm surv;
        static QuestionDetail questiondetail;
        static List<string> SurveyIDs;
        static List<string> PagesIDs;
        static List<ResponseList> listaResponseList;
        static void Main(string[] args)
        {
            fillSurveyIDs();
            List<SurveyForm> SurveyFormDetailsList = new List<SurveyForm>();
            for (int i = 0; i < SurveyIDs.Count; i++)
            {
                SurveyFormDetailsList.Add(GetSurveyDetails(SurveyIDs[i]));
            }

            //for (int i = 0; i < SurveyFormDetailsList.Count; i++)
            //{
            //    Console.WriteLine(SurveyFormDetailsList[i].title);
            //    Console.WriteLine(SurveyFormDetailsList[i].preview);
            //    Console.WriteLine(SurveyFormDetailsList[i].language);
            //    Console.WriteLine(SurveyFormDetailsList[i].question_count);
            //    Console.WriteLine(SurveyFormDetailsList[i].page_count);
            //    Console.WriteLine(SurveyFormDetailsList[i].date_created);
            //    Console.WriteLine(SurveyFormDetailsList[i].date_modified);
            //    Console.WriteLine(SurveyFormDetailsList[i].id);
            //    Console.WriteLine("---------------------------------------------------------------------");
            //}


            //SurveyFormDetailsList[0].pagesIDs = BringPagesIDs(SurveyFormDetailsList[0]);
            //for (int i = 0; i < SurveyFormDetailsList[0].pagesIDs.Count; i++)
            //{
            //    //Console.WriteLine(SurveyFormDetailsList[0].pagesIDs[i]);
            //    GetQuestionList(SurveyFormDetailsList[0].id, SurveyFormDetailsList[0].pagesIDs[i]);
            //    for (int k = 0; k < questlist.data.Count; k++)
            //    {
            //        QuestionDetail objtmp = new QuestionDetail();
            //        objtmp = GetQuestionDetails(SurveyFormDetailsList[0].id, SurveyFormDetailsList[0].pagesIDs[i], questlist.data[k].id);
            //        if (objtmp.family == "multiple_choice" || objtmp.family == "single_choice") //Como solamente la family de single_choice es la que tiene choices
            //        {
            //            for (int j = 0; j < objtmp.answers.choices.Count; j++)
            //            {
            //                Console.WriteLine(objtmp.answers.choices[j].text);//Tengo que verificar entre answer.choice y answer.text porque hay preguntas que su respuesta es de otro tipo a choice

            //            }
            //            Console.WriteLine("------------------------------------------------");
            //        }
            //    }
            //}
            Console.WriteLine(SurveyFormDetailsList[0].id);
            List<string> listaprueba = new List<string>();
            listaprueba = BringResponsesIDs(SurveyFormDetailsList[0].id);

            Console.WriteLine(listaprueba.Count);
            //for (int i = 0; i < listaprueba.Count; i++)
            //{
            //    Console.WriteLine(i+")  "+listaprueba[i]);
            //}
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
        static List<String> BringSurveyIDs()
        {
            GetSurveys();
            List<String> IDsSurveys = new List<string>();
            for (int i = 0; i < survlist.data.Count; i++)
            {
                IDsSurveys.Add(survlist.data[i].id);
            }

            return IDsSurveys;
        }
        static bool fillPagesIDs(SurveyForm objsf)
        {
            GetPageList(objsf.id);
            PagesIDs = new List<string>();
            for (int i = 0; i < pagelist.data.Count; i++)
            {
                PagesIDs.Add(pagelist.data[i].id);
            }
            return true;
        }
        static List<String> BringPagesIDs(SurveyForm objsf)
        {
            GetPageList(objsf.id);
            List<string> IdPages = new List<string>();
            for (int i = 0; i < pagelist.data.Count; i++)
            {
                IdPages.Add(pagelist.data[i].id);
            }
            return IdPages;
        }
        static List<String> BringResponsesIDs(string surveyID)
        {
            List<string> IDsResponses = new List<string>();
            GetResponseList(surveyID);
            Console.WriteLine(resplist.data.Count);
            for (int j = 0; j < listaResponseList.Count; j++)
            {
                for (int i = 0; i < resplist.data.Count; i++)
                {
                    IDsResponses.Add(resplist.data[i].id);
                }
            }
            
            return IDsResponses;
        }
        static string getHeader()
        {
            var AuthHeader = "bearer ";
            if (token == "nada")
            {
                //Console.WriteLine("No se habia leido");
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "\\monkey.xml");
                XmlNode node = doc.DocumentElement.SelectSingleNode("/monkey/token");
                string attr = node.InnerText;
                token = attr;
            }
            return AuthHeader + token;
        }
        static string getApiKey()
        {
            if (apikey == "nada")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "\\monkey.xml");
                XmlNode node = doc.DocumentElement.SelectSingleNode("/monkey/key");
                string attr = node.InnerText;
                apikey = attr;
                return apikey;
            }
            else
            {
                //Console.WriteLine("Ya se habia leido");
                return apikey;
            }



        }
        static WebRequest GetSurveys()
        {

            var request = WebRequest.Create("https://api.surveymonkey.net/v3/surveys?api_key=" + getApiKey());
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
            var request = WebRequest.Create("https://api.surveymonkey.net/v3/surveys/" + survey_id + "/details?api_key=" + getApiKey());
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
        static QuestionDetail GetQuestionDetails(string survey_id, string page_id, string question_id)
        {
            var request = WebRequest.Create("https://api.surveymonkey.net/v3/surveys/" + survey_id + "/pages/" + page_id + "/questions/" + question_id + "?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            //Console.WriteLine(responseFromServer);//Parsear a la clase
            questiondetail = new QuestionDetail();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            questiondetail = serializer.Deserialize<QuestionDetail>(responseFromServer);
            reader.Close();
            response.Close();

            return questiondetail;
        }
        static WebRequest GetPageList(string surveyID)
        {
            var request = WebRequest.Create("https://api.surveymonkey.net/v3/surveys/" + surveyID + "/pages?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            //Console.WriteLine(responseFromServer);//Debo meter los IDs a un arreglo
            pagelist = new PageList();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            pagelist = serializer.Deserialize<PageList>(responseFromServer);
            reader.Close();
            response.Close();

            return request;
        }
        static WebRequest GetQuestionList(string surveyID, string pageID)
        {
            var request = WebRequest.Create("https://api.surveymonkey.net/v3/surveys/" + surveyID + "/pages/" + pageID + "/questions?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            //Console.WriteLine(responseFromServer);//Debo meter los IDs a un arreglo
            questlist = new QuestionList();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            questlist = serializer.Deserialize<QuestionList>(responseFromServer);
            reader.Close();
            response.Close();

            return request;
        }
        static WebRequest GetResponseList(string surveyID)
        {
            var request = WebRequest.Create("https://api.surveymonkey.net/v3/surveys/" + surveyID + "/responses?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            //Console.WriteLine(responseFromServer);//Debo meter los IDs a un arreglo
            resplist = new ResponseList();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            resplist = serializer.Deserialize<ResponseList>(responseFromServer);
            reader.Close();
            response.Close();
            listaResponseList = new List<ResponseList>();
            //////////////////////////////////////////////////////////////////////////////
            string total = resplist.total;
            int x = Int32.Parse(total);
            x = x / 1000;
            x++;
            Console.WriteLine(x);
            Console.WriteLine(total);
            responsePageAct = 1;
            string respPageStr = responsePageAct.ToString();
            GetResponseListTotal(surveyID,1,total,x);
            return request;
        }

        static WebRequest GetResponseListTotal(string surveyID,int page,string total, int RespPages)
        {
            var request = WebRequest.Create("https://api.surveymonkey.net/v3/surveys/" + surveyID + "/responses?page="+page+"&per_page=" + total + "&api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            //Console.WriteLine(responseFromServer);//Debo meter los IDs a un arreglo
            resplist = new ResponseList();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            resplist = serializer.Deserialize<ResponseList>(responseFromServer);
            listaResponseList.Add(resplist);
            Console.WriteLine(request.ToString());
            Console.WriteLine(resplist.data.Count);
            reader.Close();
            response.Close();
            if (page != RespPages)
            {
                GetResponseListTotal(surveyID, page+1, total, RespPages); //Llamado recursivo para que vaya a todas las paginas de responses
            }
            return request;
        }
    }
}
