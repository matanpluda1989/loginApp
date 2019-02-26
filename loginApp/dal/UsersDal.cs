using loginApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace loginApp.DAL
{
    public class UsersDal
    {
        public List<User> GetAll()
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {


                        da.SelectCommand = new SqlCommand("GetAll", conn);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        List<User> users =  ds.Tables[0].AsEnumerable().Select(dataRow => new User
                        {
                            _id = dataRow.Field<int>("Id"),
                            _name = dataRow.Field<string>("Name") ,
                            _phone = dataRow.Field<string>("Phone"),
                            _birthDay = dataRow.Field<DateTime>("BirthDate"),
                            _gender = dataRow.Field<string>("Gender"),
                            _mail = dataRow.Field<string>("Mail"),
                        }).ToList();
                        return users;
                    }
                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(User user)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("dbo.InsertUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        var parameterName = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                        var parameterPhone = new SqlParameter("@Phone", SqlDbType.NVarChar, 10);
                        var parameterBirthDate = new SqlParameter("@BirthDate", SqlDbType.DateTime);
                        var parameterMail = new SqlParameter("@Mail", SqlDbType.NVarChar);
                        var parameterGender = new SqlParameter("@Gender", SqlDbType.NVarChar);

                        parameterName.Value = user._name;
                        parameterPhone.Value = user._phone;
                        parameterBirthDate.Value = user._birthDay;
                        parameterGender.Value = user._gender;
                        parameterMail.Value = user._mail;


                        cmd.Parameters.Add(parameterName);
                        cmd.Parameters.Add(parameterPhone);
                        cmd.Parameters.Add(parameterMail);
                        cmd.Parameters.Add(parameterBirthDate);
                        cmd.Parameters.Add(parameterGender);

                        
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;          
            }
        }
    }
}