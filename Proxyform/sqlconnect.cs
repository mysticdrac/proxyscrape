/*
 * Created by SharpDevelop.
 * User: sonniepollak
 * Date: 10/27/2014
 * Time: 2:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace sqlconnect
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>

    public class sqlconnect
    {
        SQLiteConnection m_dbConnection;

        public sqlconnect(string data, string password)
        {
       
            if (!File.Exists(data))
            {
                SQLiteConnection.CreateFile(data);
                try
                {
                    m_dbConnection = new SQLiteConnection("Data Source=" + data + ";Version=3;");
                    m_dbConnection.Open();
                    m_dbConnection.ChangePassword(password);
                }
                catch(SQLiteException ex)
                {
                    Debug.WriteLine(ex.Message);


                }
            }
            else
            {
                try
                {
                    m_dbConnection = new SQLiteConnection("Data Source=" + data + "; Password=" + password);
                    m_dbConnection.Open();
                }
                catch (SQLiteException ex)
                {
                    Debug.WriteLine(ex.Message);


                }
            }
            //string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name='table_name'";
            string[] sqls = new string[]{
            "CREATE TABLE IF NOT EXISTS UrlListTmp(id INTEGER PRIMARY KEY,Url TEXT UNIQUE,Valid INT DEFAULT 0)",
            "CREATE TABLE IF NOT EXISTS ProxyListTmp(id INTEGER PRIMARY KEY,Ipport TEXT UNIQUE,Valid INT DEFAULT 0,Https INT DEFAULT 0,Google INT DEFAULT 0,Speed INT DEFAULT 0,Typeprox INT DEFAULT 0)",
            "CREATE TABLE IF NOT EXISTS UrlList(id INTEGER PRIMARY KEY,Url TEXT UNIQUE,Valid INT DEFAULT 0)",
            "CREATE TABLE IF NOT EXISTS ProxyList(id INTEGER PRIMARY KEY,Ipport TEXT UNIQUE,Valid INT DEFAULT 0,Https INT DEFAULT 0,Google INT DEFAULT 0,Speed INT DEFAULT 0,Typeprox INT DEFAULT 0)",
            "CREATE TABLE IF NOT EXISTS ProxyListFilter(id INTEGER PRIMARY KEY,Ipport TEXT UNIQUE,Valid INT DEFAULT 0,Https INT DEFAULT 0,Google INT DEFAULT 0,Speed INT DEFAULT 0,Typeprox INT DEFAULT 0)"

            //"CREATE INDEX UrlList_idx_1 on UrlList (url)",
            //"CREATE INDEX ProxyList_idx_1 on ProxyList (ipport)"

                      
            };


            foreach (string sql in sqls)
            {

                try
                {
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Debug.WriteLine(ex.Message);

                }

            }
        }

        public void close_dbConnection()
        {
            try
            {
                m_dbConnection.Close();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }

        public int Commit() {

            return m_dbConnection.Changes;
        }

        public int Count(string tablename,Hashtable hash) {

            string sql = null;
            string conditionstr = "";
            if (hash != null && hash.Count > 0)
            {
                foreach (DictionaryEntry entry in hash)
                {
                    if (entry.Value.GetType() == typeof(string))
                    {
                        conditionstr += entry.Key.ToString() + "='" + entry.Value.ToString() + "'" + " AND ";

                    }
                    else if (entry.Value.GetType() == typeof(int))
                    {
                        conditionstr += entry.Key.ToString() + "=" + entry.Value.ToString() + " AND ";


                    }


                }
                conditionstr = conditionstr.Remove(conditionstr.LastIndexOf(" AND "));
            }
            if (conditionstr.Trim() != "")
            {
                sql = string.Format("SELECT COUNT(id) FROM {0} WHERE {1}", tablename, conditionstr);
            }
            else {
                sql = string.Format("SELECT COUNT(id) FROM {0}",tablename);
            
            }
            SQLiteCommand SelectCommand;
            int count = 0;
            try
            {
                 
            
                SelectCommand = new SQLiteCommand(sql, m_dbConnection);
                count = Convert.ToInt32(SelectCommand.ExecuteScalar());

            }
            catch (SQLiteException) { 
            
            
            }

            return count;

        }

        public void insertBulk(string tablename,Hashtable[] hasharr) {
            foreach (Hashtable hash in hasharr) {
                insert(tablename, hash);
            
            }
        
        }
              
        public void insert(string tablename, Hashtable hash)
        {
            string keys="";
            string values="";
            foreach (DictionaryEntry entry in hash)
            {

                keys += entry.Key.ToString() + ",";

                if (entry.Value.GetType() == typeof(string))
                {
                    values += "'" + entry.Value.ToString() + "',";
                }
                else if(entry.Value.GetType() == typeof(int)) {
                    values +=  entry.Value.ToString() + ",";

                }
                else if (entry.Value.GetType() == typeof(DateTime))
                {
                    values += "'"+entry.Value.ToString() + "',";

                }


            }
            keys = keys.Remove(keys.LastIndexOf(","));
            values = values.Remove(values.LastIndexOf(","));
            string sqls = string.Format("INSERT OR IGNORE INTO {0}({1}) VALUES({2})", tablename, keys, values);

                   try
                    {
                        SQLiteCommand command = new SQLiteCommand(sqls, m_dbConnection);
                        command.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        Debug.WriteLine(ex.Message);

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);


                    }
 
        }

        public void delete(string tablename, Hashtable hash)
        {
            string deletestr = "";

            if (hash != null && hash.Count >0)
            {
                foreach (DictionaryEntry entry in hash)
                {
                    if (entry.Value.GetType() == typeof(string))
                    {
                        deletestr += entry.Key.ToString() + "='" + entry.Value.ToString() + "'" + " AND ";

                    }
                    else if (entry.Value.GetType() == typeof(int))
                    {
                        deletestr += entry.Key.ToString() + "=" + entry.Value.ToString() + " AND ";


                    }


                }
                deletestr = deletestr.Remove(deletestr.LastIndexOf(" AND "));
            }
            string sql = "";
            if (hash != null)
            {
               sql=string.Format("DELETE FROM {0} WHERE {1}", tablename, deletestr);
            }
            else {
                sql = string.Format("DELETE FROM {0}", tablename);

            }
                    try
                    {
                        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                        command.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        Debug.WriteLine(ex.Message);


                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);


                    }

                    
        }

        public void update(string tablename,Hashtable hash,Hashtable condition)
        {
            string updatestr = "";
            string conditionstr = "";
            foreach (DictionaryEntry entry in hash)
            {
                if (entry.Value.GetType() == typeof(string))
                {
                    updatestr += entry.Key.ToString() + "='" + entry.Value.ToString() + "'" + ",";

                }
                else if (entry.Value.GetType() == typeof(int))
                {
                    updatestr += entry.Key.ToString() + "=" + entry.Value.ToString() + ",";


                }


            }
            updatestr = updatestr.Remove(updatestr.LastIndexOf(","));

            foreach (DictionaryEntry entry in condition)
            {
                if (entry.Value.GetType() == typeof(string))
                {
                    conditionstr += entry.Key.ToString() + "='" + entry.Value.ToString() + "'" + " AND ";

                }
                else if (entry.Value.GetType() == typeof(int))
                {
                    conditionstr += entry.Key.ToString() + "=" + entry.Value.ToString() + " AND ";


                }


            }
            conditionstr = conditionstr.Remove(conditionstr.LastIndexOf(" AND "));


                    string sql = string.Format("UPDATE {0} SET {1} WHERE {2}",tablename,updatestr,conditionstr);
                    try
                    {
                        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                        command.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {

                    }
                    catch (Exception ex)
                    {


                    }

        }

        public List<Dictionary<string, object>> view2(string tablename, List<object[]> hash)
        {
            string conditionstr = "";
            object[] entry;
            if (hash != null && hash.Count > 0)
            {
                //foreach (DictionaryEntry entry in hash)
                for (int i = 0; i < hash.Count;i++ )
                {
                    entry = (object[])hash[i];
                    if (entry[0].ToString().ToLower().Equals("speed"))
                    {
                        if (entry[1].GetType() == typeof(int))
                        {
                            if ((int)entry[1] > 0)
                            {
                                conditionstr += entry[0].ToString() + ">=" + entry[1].ToString() + " AND ";


                            }
                            else
                            {
                                conditionstr += entry[0].ToString() + "<" + entry[1].ToString() + " AND ";


                            }

                        }


                    }
                    else
                    {

                        if (entry[1].GetType() == typeof(string))
                        {
                            conditionstr += entry[0].ToString() + "='" + entry[1].ToString() + "'" + " AND ";

                        }
                        else if (entry[1].GetType() == typeof(int))
                        {

                            conditionstr += entry[0].ToString() + "=" + entry[1].ToString() + " AND ";


                        }
                    }

                }
                conditionstr = conditionstr.Remove(conditionstr.LastIndexOf(" AND "));
            }
            string sql = "";
            if (conditionstr.Trim() != "")
            {
                sql = string.Format("SELECT * FROM {0} WHERE {1}", tablename, conditionstr);
            }
            else
            {

                sql = string.Format("SELECT * FROM {0}", tablename);
            }
            SQLiteCommand SelectCommand;
            SQLiteDataReader ResultReader;
            List<Dictionary<string, object>> list;
            Dictionary<string, object> objhash;
            try
            {
                SelectCommand = new SQLiteCommand(sql, m_dbConnection);
                ResultReader = SelectCommand.ExecuteReader();

                list = new List<Dictionary<string, object>>();
                int count = ResultReader.FieldCount;

                while (ResultReader.Read())
                {
                    //obj = new object[count];
                    // objhash = new Hashtable();
                    objhash = new Dictionary<string, object>();
                    for (int i = 0; i < count; i++)
                    {
                        //  var tas = ResultReader.GetFieldType(i);
                        if (ResultReader.GetFieldType(i) == typeof(Int64))
                        {
                            if (!ResultReader.IsDBNull(i))
                            {
                                // obj.SetValue(ResultReader.GetInt64(i), i);
                                objhash.Add(ResultReader.GetName(i), ResultReader.GetInt64(i));
                            }
                        }
                        else if (ResultReader.GetFieldType(i) == typeof(int))
                        {
                            if (!ResultReader.IsDBNull(i))
                            {
                                // obj.SetValue(ResultReader.GetInt32(i), i);
                                objhash.Add(ResultReader.GetName(i), ResultReader.GetInt32(i));
                            }
                        }
                        else if (ResultReader.GetFieldType(i) == typeof(string))
                        {
                            if (!ResultReader.IsDBNull(i))
                            {
                                //obj.SetValue(ResultReader.GetString(i), i);
                                objhash.Add(ResultReader.GetName(i), ResultReader.GetString(i));
                            }
                        }
                        else if (ResultReader.GetFieldType(i) == typeof(DateTime))
                        {
                            if (!ResultReader.IsDBNull(i))
                            {
                                //obj.SetValue(ResultReader.GetDateTime(i), i);
                                objhash.Add(ResultReader.GetName(i), ResultReader.GetDateTime(i));
                            }

                        }
                    }

                    //list.Add(obj);
                    list.Add(objhash);
                }

                return list;
            }
            catch (SQLiteException ex)
            {

                Debug.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }
            return null;
        }
 


        public List<Dictionary<string,object>> view(string tablename,Hashtable hash)
        {
            string conditionstr = "";
            if (hash != null && hash.Count >0)
            {
                foreach (DictionaryEntry entry in hash)
                {
                    if (entry.Value.GetType() == typeof(string))
                    {
                        conditionstr += entry.Key.ToString() + "='" + entry.Value.ToString() + "'" + " AND ";

                    }
                    else if (entry.Value.GetType() == typeof(int))
                    {
                        conditionstr += entry.Key.ToString() + "=" + entry.Value.ToString() + " AND ";


                    }


                }
                conditionstr = conditionstr.Remove(conditionstr.LastIndexOf(" AND "));
            }
            string sql ="";
            if (conditionstr.Trim() != "")
            {
                sql = string.Format("SELECT * FROM {0} WHERE {1}", tablename, conditionstr);
            }
            else {

                sql = string.Format("SELECT * FROM {0}", tablename);
            }
            SQLiteCommand SelectCommand;
            SQLiteDataReader ResultReader;
            List<Dictionary<string,object>> list;
            Dictionary<string,object> objhash;
            try
            {
                SelectCommand = new SQLiteCommand(sql, m_dbConnection);
                ResultReader = SelectCommand.ExecuteReader();

                list = new List<Dictionary<string,object>>();
                int count = ResultReader.FieldCount;
              
                while (ResultReader.Read())
                {
                    //obj = new object[count];
                   // objhash = new Hashtable();
                    objhash = new Dictionary<string, object>();
                    for (int i = 0; i < count; i++) 
                    {
                        if (ResultReader.GetFieldType(i) == typeof(Int64))
                        {
                            if (!ResultReader.IsDBNull(i))
                            {
                                objhash.Add(ResultReader.GetName(i),ResultReader.GetInt64(i));
                            }
                             }
                        else if(ResultReader.GetFieldType(i) == typeof(int)){
                            if (!ResultReader.IsDBNull(i))
                            {
                                objhash.Add(ResultReader.GetName(i),ResultReader.GetInt32(i));
                            }
                             }
                        else if (ResultReader.GetFieldType(i) == typeof(string)) {
                            if (!ResultReader.IsDBNull(i))
                            {
                                objhash.Add(ResultReader.GetName(i),ResultReader.GetString(i));
                            }
                        }
                        else if (ResultReader.GetFieldType(i) == typeof(DateTime)) {
                            if (!ResultReader.IsDBNull(i))
                            {
                                //obj.SetValue(ResultReader.GetDateTime(i), i);
                                objhash.Add(ResultReader.GetName(i),ResultReader.GetDateTime(i));
                            }

                         }
                    }

                    //list.Add(obj);
                    list.Add(objhash);
                }

                return list;
            }
            catch (SQLiteException ex)
            {

                Debug.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

            }
            return null;
        }
 
    }
}