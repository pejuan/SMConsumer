using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMonkeyImplementation
{
    class ResponsePage
    {
        public string id { get; set; }
        public List<ResponseQuestion> questions { get; set; }
        //Lista de ResponseQuestion
        public ResponsePage() { }
    }
}
