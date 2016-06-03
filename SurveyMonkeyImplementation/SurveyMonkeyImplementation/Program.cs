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
        static bool settingsLoaded = false;
        static string token = "nada";
        static DateTime datesPrior;
        static DateTime datesAfter;
        static string defaultSurveyName="";
        static string numRegistry;
        static string titlesContaining = "";
        static string initialPage = "";
        static string endingPage = "";
        static string responsesPerPage = "";

        static string baseURL = "https://api.surveymonkey.net/v3/";
        static int responsePageAct = 1;
        static int ResponsePages = 1;
        static SurveyList survlist;
        static PageList pagelist;
        static QuestionList questlist;
        static ResponseList resplist;
        static SurveyForm surv;
        static QuestionDetail questiondetail;
        static ResponseDetail responsedetail;
        static List<string> SurveyIDs;
        static List<string> PagesIDs;
        static List<ResponseList> listaResponseList;
        static void Main(string[] args)
        {
            //List<string> prueba = BringResponsesIDsAccordingToSettings("74972790");
            //for (int i = 0; i < prueba.Count; i++)
            //{
            //    Console.WriteLine(i+")"+prueba[i]);
            //}
            

            ResponsesToCSV(BringResponsesIDsAccordingToSettings("73337763"));
            //loadSettings();
            //ResponsesToCSV(GetSurveyDetails("74972790"),numRegistry);


            //loadSettings();
            //DateTime datet = DateTime.Parse(date);
            //string date2 = "2014-02-09T19:39:00";
            //DateTime datet2 = DateTime.Parse(date2);
            //if (datet<datet2)
            //{
            //    Console.WriteLine(datet.ToString());
            //}else
            //{
            //    Console.WriteLine(datet2.ToString());
            //}

            //fillSurveyIDs();
            //List<SurveyForm> SurveyFormDetailsList = new List<SurveyForm>();
            //for (int i = 0; i < SurveyIDs.Count; i++)
            //{
            //    SurveyFormDetailsList.Add(GetSurveyDetails(SurveyIDs[i]));
            //}
            //Necesario
            //loadSettings();
            //Console.WriteLine(defaultSurveyName);


            //Console.WriteLine(GetAPageQuestionCount("74972790", "240792622"));

            //ResponsesToCSV(GetSurveyDetailsBySurveyName(),numRegistry);

            //SurveysToCSV();
            //loadSettings();
            //SurveysCreatedAfterToCSV();
            //BringSurveys(BringSurveyIDs());


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
            //    Console.WriteLine(SurveyFormDetailsList[0].pagesIDs[i]);
            //    GetQuestionList(SurveyFormDetailsList[0].id, SurveyFormDetailsList[0].pagesIDs[i]);
            //    for (int k = 0; k < questlist.data.Count; k++)
            //    {
            //        Console.WriteLine(questlist.data[k].heading);
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

            //SurveyFormDetailsList[0].pagesIDs = BringPagesIDs(SurveyFormDetailsList[0]);
            //GetQuestionList(SurveyFormDetailsList[0].id, SurveyFormDetailsList[0].pagesIDs[0]);
            //Console.WriteLine(questlist.data[0].heading);

            //Console.WriteLine(SurveyFormDetailsList[0].id);
            //List<string> listaprueba = new List<string>();
            //listaprueba = BringResponsesIDs(SurveyFormDetailsList[0].id);
            //Console.WriteLine("Total con el que termina");
            //Console.WriteLine(listaprueba.Count);
            //for (int i = 0; i < listaprueba.Count; i++)
            //{
            //    ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
            //    Console.WriteLine(objRD.response_status);
            //    for (int j = 0; j < objRD.pages.Count; j++)
            //    {

            //        for (int k = 0; k < objRD.pages[j].questions.Count; k++)
            //        {
            //            //Console.WriteLine(objRD.pages[j].questions[k].id);
            //            for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
            //            {
            //                if (objRD.pages[j].questions[k].answers[l].choice_id != null)
            //                {
            //                    //Console.WriteLine(objRD.pages[j].questions[k].answers[l].choice_id);
            //                    //Encontrar el texto de la choice id
            //
            //                }
            //                if (objRD.pages[j].questions[k].answers[l].text != null)
            //                {
            //                    Console.WriteLine(objRD.pages[j].questions[k].answers[l].text);
            //                }
            //            }
            //        }
            //    }
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
        static List<SurveyForm> BringSurveys(List<string> SurveyIDs)
        {

            List<SurveyForm> SurveyFormDetailsList = new List<SurveyForm>();
            for (int i = 0; i < SurveyIDs.Count; i++)
            {
                SurveyFormDetailsList.Add(GetSurveyDetails(SurveyIDs[i]));
            }

            return SurveyFormDetailsList;
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
            for (int j = 0; j < listaResponseList.Count; j++)
            {
                for (int i = 0; i < listaResponseList[j].data.Count; i++)
                {
                    IDsResponses.Add(listaResponseList[j].data[i].id);
                }
            }
            
            return IDsResponses;
        }
        static List<String> BringResponsesIDs(string surveyID, int num_registros)
        {
            List<string> IDsResponses = new List<string>();
            int rp = num_registros / 1000;
            rp++;
            string x = num_registros.ToString();
            listaResponseList = new List<ResponseList>();
            GetResponseList(surveyID,1,x,rp);
            for (int j = 0; j < listaResponseList.Count; j++)
            {
                for (int i = 0; i < listaResponseList[j].data.Count; i++)
                {
                    IDsResponses.Add(listaResponseList[j].data[i].id);
                }
            }

            return IDsResponses;
        }
        static List<String> BringResponsesIDsAccordingToSettings(string surveyID)
        {
            loadSettings();
            listaResponseList = new List<ResponseList>();
            List<string> IDsResponses = new List<string>();
            GetResponseList(surveyID, int.Parse(initialPage), responsesPerPage, int.Parse(endingPage));
            for (int j = 0; j < listaResponseList.Count; j++)
            {
                for (int i = 0; i < listaResponseList[j].data.Count; i++)
                {
                    IDsResponses.Add(listaResponseList[j].data[i].id);
                }
            }

            return IDsResponses;

        }
        static string getHeader()
        {
            var AuthHeader = "bearer ";
            if (token == "nada")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "\\monkey.xml");
                XmlNode node = doc.DocumentElement.SelectSingleNode("/root/token");
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
                XmlNode node = doc.DocumentElement.SelectSingleNode("/root/key");
                string attr = node.InnerText;
                apikey = attr;
                return apikey;
            }
            else
            {
                return apikey;
            }
        }
        static void loadSettings()
        {
            if (!settingsLoaded)
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "\\monkey.xml");
                XmlNode datesPriornode = doc.DocumentElement.SelectSingleNode("/root/datesPrior");
                datesPrior = DateTime.Parse(datesPriornode.InnerText);
                XmlNode datesAfternode = doc.DocumentElement.SelectSingleNode("/root/datesAfter");
                datesAfter = DateTime.Parse(datesAfternode.InnerText);
                XmlNode titlesContainingNode = doc.DocumentElement.SelectSingleNode("/root/titlesContaining");
                titlesContaining = titlesContainingNode.InnerText;
                XmlNode RegistryNumberNode = doc.DocumentElement.SelectSingleNode("/root/RegistryNumber");
                numRegistry = RegistryNumberNode.InnerText;
                XmlNode surveyNameNode = doc.DocumentElement.SelectSingleNode("/root/surveyName");
                defaultSurveyName = surveyNameNode.InnerText;
                XmlNode initialPageNode = doc.DocumentElement.SelectSingleNode("/root/initialPage");
                initialPage = initialPageNode.InnerText;
                XmlNode endingPageNode = doc.DocumentElement.SelectSingleNode("/root/endingPage");
                endingPage = endingPageNode.InnerText;
                XmlNode responsesPerPageNode = doc.DocumentElement.SelectSingleNode("/root/responsesPerPage");
                responsesPerPage = responsesPerPageNode.InnerText;
                settingsLoaded = true;
            }
        }
        static WebRequest GetSurveys()
        {

            var request = WebRequest.Create(baseURL+"surveys?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            survlist = new SurveyList();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            survlist = serializer.Deserialize<SurveyList>(responseFromServer);
            reader.Close();
            response.Close();

            return request;
        }
        static SurveyForm GetSurveyDetails(string survey_id)
        {
            var request = WebRequest.Create(baseURL + "surveys/" + survey_id + "/details?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            surv = new SurveyForm();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            surv = serializer.Deserialize<SurveyForm>(responseFromServer);
            reader.Close();
            response.Close();

            return surv;
        }
        static SurveyForm GetSurveyDetailsBySurveyName()
        {
            loadSettings();
            var request = WebRequest.Create(baseURL + "surveys?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            SurveyList survlist2 = new SurveyList();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            survlist2 = serializer.Deserialize<SurveyList>(responseFromServer);
            reader.Close();
            response.Close();
            SurveyForm retornable = new SurveyForm();
            for (int i = 0; i < survlist2.data.Count; i++)
            {
                if (survlist2.data[i].title==defaultSurveyName)
                {
                    retornable = GetSurveyDetails(survlist2.data[i].id);
                    break;
                }
            }
            return retornable;

        }
        static int GetAPageQuestionCount(string surveyID, string page_id)
        {
            var request = WebRequest.Create(baseURL + "surveys/" + surveyID + "/pages/"+page_id+"?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            Page page = new Page();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            page = serializer.Deserialize<Page>(responseFromServer);
            reader.Close();
            response.Close();
            return page.question_count;
        }
        static SurveyForm GetSurveyDetailsBySurveyName(string surveyname)
        {
            loadSettings();
            var request = WebRequest.Create(baseURL + "surveys?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            SurveyList survlist2 = new SurveyList();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            survlist2 = serializer.Deserialize<SurveyList>(responseFromServer);
            reader.Close();
            response.Close();
            SurveyForm retornable = new SurveyForm();
            for (int i = 0; i < survlist2.data.Count; i++)
            {
                if (survlist2.data[i].title == surveyname)
                {
                    retornable = GetSurveyDetails(survlist2.data[i].id);
                    break;
                }
            }
            return retornable;

        }
        static QuestionDetail GetQuestionDetails(string survey_id, string page_id, string question_id)
        {
            var request = WebRequest.Create(baseURL+"surveys/" + survey_id + "/pages/" + page_id + "/questions/" + question_id + "?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();
            questiondetail = new QuestionDetail();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            questiondetail = serializer.Deserialize<QuestionDetail>(responseFromServer);
            questiondetail.page_id = page_id;
            reader.Close();
            response.Close();

            return questiondetail;
        }
        static int GetAQuestionPosition(string survey_id, string page_id, string question_id)
        {
            var request = WebRequest.Create(baseURL + "surveys/" + survey_id + "/pages/" + page_id + "/questions/" + question_id + "?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();
            questiondetail = new QuestionDetail();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            questiondetail = serializer.Deserialize<QuestionDetail>(responseFromServer);
            questiondetail.page_id = page_id;
            reader.Close();
            response.Close();

            return questiondetail.position;

        }
        static WebRequest GetPageList(string surveyID)
        {
            var request = WebRequest.Create(baseURL+"surveys/" + surveyID + "/pages?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            pagelist = new PageList();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            pagelist = serializer.Deserialize<PageList>(responseFromServer);
            reader.Close();
            response.Close();

            return request;
        }
        static WebRequest GetQuestionList(string surveyID, string pageID)
        {
            var request = WebRequest.Create(baseURL+"surveys/" + surveyID + "/pages/" + pageID + "/questions?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            questlist = new QuestionList();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            questlist = serializer.Deserialize<QuestionList>(responseFromServer);
            reader.Close();
            response.Close();

            return request;
        }
        static QuestionList BringQuestionList(string surveyID, string pageID)
        {
            var request = WebRequest.Create(baseURL + "surveys/" + surveyID + "/pages/" + pageID + "/questions?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            QuestionList qlist = new QuestionList();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            qlist = serializer.Deserialize<QuestionList>(responseFromServer);
            reader.Close();
            response.Close();

            return qlist;
        }
        static WebRequest GetResponseList(string surveyID)
        {
            var request = WebRequest.Create(baseURL+"surveys/" + surveyID + "/responses?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

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
            responsePageAct = 1;
            string respPageStr = responsePageAct.ToString();
            GetResponseList(surveyID,1,total,x);
            return request;
        }
        static WebRequest GetResponseList(string surveyID,int page,string total, int RespPages)
        {
            var request = WebRequest.Create(baseURL+"surveys/" + surveyID + "/responses?page="+page+"&per_page=" + total + "&api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();
            resplist = new ResponseList();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            resplist = serializer.Deserialize<ResponseList>(responseFromServer);
            listaResponseList.Add(resplist);
            reader.Close();
            response.Close();
            if (page != RespPages)
            {
                GetResponseList(surveyID, page+1, total, RespPages); //Llamado recursivo para que vaya a todas las paginas de responses
            }
            return request;
        }
        static ResponseDetail GetResponseDetails(string response_id)
        {
            var request = WebRequest.Create(baseURL+"responses/"+response_id+"/details?api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            responsedetail = new ResponseDetail();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            responsedetail = serializer.Deserialize<ResponseDetail>(responseFromServer);
            reader.Close();
            response.Close();

            return responsedetail;
        }
        static WebRequest GetResponseListWithSettings(string surveyID, int page, string total, int RespPages)
        {
            var request = WebRequest.Create(baseURL + "surveys/" + surveyID + "/responses?page=" + page + "&per_page=" + total + "&api_key=" + getApiKey());
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();
            resplist = new ResponseList();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            resplist = serializer.Deserialize<ResponseList>(responseFromServer);
            listaResponseList.Add(resplist);
            reader.Close();
            response.Close();
            if (page != RespPages)
            {
                GetResponseList(surveyID, page + 1, total, RespPages); //Llamado recursivo para que vaya a todas las paginas de responses
            }
            return request;
        }
        static string MakeARequest(string Request)
        {
            var request = WebRequest.Create(Request);
            request.Headers["Authorization"] = getHeader();
            var response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return responseFromServer;
        }
        static bool SurveysToCSV()
        {
            string filePath = Application.StartupPath + "\\SurveyForm.csv";
            List<SurveyForm> lista = BringSurveys(BringSurveyIDs());
            String csvtext = "SurveyFormId, SurveyFormName, SurveyLink, SurveyLanguage, SurveyQuestionCount, SurveyPageCount, SurveyDateCreated, SurveyDateModified, ProjectId\n";
            for (int i = 0; i < lista.Count; i++)
            {
                csvtext += "\""+lista[i].id + "\", ";
                csvtext += "\"" + lista[i].title + "\", ";
                csvtext += "\"" + lista[i].preview + "\", ";
                csvtext += "\"" + lista[i].language + "\", ";
                csvtext += "\"" + lista[i].question_count + "\", ";
                csvtext += "\"" + lista[i].page_count + "\", ";
                csvtext += "\"" + lista[i].date_created + "\", ";
                csvtext += "\"" + lista[i].date_modified + "\", ";
                csvtext += 1 + "\n";
            }
            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool SurveysTitleContainingToCSV()
        {
            loadSettings();
            string filePath = Application.StartupPath + "\\SurveyFormStartingWith"+ titlesContaining + ".csv";
            List<SurveyForm> lista = BringSurveys(BringSurveyIDs());
            String csvtext = "SurveyFormId, SurveyFormName, SurveyLink, SurveyLanguage, SurveyQuestionCount, SurveyPageCount, SurveyDateCreated, SurveyDateModified, ProjectId\n";
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].title.Contains(titlesContaining))
                {
                    csvtext += "\"" + lista[i].id + "\", ";
                    csvtext += "\"" + lista[i].title + "\", ";
                    csvtext += "\"" + lista[i].preview + "\", ";
                    csvtext += "\"" + lista[i].language + "\", ";
                    csvtext += "\"" + lista[i].question_count + "\", ";
                    csvtext += "\"" + lista[i].page_count + "\", ";
                    csvtext += "\"" + lista[i].date_created + "\", ";
                    csvtext += "\"" + lista[i].date_modified + "\", ";
                    csvtext += 1 + "\n";

                }
                
            }
            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool SurveysCreatedPriorToCSV()
        {
            loadSettings();
            Console.WriteLine(datesPrior.ToString());
            string tmpAux = RemoveLineEndings(datesPrior.ToString().Trim());
            String nameAux = Regex.Replace(tmpAux, @":|/", "-");
            nameAux=nameAux.Replace(".", string.Empty);
            string filePath = Application.StartupPath + "\\SurveyFormPriorTo" + nameAux + ".csv";
            Console.WriteLine(nameAux);
            List<SurveyForm> lista = BringSurveys(BringSurveyIDs());
            String csvtext = "SurveyFormId, SurveyFormName, SurveyLink, SurveyLanguage, SurveyQuestionCount, SurveyPageCount, SurveyDateCreated, SurveyDateModified, ProjectId\n";
            for (int i = 0; i < lista.Count; i++)
            {
                DateTime datetmp = DateTime.Parse(lista[i].date_created);
                if (datetmp<=datesPrior)
                {
                    csvtext += "\"" + lista[i].id + "\", ";
                    csvtext += "\"" + lista[i].title + "\", ";
                    csvtext += "\"" + lista[i].preview + "\", ";
                    csvtext += "\"" + lista[i].language + "\", ";
                    csvtext += "\"" + lista[i].question_count + "\", ";
                    csvtext += "\"" + lista[i].page_count + "\", ";
                    csvtext += "\"" + lista[i].date_created + "\", ";
                    csvtext += "\"" + lista[i].date_modified + "\", ";
                    csvtext += 1 + "\n";

                }

            }
            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool SurveysCreatedAfterToCSV()
        {
            loadSettings();
            string tmpAux = RemoveLineEndings(datesAfter.ToString().Trim());
            String nameAux = Regex.Replace(tmpAux, @":|/", "-");
            nameAux = nameAux.Replace(".", string.Empty);
            string filePath = Application.StartupPath + "\\SurveyFormAfterTo" + nameAux + ".csv";
            List<SurveyForm> lista = BringSurveys(BringSurveyIDs());
            String csvtext = "SurveyFormId, SurveyFormName, SurveyLink, SurveyLanguage, SurveyQuestionCount, SurveyPageCount, SurveyDateCreated, SurveyDateModified, ProjectId\n";
            for (int i = 0; i < lista.Count; i++)
            {
                DateTime datetmp = DateTime.Parse(lista[i].date_created);
                if (datetmp >= datesAfter)
                {
                    csvtext += "\"" + lista[i].id + "\", ";
                    csvtext += "\"" + lista[i].title + "\", ";
                    csvtext += "\"" + lista[i].preview + "\", ";
                    csvtext += "\"" + lista[i].language + "\", ";
                    csvtext += "\"" + lista[i].question_count + "\", ";
                    csvtext += "\"" + lista[i].page_count + "\", ";
                    csvtext += "\"" + lista[i].date_created + "\", ";
                    csvtext += "\"" + lista[i].date_modified + "\", ";
                    csvtext += 1 + "\n";

                }

            }
            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool ResponsesToCSV()
        {
            string filePath = Application.StartupPath + "\\SurveyResponses.csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<SurveyForm> SurveyFormDetailsList = BringSurveys(BringSurveyIDs());
            List<string> listaprueba = new List<string>();
            for (int m = 0; m < SurveyFormDetailsList.Count; m++)
            {
                listaprueba = BringResponsesIDs(SurveyFormDetailsList[m].id);
                for (int i = 0; i < listaprueba.Count; i++)
                {
                    ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                    csvtext += "\"" + objRD.id+"\", ";
                    csvtext += "\"" + SurveyFormDetailsList[m].id + "\", ";
                    csvtext += "\"" + objRD.date_modified + "\", " + objRD.date_created + "\", ";
                    csvtext += "\"" + objRD.ip_address + "\", ";
                    csvtext += "\"" + objRD.response_status + "\", " + "\"NULL" + "\", ";
                    csvtext += "\"" + objRD.recipient_id + "\", ";
                    csvtext += "\"" + objRD.total_time + "\", ";
                    Console.WriteLine(objRD.response_status);
                    for (int j = 0; j < objRD.pages.Count; j++)
                    {
                        int qcaux = GetAPageQuestionCount(SurveyFormDetailsList[m].id, objRD.pages[j].id);
                        int contadorNulls = 0;
                        if (qcaux > 0)
                        {
                            bool donethis = false;
                            for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                            {
                                csvtext += "\"";
                                if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                                {

                                    for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                    {
                                        if (!donethis)
                                        {
                                            int posaux = GetAQuestionPosition(SurveyFormDetailsList[m].id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            if (l < posaux)
                                            {
                                                for (int z = 0; z < posaux - l - 1; z++)
                                                {
                                                    csvtext += "NULL\",\"";

                                                    contadorNulls++;
                                                }
                                                donethis = true;
                                            }

                                        }

                                        if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                        {
                                            //Encontrar el texto de la choice id

                                            string temporal = "";
                                            QuestionDetail objQD = GetQuestionDetails(SurveyFormDetailsList[m].id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                            {
                                                if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                                {
                                                    //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                    string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                    string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                    temporal += newCont + "_";

                                                }
                                            }
                                            csvtext += temporal/*+ "\","*/;
                                            contadorNulls++;
                                        }
                                        else if (objRD.pages[j].questions[k].answers.Count > 0)
                                        {
                                            //csvtext += "\"";
                                            string newContent = "";
                                            for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                            {
                                                string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                                newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                            }
                                            csvtext += newContent;
                                            contadorNulls++;
                                        }
                                        else
                                        {
                                            csvtext += "NULL";
                                            contadorNulls++;
                                        }
                                    }
                                    csvtext += "\",";
                                }
                                else if (qcaux > contadorNulls)
                                {
                                    csvtext += "NULL\",";
                                    contadorNulls++;
                                }



                            }
                        }
                    }
                    csvtext += "\n";
                }

            }
            File.WriteAllText(filePath, csvtext);
            return true;
        }        
        static bool ResponsesToCSV(SurveyForm survey)
        {
            string filePath = Application.StartupPath + "\\SurveyResponses"+survey.title.Trim()+".csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<string> listaprueba = new List<string>();

            listaprueba = BringResponsesIDs(survey.id);
            for (int i = 0; i < listaprueba.Count; i++)
            {
                ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                csvtext += "\""+objRD.id + "\", ";
                csvtext += "\"" + survey.id + "\", ";
                csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                csvtext += "\"" + objRD.ip_address + "\", ";
                csvtext += "\"" + objRD.response_status + "\", " + "NULL" + "\", ";
                csvtext += "\"" + objRD.recipient_id + "\", ";
                csvtext += "\"" + objRD.total_time + "\", ";
                Console.WriteLine(objRD.response_status);
                for (int j = 0; j < objRD.pages.Count; j++)
                {
                    int qcaux = GetAPageQuestionCount(survey.id, objRD.pages[j].id);
                    int contadorNulls = 0;
                    if (qcaux > 0)
                    {
                        bool donethis = false;
                        for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                        {
                            csvtext += "\"";
                            if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                            {

                                for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                {
                                    if (!donethis)
                                    {
                                        int posaux = GetAQuestionPosition(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                        if (l < posaux)
                                        {
                                            for (int z = 0; z < posaux - l - 1; z++)
                                            {
                                                csvtext += "NULL\",\"";

                                                contadorNulls++;
                                            }
                                            donethis = true;
                                        }

                                    }

                                    if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                    {
                                        //Encontrar el texto de la choice id

                                        string temporal = "";
                                        QuestionDetail objQD = GetQuestionDetails(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                        for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                        {
                                            if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                            {
                                                //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                temporal += newCont + "_";

                                            }
                                        }
                                        csvtext += temporal/*+ "\","*/;
                                        contadorNulls++;
                                    }
                                    else if (objRD.pages[j].questions[k].answers.Count > 0)
                                    {
                                        //csvtext += "\"";
                                        string newContent = "";
                                        for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                        {
                                            string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                            newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                        }
                                        csvtext += newContent;
                                        contadorNulls++;
                                    }
                                    else
                                    {
                                        csvtext += "NULL";
                                        contadorNulls++;
                                    }
                                }
                                csvtext += "\",";
                            }
                            else if (qcaux > contadorNulls)
                            {
                                csvtext += "NULL\",";
                                contadorNulls++;
                            }



                        }
                    }

                }
                csvtext += "\n";
            }
   
            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool ResponsesToCSV(SurveyForm survey,int num_registros)
        {
            string filePath = Application.StartupPath + "\\SurveyResponses" + survey.title.Trim() + ".csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<string> listaprueba = new List<string>();

            listaprueba = BringResponsesIDs(survey.id,num_registros);
            int final = num_registros;
            if (listaprueba.Count <= num_registros)
            {
                final = listaprueba.Count;
            }
            for (int i = 0; i < final; i++)
            {
                ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                csvtext += "\"" + objRD.id + "\", ";
                csvtext += "\"" + survey.id + "\", ";
                csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                csvtext += "\"" + objRD.ip_address + "\", ";
                csvtext += "\"" + objRD.response_status + "\",\"" + "NULL" + "\", ";
                csvtext += "\"" + objRD.recipient_id + "\", ";
                csvtext += "\"" + objRD.total_time + "\", ";
                Console.WriteLine(objRD.response_status);
                for (int j = 0; j < objRD.pages.Count; j++)
                {
                    int qcaux = GetAPageQuestionCount(survey.id, objRD.pages[j].id);
                    int contadorNulls = 0;
                    if (qcaux > 0)
                    {
                        bool donethis = false;
                        for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                        {
                            csvtext += "\"";
                            if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                            {

                                for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                {
                                    if (!donethis)
                                    {
                                        int posaux = GetAQuestionPosition(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                        if (l < posaux)
                                        {
                                            for (int z = 0; z < posaux - l - 1; z++)
                                            {
                                                csvtext += "NULL\",\"";

                                                contadorNulls++;
                                            }
                                            donethis = true;
                                        }

                                    }

                                    if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                    {
                                        //Encontrar el texto de la choice id

                                        string temporal = "";
                                        QuestionDetail objQD = GetQuestionDetails(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                        for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                        {
                                            if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                            {
                                                //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                temporal += newCont + "_";

                                            }
                                        }
                                        csvtext += temporal/*+ "\","*/;
                                        contadorNulls++;
                                    }
                                    else if (objRD.pages[j].questions[k].answers.Count > 0)
                                    {
                                        //csvtext += "\"";
                                        string newContent = "";
                                        for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                        {
                                            string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                            newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                        }
                                        csvtext += newContent;
                                        contadorNulls++;
                                    }
                                    else
                                    {
                                        csvtext += "NULL";
                                        contadorNulls++;
                                    }
                                }
                                csvtext += "\",";
                            }
                            else if (qcaux > contadorNulls)
                            {
                                csvtext += "NULL\",";
                                contadorNulls++;
                            }



                        }
                    }


                }
                csvtext += "\n";
            }

            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool ResponsesToCSV(SurveyForm survey, string num_registros)
        {
            string filePath = Application.StartupPath + "\\SurveyResponses" + survey.title.Trim() + ".csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<string> listaprueba = new List<string>();
            if (num_registros=="*")
            {
                listaprueba = BringResponsesIDs(survey.id);
            }else
            {
                listaprueba = BringResponsesIDs(survey.id, int.Parse(num_registros));
            }
            
            int final = int.Parse(num_registros);
            if (listaprueba.Count <= int.Parse(num_registros))
            {
                final = listaprueba.Count;
            }
            for (int i = 0; i < final; i++)
            {
                ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                csvtext += "\"" + objRD.id + "\", ";
                csvtext += "\"" + survey.id + "\", ";
                csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                csvtext += "\"" + objRD.ip_address + "\", ";
                csvtext += "\"" + objRD.response_status + "\",\"" + "NULL" + "\", ";
                csvtext += "\"" + objRD.recipient_id + "\", ";
                csvtext += "\"" + objRD.total_time + "\", ";
                Console.WriteLine(objRD.response_status);
                for (int j = 0; j < objRD.pages.Count; j++)
                {
                    int qcaux = GetAPageQuestionCount(survey.id,objRD.pages[j].id);
                    int contadorNulls = 0;
                    if (qcaux > 0)
                    {
                        bool donethis = false;
                        for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                        {
                            csvtext += "\"";
                            if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                            {

                                for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                {
                                    if (!donethis)
                                    {
                                        int posaux = GetAQuestionPosition(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                        if (l < posaux)
                                        {
                                            for (int z = 0; z < posaux - l - 1; z++)
                                            {
                                                csvtext += "NULL\",\"";

                                                contadorNulls++;
                                            }
                                            donethis = true;
                                        }

                                    }

                                    if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                    {
                                        //Encontrar el texto de la choice id

                                        string temporal = "";
                                        QuestionDetail objQD = GetQuestionDetails(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                        for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                        {
                                            if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                            {
                                                //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                temporal += newCont + "_";

                                            }
                                        }
                                        csvtext += temporal/*+ "\","*/;
                                        contadorNulls++;
                                    }
                                    else if (objRD.pages[j].questions[k].answers.Count > 0)
                                    {
                                        //csvtext += "\"";
                                        string newContent = "";
                                        for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                        {
                                            string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                            newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                        }
                                        csvtext += newContent;
                                        contadorNulls++;
                                    }
                                    else
                                    {
                                        csvtext += "NULL";
                                        contadorNulls++;
                                    }
                                }
                                csvtext += "\",";
                            }
                            else if (qcaux > contadorNulls)
                            {
                                csvtext += "NULL\",";
                                contadorNulls++;
                            }



                        }
                    }

                }
                csvtext += "\n";
            }

            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool ResponsesToCSVPriorTo(SurveyForm survey)
        {
            loadSettings();
            string tmpAux = RemoveLineEndings(datesPrior.ToString().Trim());
            String nameAux = Regex.Replace(tmpAux, @":|/", "-");
            nameAux = nameAux.Replace(".", string.Empty);
            string filePath = Application.StartupPath + "\\SurveyResponsesPriorTo" + survey.title.Trim()+"PriorTo"+ nameAux + ".csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<string> listaprueba = new List<string>();

            listaprueba = BringResponsesIDs(survey.id);
            for (int i = 0; i < listaprueba.Count; i++)
            {
                ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                if (datesPrior >= DateTime.Parse(objRD.date_created))
                {


                    csvtext += "\"" + objRD.id + "\", ";
                    csvtext += "\"" + survey.id + "\", ";
                    csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                    csvtext += "\"" + objRD.ip_address + "\", ";
                    csvtext += "\"" + objRD.response_status + "\", " + "NULL" + "\", ";
                    csvtext += "\"" + objRD.recipient_id + "\", ";
                    csvtext += "\"" + objRD.total_time + "\", ";
                    Console.WriteLine(objRD.response_status);
                    for (int j = 0; j < objRD.pages.Count; j++)
                    {
                        int qcaux = GetAPageQuestionCount(survey.id, objRD.pages[j].id);
                        int contadorNulls = 0;
                        if (qcaux > 0)
                        {
                            bool donethis = false;
                            for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                            {
                                csvtext += "\"";
                                if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                                {

                                    for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                    {
                                        if (!donethis)
                                        {
                                            int posaux = GetAQuestionPosition(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            if (l < posaux)
                                            {
                                                for (int z = 0; z < posaux - l - 1; z++)
                                                {
                                                    csvtext += "NULL\",\"";

                                                    contadorNulls++;
                                                }
                                                donethis = true;
                                            }

                                        }

                                        if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                        {
                                            //Encontrar el texto de la choice id

                                            string temporal = "";
                                            QuestionDetail objQD = GetQuestionDetails(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                            {
                                                if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                                {
                                                    //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                    string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                    string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                    temporal += newCont + "_";

                                                }
                                            }
                                            csvtext += temporal/*+ "\","*/;
                                            contadorNulls++;
                                        }
                                        else if (objRD.pages[j].questions[k].answers.Count > 0)
                                        {
                                            //csvtext += "\"";
                                            string newContent = "";
                                            for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                            {
                                                string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                                newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                            }
                                            csvtext += newContent;
                                            contadorNulls++;
                                        }
                                        else
                                        {
                                            csvtext += "NULL";
                                            contadorNulls++;
                                        }
                                    }
                                    csvtext += "\",";
                                }
                                else if (qcaux > contadorNulls)
                                {
                                    csvtext += "NULL\",";
                                    contadorNulls++;
                                }



                            }
                        }

                    }
                    csvtext += "\n";
                }
            }

            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool ResponsesToCSVPriorTo(SurveyForm survey, int num_registros)
        {
            loadSettings();
            string tmpAux = RemoveLineEndings(datesPrior.ToString().Trim());
            String nameAux = Regex.Replace(tmpAux, @":|/", "-");
            nameAux = nameAux.Replace(".", string.Empty);
            string filePath = Application.StartupPath + "\\SurveyResponses" + survey.title.Trim()+"PriorTo"+nameAux + ".csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<string> listaprueba = new List<string>();

            listaprueba = BringResponsesIDs(survey.id, num_registros);
            int final = num_registros;
            if (listaprueba.Count <= num_registros)
            {
                final = listaprueba.Count;
            }
            for (int i = 0; i < final; i++)
            {
                ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                if (datesPrior >= DateTime.Parse(objRD.date_created))
                {
                    csvtext += "\"" + objRD.id + "\", ";
                    csvtext += "\"" + survey.id + "\", ";
                    csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                    csvtext += "\"" + objRD.ip_address + "\", ";
                    csvtext += "\"" + objRD.response_status + "\",\"" + "NULL" + "\", ";
                    csvtext += "\"" + objRD.recipient_id + "\", ";
                    csvtext += "\"" + objRD.total_time + "\", ";
                    Console.WriteLine(objRD.response_status);
                    for (int j = 0; j < objRD.pages.Count; j++)
                    {
                        int qcaux = GetAPageQuestionCount(survey.id, objRD.pages[j].id);
                        int contadorNulls = 0;
                        if (qcaux > 0)
                        {
                            bool donethis = false;
                            for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                            {
                                csvtext += "\"";
                                if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                                {

                                    for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                    {
                                        if (!donethis)
                                        {
                                            int posaux = GetAQuestionPosition(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            if (l < posaux)
                                            {
                                                for (int z = 0; z < posaux - l - 1; z++)
                                                {
                                                    csvtext += "NULL\",\"";

                                                    contadorNulls++;
                                                }
                                                donethis = true;
                                            }

                                        }

                                        if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                        {
                                            //Encontrar el texto de la choice id

                                            string temporal = "";
                                            QuestionDetail objQD = GetQuestionDetails(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                            {
                                                if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                                {
                                                    //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                    string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                    string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                    temporal += newCont + "_";

                                                }
                                            }
                                            csvtext += temporal/*+ "\","*/;
                                            contadorNulls++;
                                        }
                                        else if (objRD.pages[j].questions[k].answers.Count > 0)
                                        {
                                            //csvtext += "\"";
                                            string newContent = "";
                                            for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                            {
                                                string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                                newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                            }
                                            csvtext += newContent;
                                            contadorNulls++;
                                        }
                                        else
                                        {
                                            csvtext += "NULL";
                                            contadorNulls++;
                                        }
                                    }
                                    csvtext += "\",";
                                }
                                else if (qcaux > contadorNulls)
                                {
                                    csvtext += "NULL\",";
                                    contadorNulls++;
                                }



                            }
                        }


                    }
                    csvtext += "\n";
                }
            }

            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool ResponsesToCSVPriorTo(SurveyForm survey, string num_registros)
        {
            loadSettings();
            string tmpAux = RemoveLineEndings(datesPrior.ToString().Trim());
            String nameAux = Regex.Replace(tmpAux, @":|/", "-");
            nameAux = nameAux.Replace(".", string.Empty);
            string filePath = Application.StartupPath + "\\SurveyResponses" + survey.title.Trim() +"PriorTo"+nameAux+ ".csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<string> listaprueba = new List<string>();
            if (num_registros == "*")
            {
                listaprueba = BringResponsesIDs(survey.id);
            }
            else
            {
                listaprueba = BringResponsesIDs(survey.id, int.Parse(num_registros));
            }
            int final = int.Parse(num_registros);
            if (listaprueba.Count <= int.Parse(num_registros))
            {
                final = listaprueba.Count;
            }
            for (int i = 0; i < final; i++)
            {
                ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                if (datesPrior >= DateTime.Parse(objRD.date_created))
                {
                    csvtext += "\"" + objRD.id + "\", ";
                    csvtext += "\"" + survey.id + "\", ";
                    csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                    csvtext += "\"" + objRD.ip_address + "\", ";
                    csvtext += "\"" + objRD.response_status + "\",\"" + "NULL" + "\", ";
                    csvtext += "\"" + objRD.recipient_id + "\", ";
                    csvtext += "\"" + objRD.total_time + "\", ";
                    Console.WriteLine(objRD.response_status);
                    for (int j = 0; j < objRD.pages.Count; j++)
                    {
                        int qcaux = GetAPageQuestionCount(survey.id, objRD.pages[j].id);
                        int contadorNulls = 0;
                        if (qcaux > 0)
                        {
                            bool donethis = false;
                            for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                            {
                                csvtext += "\"";
                                if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                                {

                                    for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                    {
                                        if (!donethis)
                                        {
                                            int posaux = GetAQuestionPosition(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            if (l < posaux)
                                            {
                                                for (int z = 0; z < posaux - l - 1; z++)
                                                {
                                                    csvtext += "NULL\",\"";

                                                    contadorNulls++;
                                                }
                                                donethis = true;
                                            }

                                        }

                                        if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                        {
                                            //Encontrar el texto de la choice id

                                            string temporal = "";
                                            QuestionDetail objQD = GetQuestionDetails(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                            {
                                                if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                                {
                                                    //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                    string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                    string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                    temporal += newCont + "_";

                                                }
                                            }
                                            csvtext += temporal/*+ "\","*/;
                                            contadorNulls++;
                                        }
                                        else if (objRD.pages[j].questions[k].answers.Count > 0)
                                        {
                                            //csvtext += "\"";
                                            string newContent = "";
                                            for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                            {
                                                string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                                newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                            }
                                            csvtext += newContent;
                                            contadorNulls++;
                                        }
                                        else
                                        {
                                            csvtext += "NULL";
                                            contadorNulls++;
                                        }
                                    }
                                    csvtext += "\",";
                                }
                                else if (qcaux > contadorNulls)
                                {
                                    csvtext += "NULL\",";
                                    contadorNulls++;
                                }



                            }
                        }
                    }
                    csvtext += "\n";
                }
            }

            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool ResponsesToCSVAfterTo(SurveyForm survey)
        {
            loadSettings();
            string tmpAux = RemoveLineEndings(datesAfter.ToString().Trim());
            String nameAux = Regex.Replace(tmpAux, @":|/", "-");
            nameAux = nameAux.Replace(".", string.Empty);
            string filePath = Application.StartupPath + "\\SurveyResponsesPriorTo" + survey.title.Trim() + "PriorTo" + nameAux + ".csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<string> listaprueba = new List<string>();

            listaprueba = BringResponsesIDs(survey.id);
            for (int i = 0; i < listaprueba.Count; i++)
            {
                ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                if (datesAfter <= DateTime.Parse(objRD.date_created))
                {


                    csvtext += "\"" + objRD.id + "\", ";
                    csvtext += "\"" + survey.id + "\", ";
                    csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                    csvtext += "\"" + objRD.ip_address + "\", ";
                    csvtext += "\"" + objRD.response_status + "\", " + "NULL" + "\", ";
                    csvtext += "\"" + objRD.recipient_id + "\", ";
                    csvtext += "\"" + objRD.total_time + "\", ";
                    Console.WriteLine(objRD.response_status);
                    for (int j = 0; j < objRD.pages.Count; j++)
                    {
                        int qcaux = GetAPageQuestionCount(survey.id, objRD.pages[j].id);
                        int contadorNulls = 0;
                        if (qcaux > 0)
                        {
                            bool donethis = false;
                            for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                            {
                                csvtext += "\"";
                                if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                                {

                                    for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                    {
                                        if (!donethis)
                                        {
                                            int posaux = GetAQuestionPosition(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            if (l < posaux)
                                            {
                                                for (int z = 0; z < posaux - l - 1; z++)
                                                {
                                                    csvtext += "NULL\",\"";

                                                    contadorNulls++;
                                                }
                                                donethis = true;
                                            }

                                        }

                                        if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                        {
                                            //Encontrar el texto de la choice id

                                            string temporal = "";
                                            QuestionDetail objQD = GetQuestionDetails(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                            {
                                                if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                                {
                                                    //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                    string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                    string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                    temporal += newCont + "_";

                                                }
                                            }
                                            csvtext += temporal/*+ "\","*/;
                                            contadorNulls++;
                                        }
                                        else if (objRD.pages[j].questions[k].answers.Count > 0)
                                        {
                                            //csvtext += "\"";
                                            string newContent = "";
                                            for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                            {
                                                string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                                newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                            }
                                            csvtext += newContent;
                                            contadorNulls++;
                                        }
                                        else
                                        {
                                            csvtext += "NULL";
                                            contadorNulls++;
                                        }
                                    }
                                    csvtext += "\",";
                                }
                                else if (qcaux > contadorNulls)
                                {
                                    csvtext += "NULL\",";
                                    contadorNulls++;
                                }



                            }
                        }

                    }
                    csvtext += "\n";
                }
            }

            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool ResponsesToCSVAfterTo(SurveyForm survey, int num_registros)
        {
            loadSettings();
            string tmpAux = RemoveLineEndings(datesAfter.ToString().Trim());
            String nameAux = Regex.Replace(tmpAux, @":|/", "-");
            nameAux = nameAux.Replace(".", string.Empty);
            string filePath = Application.StartupPath + "\\SurveyResponses" + survey.title.Trim() + "PriorTo" + nameAux + ".csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<string> listaprueba = new List<string>();

            listaprueba = BringResponsesIDs(survey.id, num_registros);
            int final = num_registros;
            if (listaprueba.Count <= num_registros)
            {
                final = listaprueba.Count;
            }
            for (int i = 0; i < final; i++)
            {
                ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                if (datesAfter <= DateTime.Parse(objRD.date_created))
                {
                    csvtext += "\"" + objRD.id + "\", ";
                    csvtext += "\"" + survey.id + "\", ";
                    csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                    csvtext += "\"" + objRD.ip_address + "\", ";
                    csvtext += "\"" + objRD.response_status + "\",\"" + "NULL" + "\", ";
                    csvtext += "\"" + objRD.recipient_id + "\", ";
                    csvtext += "\"" + objRD.total_time + "\", ";
                    Console.WriteLine(objRD.response_status);
                    for (int j = 0; j < objRD.pages.Count; j++)
                    {
                        int qcaux = GetAPageQuestionCount(survey.id, objRD.pages[j].id);
                        int contadorNulls = 0;
                        if (qcaux > 0)
                        {
                            bool donethis = false;
                            for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                            {
                                csvtext += "\"";
                                if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                                {

                                    for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                    {
                                        if (!donethis)
                                        {
                                            int posaux = GetAQuestionPosition(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            if (l < posaux)
                                            {
                                                for (int z = 0; z < posaux - l - 1; z++)
                                                {
                                                    csvtext += "NULL\",\"";

                                                    contadorNulls++;
                                                }
                                                donethis = true;
                                            }

                                        }

                                        if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                        {
                                            //Encontrar el texto de la choice id

                                            string temporal = "";
                                            QuestionDetail objQD = GetQuestionDetails(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                            {
                                                if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                                {
                                                    //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                    string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                    string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                    temporal += newCont + "_";

                                                }
                                            }
                                            csvtext += temporal/*+ "\","*/;
                                            contadorNulls++;
                                        }
                                        else if (objRD.pages[j].questions[k].answers.Count > 0)
                                        {
                                            //csvtext += "\"";
                                            string newContent = "";
                                            for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                            {
                                                string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                                newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                            }
                                            csvtext += newContent;
                                            contadorNulls++;
                                        }
                                        else
                                        {
                                            csvtext += "NULL";
                                            contadorNulls++;
                                        }
                                    }
                                    csvtext += "\",";
                                }
                                else if (qcaux > contadorNulls)
                                {
                                    csvtext += "NULL\",";
                                    contadorNulls++;
                                }



                            }
                        }

                    }
                    csvtext += "\n";
                }
            }

            File.WriteAllText(filePath, csvtext);
            return true;
        }
        static bool ResponsesToCSVAfterTo(SurveyForm survey, string num_registros)
        {
            loadSettings();
            string tmpAux = RemoveLineEndings(datesAfter.ToString().Trim());
            String nameAux = Regex.Replace(tmpAux, @":|/", "-");
            nameAux = nameAux.Replace(".", string.Empty);
            string filePath = Application.StartupPath + "\\SurveyResponses" + survey.title.Trim() + "PriorTo" + nameAux + ".csv";
            String csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
            for (int i = 1; i < 101; i++)
            {
                csvtext += ", QUESTION" + i;
            }
            csvtext += "\n";
            List<string> listaprueba = new List<string>();
            if (num_registros == "*")
            {
                listaprueba = BringResponsesIDs(survey.id);
            }
            else
            {
                listaprueba = BringResponsesIDs(survey.id, int.Parse(num_registros));
            }

            int final = int.Parse(num_registros);
            if (listaprueba.Count <= int.Parse(num_registros))
            {
                final = listaprueba.Count;
            }
            for (int i = 0; i < final; i++)
            {
                ResponseDetail objRD = GetResponseDetails(listaprueba[i]);
                if (datesAfter <= DateTime.Parse(objRD.date_created))
                {
                    csvtext += "\"" + objRD.id + "\", ";
                    csvtext += "\"" + survey.id + "\", ";
                    csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                    csvtext += "\"" + objRD.ip_address + "\", ";
                    csvtext += "\"" + objRD.response_status + "\",\"" + "NULL" + "\", ";
                    csvtext += "\"" + objRD.recipient_id + "\", ";
                    csvtext += "\"" + objRD.total_time + "\", ";
                    Console.WriteLine(objRD.response_status);
                    for (int j = 0; j < objRD.pages.Count; j++)
                    {
                        int qcaux = GetAPageQuestionCount(survey.id, objRD.pages[j].id);
                        int contadorNulls = 0;
                        if (qcaux > 0)
                        {
                            bool donethis = false;
                            for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                            {
                                csvtext += "\"";
                                if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                                {

                                    for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                    {
                                        if (!donethis)
                                        {
                                            int posaux = GetAQuestionPosition(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            if (l < posaux)
                                            {
                                                for (int z = 0; z < posaux - l - 1; z++)
                                                {
                                                    csvtext += "NULL\",\"";

                                                    contadorNulls++;
                                                }
                                                donethis = true;
                                            }

                                        }

                                        if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                        {
                                            //Encontrar el texto de la choice id

                                            string temporal = "";
                                            QuestionDetail objQD = GetQuestionDetails(survey.id, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                            {
                                                if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                                {
                                                    //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                    string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                    string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                    temporal += newCont + "_";

                                                }
                                            }
                                            csvtext += temporal/*+ "\","*/;
                                            contadorNulls++;
                                        }
                                        else if (objRD.pages[j].questions[k].answers.Count > 0)
                                        {
                                            //csvtext += "\"";
                                            string newContent = "";
                                            for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                            {
                                                string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                                newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                            }
                                            csvtext += newContent;
                                            contadorNulls++;
                                        }
                                        else
                                        {
                                            csvtext += "NULL";
                                            contadorNulls++;
                                        }
                                    }
                                    csvtext += "\",";
                                }
                                else if (qcaux > contadorNulls)
                                {
                                    csvtext += "NULL\",";
                                    contadorNulls++;
                                }



                            }
                        }


                    }
                    csvtext += "\n";
                }
            }

            File.WriteAllText(filePath, csvtext);
            return true;
        }

        static bool ResponsesToCSV(List<string> listOfResponsesIDs)
        {
            if (listOfResponsesIDs.Count==0)
            {
                return false;
            }
            List<ResponseDetail> rdlist = new List<ResponseDetail>();
            
            for (int i = 0; i < listOfResponsesIDs.Count; i++)
            {
                rdlist.Add(GetResponseDetails(listOfResponsesIDs[i]));
            }
            string surveyID = rdlist[0].survey_id;
            SurveyForm objSF = GetSurveyDetails(surveyID);
            string filePath = Application.StartupPath + "\\SurveyResponses" + objSF.title.Trim() + ".csv";
            String csvtext ="";


            if (File.Exists(filePath))//entonces append
            {
                for (int i = 0; i < rdlist.Count; i++)
                {
                    ResponseDetail objRD = rdlist[i];
                    csvtext += "\"" + objRD.id + "\", ";
                    csvtext += "\"" + surveyID + "\", ";
                    csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                    csvtext += "\"" + objRD.ip_address + "\", ";
                    csvtext += "\"" + objRD.response_status + "\", \"" + "NULL" + "\", ";
                    csvtext += "\"" + objRD.recipient_id + "\", ";
                    csvtext += "\"" + objRD.total_time + "\", ";
                    Console.WriteLine(objRD.response_status);
                    for (int j = 0; j < objRD.pages.Count; j++)
                    {
                        int qcaux = GetAPageQuestionCount(surveyID, objRD.pages[j].id);
                        int contadorNulls = 0;
                        if (qcaux > 0)
                        {
                            bool donethis = false;
                            for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                            {
                                csvtext += "\"";
                                if (objRD.pages[j].questions.Count > k)//Poner objRD.pages[j].questions.Count en otra variable y comparar con esa ////////////////////////////
                                {
                                    
                                    for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                    {
                                        if (!donethis)
                                        {
                                            int posaux = GetAQuestionPosition(surveyID, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            if (l < posaux )
                                            {
                                                for (int z = 0; z < posaux-l-1; z++)
                                                {
                                                    csvtext += "NULL\",\"";
                                                   
                                                    contadorNulls++;
                                                }
                                                donethis = true;
                                            }
                                            
                                        }
                                        
                                        if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                        {
                                            //Encontrar el texto de la choice id

                                            string temporal = "";
                                            QuestionDetail objQD = GetQuestionDetails(surveyID, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                            {
                                                if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                                {
                                                    //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                    string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                    string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                    temporal += newCont + "_";

                                                }
                                            }
                                            csvtext += temporal/*+ "\","*/;
                                            contadorNulls++;
                                        }
                                        else if (objRD.pages[j].questions[k].answers.Count > 0)
                                        {
                                            //csvtext += "\"";
                                            string newContent = "";
                                            for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                            {
                                                string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                                newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                            }
                                            csvtext += newContent;
                                            contadorNulls++;
                                        }
                                        else
                                        {
                                            csvtext += "NULL";
                                            contadorNulls++;
                                        }
                                    }
                                    csvtext += "\",";
                                }
                                else if (qcaux > contadorNulls)
                                {
                                    csvtext += "NULL\",";
                                    contadorNulls++;
                                }

                                

                            }
                        }                       
                    }
                    csvtext += "\n";
                }
                File.AppendAllText(filePath, csvtext);



            }
            else//entonces crear nuevo
            {
                csvtext = "SurveyResponseId, SurveyFormID, SurveyResponseDateModified, SurveyResponseDateCreated, SurveyResponseIp, SurveyResponseCompleted, EmailAddress, RecipientId, TotalTime";
                for (int i = 1; i < 101; i++)
                {
                    csvtext += ", QUESTION" + i;
                }
                csvtext += "\n";


                for (int i = 0; i < rdlist.Count; i++)
                {
                    ResponseDetail objRD = rdlist[i];
                    csvtext += "\"" + objRD.id + "\", ";
                    csvtext += "\"" + surveyID + "\", ";
                    csvtext += "\"" + objRD.date_modified + "\", " + "\"" + objRD.date_created + "\", ";
                    csvtext += "\"" + objRD.ip_address + "\", ";
                    csvtext += "\"" + objRD.response_status + "\", \"" + "NULL" + "\", ";
                    csvtext += "\"" + objRD.recipient_id + "\", ";
                    csvtext += "\"" + objRD.total_time + "\", ";
                    Console.WriteLine(objRD.response_status);
                    for (int j = 0; j < objRD.pages.Count; j++)
                    {
                        int qcaux = GetAPageQuestionCount(surveyID, objRD.pages[j].id);
                        
                        int contadorNulls = 0;
                        if (qcaux > 0)
                        {
                            bool donethis = false;
                            for (int k = 0; k < qcaux; k++) //objRD.pages[j].id debo buscar este id en otro lado
                            {
                                csvtext += "\"";
                                if (objRD.pages[j].questions.Count > k)
                                {
                                    for (int l = 0; l < objRD.pages[j].questions[k].answers.Count; l++)
                                    {
                                        if (!donethis)
                                        {
                                            int posaux = GetAQuestionPosition(surveyID, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            if (l < posaux)
                                            {
                                                for (int z = 0; z < posaux-l-1; z++)
                                                {
                                                    csvtext += "NULL\",\"";
                                                    contadorNulls++;
                                                }
                                            }
                                            donethis = true;
                                        }
                                        if (objRD.pages[j].questions[k].answers[l].choice_id != null)
                                        {
                                            //Encontrar el texto de la choice id

                                            string temporal = "";
                                            QuestionDetail objQD = GetQuestionDetails(surveyID, objRD.pages[j].id, objRD.pages[j].questions[k].id);
                                            for (int q = 0; q < objQD.answers.choices.Count; q++)//Como pueden ser multiple choice, debo concatenarlas
                                            {
                                                if (objQD.answers.choices[q].id == objRD.pages[j].questions[k].answers[l].choice_id)
                                                {
                                                    //csvtext += "\"" + objQD.answers.choices[q].text + "\", ";
                                                    string Content = RemoveLineEndings(objQD.answers.choices[q].text);
                                                    string newCont = Regex.Replace(Content, @"\t|\n|\r|,", "");
                                                    temporal += newCont + "_";

                                                }
                                            }
                                            csvtext += temporal/*+ "\","*/;
                                            contadorNulls++;

                                        }
                                        else if (objRD.pages[j].questions[k].answers.Count > 0)
                                        {
                                            //csvtext += "\"";
                                            string newContent = "";
                                            for (int b = 0; b < objRD.pages[j].questions[k].answers.Count; b++)
                                            {
                                                string Content = RemoveLineEndings(objRD.pages[j].questions[k].answers[b].text);
                                                newContent += Regex.Replace(Content, @"\t|\n|\r|,", "") + "_";

                                            }

                                            csvtext += newContent;
                                            contadorNulls++;
                                        }
                                        else
                                        {
                                            csvtext += "NULO";
                                            contadorNulls++;
                                        }
                                    }
                                    csvtext += "\",";
                                }
                                else if (qcaux > contadorNulls)
                                {
                                    csvtext += "NULL\",";//poner un contador
                                    contadorNulls++;
                                }

                                
                            }
                        }

                    }
                    csvtext += "\n";
                }
                //aqui
                File.WriteAllText(filePath, csvtext);

            }

            return true;
        }

        public static string RemoveLineEndings(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();

            return value.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
        }
    }
}
