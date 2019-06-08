using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hw2.Models
{
    public class Class1
    {
        private string getdbstring()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString();
        }
        public List<Models.Employees> getsql()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * 
                           FROM BOOK_DATA,BOOK_CLASS,BOOK_CODE 
                           WHERE BOOK_DATA.BOOK_CLASS_ID=BOOK_CLASS.BOOK_CLASS_ID AND BOOK_DATA.BOOK_STATUS=BOOK_CODE.CODE_ID";
            using (SqlConnection conn = new SqlConnection(this.getdbstring()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.putmodels(dt);
        }
        private List<Models.Employees> putmodels(DataTable employeeData)
        {
            List<Models.Employees> result = new List<Employees>();
            foreach (DataRow row in employeeData.Rows)
            {
                result.Add(new Employees()
                {
                    BOOK_NAME = row["BOOK_NAME"].ToString(),
                    BOOK_ID = row["BOOK_ID"].ToString(),
                    BOOK_CLASS_NAME = row["BOOK_CLASS_NAME"].ToString(),
                    BOOK_BOUGHT_DATE = row["BOOK_BOUGHT_DATE"].ToString(),
                    CODE_NAME = row["CODE_NAME"].ToString(),
                    BOOK_KEEPER = row["BOOK_KEEPER"].ToString()
                });
            }
            return result;
        }
        public void delet(string id)
        {
            try
            {
                string sql = "Delete FROM BOOK_DATA Where BOOK_ID=@id";
                using (SqlConnection conn = new SqlConnection(this.getdbstring()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void inser(string a, string b, string c, string d, string e, string f)
        {
            try
            {
                string sql = @"INSERT INTO BOOK_DATA
						 (
						    BOOK_NAME,BOOK_AUTHOR,
							BOOK_PUBLISHER,BOOK_NOTE,
							BOOK_BOUGHT_DATE,BOOK_CLASS_ID,
							BOOK_STATUS
						 )
						VALUES
						(
                            @a,@b,@c,@d,
							@e,@f,'A'
						)";
                using (SqlConnection conn = new SqlConnection(this.getdbstring()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@a", a));
                    cmd.Parameters.Add(new SqlParameter("@b", b));
                    cmd.Parameters.Add(new SqlParameter("@c", c));
                    cmd.Parameters.Add(new SqlParameter("@d", d));
                    cmd.Parameters.Add(new SqlParameter("@e", e));
                    cmd.Parameters.Add(new SqlParameter("@f", f));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(string i,string a, string b, string c, string d, string e, string f, string g, string h)
        {
            try
            {
                string sql = @"UPDATE dbo.BOOK_DATA
                                SET  BOOK_NAME=@a,
                                     BOOK_AUTHOR=@b,
                                     BOOK_PUBLISHER=@c,
                                     BOOK_NOTE=@d,
                                     BOOK_BOUGHT_DATE=@e,
                                     BOOK_CLASS_ID=@f,
                                     BOOK_STATUS=@g,
                                     BOOK_KEEPER=@h

                                WHERE BOOK_ID = @i";
                using (SqlConnection conn = new SqlConnection(this.getdbstring()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@a", a));
                    cmd.Parameters.Add(new SqlParameter("@b", b));
                    cmd.Parameters.Add(new SqlParameter("@c", c));
                    cmd.Parameters.Add(new SqlParameter("@d", d));
                    cmd.Parameters.Add(new SqlParameter("@e", e));
                    cmd.Parameters.Add(new SqlParameter("@f", f));
                    cmd.Parameters.Add(new SqlParameter("@g", g));
                    cmd.Parameters.Add(new SqlParameter("@h", h));
                    cmd.Parameters.Add(new SqlParameter("@i", i));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}