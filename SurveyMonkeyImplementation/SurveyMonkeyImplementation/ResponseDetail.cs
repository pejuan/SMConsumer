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
        public string total_time { get; set; }
        public string recipient_id { get; set; }
        public string collector_id { get; set; }
        public string date_created { get; set; }
        public string survey_id { get; set; }
        public string collection_mode { get; set; }


        public List<ResponsePage> pages { get; set; }
        public ResponseDetail() { }
    }
}
