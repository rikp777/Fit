using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;


namespace Helpers
{
    public static class HelpFunctions
    {
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static T DatatableToObject<T>(this DataTable table) where T : class, new()
        {
            if (table.Rows.Count != 1) return null;
            
            try
            {
                T obj = new T();

                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        propertyInfo.SetValue(obj, Convert.ChangeType(table.Rows[0][prop.Name], propertyInfo.PropertyType), null);
                    }
                    catch
                    {
                        continue;
                    }
                }


                return obj;
            }
            catch
            {
                return null;
            }
        }
        
        public static bool nonQuery(string storedProcedureName, Dictionary<string, object> dict)
        {
            var success = false;
            try
            {
                using (var conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi409059;User Id=dbi409059;Password=Egt4gTSMOK;"))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(storedProcedureName))
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        if (dict != null)
                        {
                            foreach (var (key, value) in dict)
                            {
                                cmd.Parameters.AddWithValue(key, value);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                    success = true;
                }
            }
            catch (Exception sqlEx)
            {
                Console.WriteLine(@": Unable to establish a connection: {0} ", sqlEx);
                throw;
            }
            return success;
        }
        public static DataTable Query(string storedProcedureName, Dictionary<string, object> dict = null)
        {
            var datatable = new DataTable();
            try
            {
                using (var conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi409059;User Id=dbi409059;Password=Egt4gTSMOK;"))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("dbo." + storedProcedureName, conn) { CommandType = CommandType.StoredProcedure})
                    {   
                        
                        if (dict != null)
                        {
                            foreach (var (key, value) in dict)
                            {
                                cmd.Parameters.AddWithValue(key, value);
                            }
                        }
                        
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(datatable);
                        }
                    }

                }
            }
            catch (Exception sqlEx)
            {
                Console.WriteLine(@": Unable to establish a connection: {0} ", sqlEx);
                throw;
            }

            return datatable;
        }

        
    }
}