using ACMEDataCaptureDAL;
using ACMEDataCaptureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEDataCaptureBL
{
    public class ACMEBL
    {
        ACMEDAL dalObj = new ACMEDAL();
        public List<ACMEDTO> GetAllACME()
        {
            return dalObj.FetchAllACME();
        }
        public List<ACMEDTO> GetAllACMEByName(string sName)
        {
            return dalObj.FetchAllACMEByName(sName);
        }
        public int AddNewACME(ACMEDTO acmeObj)
        {
            return dalObj.InsertNewACME(acmeObj);
        }
       
    }
}
