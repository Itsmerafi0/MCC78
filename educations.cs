using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnection
{
    public class educations
    {
        public int id {  get; set; }
        public string major { get; set; }
        public string degree { get; set; }
        public string gpa { get; set; }
        public int university_id { get; set; }

            private static readonly string connectionString =
         "Data Source=RAFI;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


        public static int UpdateEducation(educations education)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_educations SET major = @major, degree = @degree, gpa = @gpa, university_id = @univ_id WHERE id = @id";
                command.Transaction = transaction;

                var pMajor = new SqlParameter();
                pMajor.ParameterName = "@major";
                pMajor.Value = education.major;

                var pDegree = new SqlParameter();
                pDegree.ParameterName = "@degree";
                pDegree.Value = education.degree;

                var pGpa = new SqlParameter();
                pGpa.ParameterName = "@gpa";
                pGpa.Value = education.gpa;

                var pUniversity_id = new SqlParameter();
                pUniversity_id.ParameterName = "@univ_id";
                pUniversity_id.Value = education.university_id;

                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = education.id;

                command.Parameters.Add(pGpa);
                command.Parameters.Add(pDegree);
                command.Parameters.Add(pMajor);
                command.Parameters.Add(pUniversity_id);
                command.Parameters.Add(pId);

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
        public static int DeleteEducation(educations educations)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_educations WHERE id = (@id)";
                command.Transaction = transaction;

                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = educations.id;

                command.Parameters.Add(pId);
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
        public static List<educations> GetEducation()
        {
            var educations = new List<educations>();
            using SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var education = new educations();
                        education.id = reader.GetInt32(0);
                        education.major = reader.GetString(1);
                        education.degree = reader.GetString(2);
                        education.gpa = reader.GetString(3);
                        education.university_id = reader.GetInt32(4);

                        educations.Add(education);
                    }
                    return educations;
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
            return new List<educations>();
        }
        public static int InsertEducation(educations educations)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_educations (major,degree,gpa,university_id) VALUES (@major, @Degree, @Gpa, @University_id)";
                command.Transaction = transaction;

                var pMajor = new SqlParameter();
                pMajor.ParameterName = "@major";
                pMajor.SqlDbType = SqlDbType.VarChar;
                pMajor.Size = 100;
                pMajor.Value = educations.major;
                command.Parameters.Add(pMajor);

                var pDegree = new SqlParameter();
                pDegree.ParameterName = "@Degree";
                pDegree.SqlDbType = SqlDbType.VarChar;
                pDegree.Size = 100;
                pDegree.Value = educations.degree;
                command.Parameters.Add(pDegree);

                var pGpa = new SqlParameter();
                pGpa.ParameterName = "@Gpa";
                pGpa.SqlDbType = SqlDbType.VarChar;
                pGpa.Size = 5;
                pGpa.Value = educations.gpa;
                command.Parameters.Add(pGpa);

                var pUniversity_id = new SqlParameter();
                pUniversity_id.ParameterName = "@University_id";
                pUniversity_id.SqlDbType = SqlDbType.Int;
                pUniversity_id.Value = educations.university_id;
                command.Parameters.Add(pUniversity_id);

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

