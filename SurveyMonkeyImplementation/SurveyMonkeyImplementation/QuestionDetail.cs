using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMonkeyImplementation
{
    class QuestionDetail
    {
        public string family { get; set; }
        public string subtype { get; set; }
        public Answer answers { get; set; }

        public string page_id { get; set; }
        public QuestionDetail() { }
    }
}
