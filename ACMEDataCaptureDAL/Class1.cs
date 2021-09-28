using ACMEDataCaptureDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEDataCaptureDAL
{
    public class ACMEDAL
    {
        string conStr = ConfigurationManager.ConnectionStrings["ACMEdb"].ConnectionString;
        public List<ACMEDTO> FetchAllACME()
        {
            List<ACMEDTO> lstACME = new List<ACMEDTO>();

            //SqlConnection conObj = new SqlConnection(@"data source = (localdb)\ProjectsV13; database = ACMEDatabase; integrated security = SSPI");
            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;

            SqlCommand queryObj = new SqlCommand();
            queryObj.CommandText = @"SELECT temp,precise_temp FROM dbo.Datarecieved";
            queryObj.CommandType = System.Data.CommandType.Text;
            queryObj.Connection = conObj;
            try
            {
                conObj.Open();
                SqlDataReader drStudent = queryObj.ExecuteReader();
                while (drACME.Read())
                {
                    lstACME.Add(new ACMEDTO()
                    {
                        temp = drStudent["temp"].ToString(),
                        precise_temp = drStudent["precise_temp"].ToString()
                    });
                }
                return lstACME;
            }
            catch (Exception ex)
            {
                throw ex;
                /* Console.WriteLine("Oops something went wrong");
                 Console.WriteLine(ex.Message);*/
            }
            /*finally
            {
                conObj.Close();
                Console.WriteLine(conObj.State);
                Console.ReadKey();
            }*/
        }
        public List<ACMEDTO> FetchAllACMEByName(string ACMEName)
        {
            List<ACMEDTO> lstACME = new List<ACMEDTO>();

            //SqlConnection conObj = new SqlConnection(@"data source = (localdb)\ProjectsV13; database = AdventureWorks2012; integrated security = SSPI");
            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;

            SqlCommand queryObj = new SqlCommand();
            queryObj.CommandText = @"SELECT firstName,lastName FROM dbo.student WHERE firstName LIKE @studentName";
            queryObj.Parameters.AddWithValue("@ACMEName", "%" + ACMEName + "%");
            queryObj.CommandType = System.Data.CommandType.Text;
            queryObj.Connection = conObj;
            try
            {
                conObj.Open();
                SqlDataReader drACME = queryObj.ExecuteReader();
                while (drACME.Read())
                {
                    lstACME.Add(new ACMEDTO()
                    {
                        temp = drACME["temp"].ToString(),
                        precise_temp = drACME["precise_temp"].ToString()
                    });
                }
                return lstACME;
            }
            catch (Exception ex)
            {
                throw ex;
                /* Console.WriteLine("Oops something went wrong");
                 Console.WriteLine(ex.Message);*/
            }
            /*finally
            {
                conObj.Close();
                Console.WriteLine(conObj.State);
                Console.ReadKey();
            }*/
        }
        public int InsertNewACME(ACMEDTO stuObj)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_AddNewACME";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;
                queryObj.Parameters.AddWithValue("@temp", stuObj.temp);
                queryObj.Parameters.AddWithValue("@precise_temp", stuObj.precise_temp);
                queryObj.Parameters.AddWithValue("@coolingagent", stuObj.coolingagent);
                queryObj.Parameters.AddWithValue("@dates", stuObj.dates);
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}      