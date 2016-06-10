using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMonkeyImplementation
{
    class Answer
    {
        public List<Choice> choices { get; set; }
        public List<Row> rows { get; set; }
        public Answer() { }
    }
}
