using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMonkeyImplementation
{
    class SurveyForm
    {

        public string id { get; set; }
        public string title { get; set; }
        public string preview { get; set; }
        public string language { get; set; }
        public string question_count { get; set; }
        public string page_count { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }

        public List<string> pagesIDs { get; set; }
        public SurveyForm() { }
    }
}
