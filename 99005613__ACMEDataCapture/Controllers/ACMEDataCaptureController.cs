using ACMEDataCaptureBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _99005613__ACMEDataCapture.Controllers
{
    public class ACMEDataCaptureController : ApiController
    {

        ACMEBL blObj;
        [HttpGet]
        public HttpResponseMessage GetStudents()
        {
            try
            {
                blObj = new ACMEBL();
                var result = blObj.GetAllACME();
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No students found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }
        public HttpResponseMessage GetStudentsByName(string sName)
        {
            try
            {
                blObj = new ACMEBL();
                var result = blObj.GetAllStudentsByName(sName);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No products found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }
        [HttpPost]
        public HttpResponseMessage InsertACME(ACMEDTO newstuObj)
        {
            try
            {
                blObj = new ACMEBL();
                int result = blObj.AddNewStudent(newstuObj);
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "ACME added successfully");
                }
                else if (result == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "temp cannot be empty");
                }
                else if (result == -2)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "ACME precise_temp cannot be empty");
                }
                else if (result == -3)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "ACME coolingagent cannot be empty");
                }
                else if (result == -4)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "ACME dates cannot be empty");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Err error");
            }

        }
    }
}
