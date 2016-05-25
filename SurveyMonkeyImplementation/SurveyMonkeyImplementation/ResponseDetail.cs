using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMonkeyImplementation
{
    class ResponseDetail
    {
        public string ip_address { get; set; }
        public string id { get; set; }
        public string date_modified { get; set; }
        public string response_status { get; set; }
        public string custom_value { get; set; }

        public ResponseDetail() { }
    }
}
