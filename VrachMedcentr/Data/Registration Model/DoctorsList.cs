using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrachMedcentr
{
    class DoctorsList
    {
        public List<DocNames> Likar { get; set; }

        public string specf { get; set; }
        public int idspecf { get; set; }



    }
    public class DocNames
    {
        public bool docBool { get; set; }
        public string docName { get; set; }
        public string docID { get; set; }
        public string docEmail { get; set; }
        public string docTimeId { get; set; }
        public string docCab { get; set; }

    }


}
