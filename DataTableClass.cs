using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.ComponentModel.Design;

namespace SqlServerWithDataTable
{
    internal class DataTableClass
    {
        public void DataTableIteration()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Student", conn);
                DataTable dt = new DataTable(); // Create instance of the DataTAable
                da.Fill(dt);

                WriteLine("Student table: ");
                foreach(DataRow select in dt.Rows)
                {
                    WriteLine(select["id"] + " | " + select["name"] + " | " + select["email"] + " | " + select["mobile"]);
                }
                WriteLine();
            }
            catch(Exception ex)
            {
                WriteLine("Đã có lỗi xảy ra!!! " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void CopyAndClone()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Student", conn);
                // create instance DataTable
                DataTable dt = new DataTable();
                da.Fill(dt);
                WriteLine("Copy And Clone");
                WriteLine("------- Dữ liệu của bảng hiện tại --------");
                foreach(DataRow select in dt.Rows)
                {
                    WriteLine(select["id"] + " | " + select["name"] + " | " + select["email"] + " | " + select["mobile"]);
                }

                WriteLine();

                WriteLine("-------- Dữ liệu của bảng Copy ------------");
                DataTable dtCopy = dt.Copy();
                if(dtCopy != null)
                {
                    foreach(DataRow select in dtCopy.Rows)
                    {
                        WriteLine(select["id"] + " | " + select["name"] + " | " + select["email"] + " | " + select["mobile"]);
                    }
                }

                WriteLine();

                WriteLine("--------- Dữ liệu của bảng Clone -------------");
                DataTable dtClone = dt.Clone();
                if(dtClone.Rows.Count > 0)
                {
                    foreach(DataRow select in dtClone.Rows)
                    {
                        WriteLine(select["id"] + " | " + select["name"] + " | " + select["email"] + " | " + select["mobile"]);
                    }
                    WriteLine();
                }
                else
                {
                    WriteLine("Dữ liệu trong bảng Clone đang trống!");
                }
                WriteLine();

            }
            catch (Exception ex) 
            {
                WriteLine("Đã có lỗi xảy ra!!! " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void DataTableDelete()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Student", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                WriteLine("------------ Delete --------------");
                WriteLine("------------ Dữ liệu trước khi xoá: ---------------");
                foreach(DataRow select in dt.Rows)
                {
                    WriteLine(select["id"] + " | " + select["name"] + " | " + select["email"] + " | " + select["mobile"]);
                }
                WriteLine();
                // tìm id để xoá
                foreach(DataRow select in dt.Rows)
                {
                    if (Convert.ToInt32(select["id"]) == 101)
                    {
                        select.Delete();
                        WriteLine("Student has id is 101 deleted!");
                    }
                }
                dt.AcceptChanges();
                WriteLine();
                WriteLine("Data after deleted");
                foreach(DataRow select in dt.Rows)
                {
                    WriteLine(select["id"] + " | " + select["name"] + " | " + select["email"] + " | " + select["mobile"]);
                }
                WriteLine();
            }
            catch(Exception ex)
            {
                WriteLine("Đã có lỗi xảy ra!!! " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void DataTableRemove()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Student", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                WriteLine("----------- Remove ------------");
                WriteLine("------------ Dữ liệu trước khi xoá: ------------");
                foreach(DataRow select in dt.Rows)
                {
                    WriteLine(select["id"] + " | " + select["name"] + " | " + select["email"] + " | " + select["mobile"]);
                }
                WriteLine();
                foreach(DataRow select in dt.Select())
                {
                    if (Convert.ToInt32(select["id"]) == 102)
                    {
                        dt.Rows.Remove(select);
                        WriteLine("Student has been id = 102 deleted");
                    }
                }
                
                WriteLine();
                WriteLine("---------------- Dữ liệu sau khi xoá ------------------");
                foreach(DataRow select in dt.Rows)
                {
                    WriteLine(select["id"] + " | " + select["name"] + " | " + select["email"] +  " | " + select["mobile"]);
                }
                WriteLine();
            }
            catch(Exception ex)
            {
                WriteLine("Has been error! " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
