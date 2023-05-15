using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnection
{
    public class profilings
    {
        public string employee_id { get; set; }
        public int education_id { get; set; }

        private static readonly string connectionString =
"Data Source=RAFI;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public static List<profilings> GetProfilings()
        {
            var pro = new List<profilings>();
            using SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Profillings";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var prof = new profilings();
                        prof.employee_id = reader.GetGuid(0).ToString();
                        prof.education_id = reader.GetInt32(1);

                        pro.Add(prof);
                    }
                    return pro;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return new List<profilings>();
        }
        public static int InsertProfiling(profilings profiling)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var employee = new Employees();
            var education = new educations();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_tr_profilings(employee_id, education_id) VALUES (@EmployeeId, @EducationId)";
                command.Transaction = transaction;

                var pEmpId = new SqlParameter();
                pEmpId.ParameterName = "@EmployeeId";
                pEmpId.Value = profiling.employee_id;
                command.Parameters.Add(pEmpId);

                var pEduId = new SqlParameter();
                pEduId.ParameterName = "@EducationId";
                pEduId.Value = profiling.education_id;
                command.Parameters.Add(pEduId);

                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }

            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
