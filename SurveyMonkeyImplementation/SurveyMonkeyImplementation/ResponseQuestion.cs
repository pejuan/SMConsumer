using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMonkeyImplementation
{
    class ResponseQuestion
    {

        public string id { get; set; }

        public List<ResponseAnswer> answers { get; set; }

        public ResponseQuestion() { }
        //lista de ResponseAnswers
    }
}
