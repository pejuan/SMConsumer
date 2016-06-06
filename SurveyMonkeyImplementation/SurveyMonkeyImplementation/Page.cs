using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMonkeyImplementation
{
    class Page
    {
        public string id { get; set; }
        public string position { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public List<QuestionDetail> questions { get; set; }
        public int question_count { get; set; }//Este atributo es traido solo en el metodo GetPageQuestionCount

        public Page() {}
    }
}
