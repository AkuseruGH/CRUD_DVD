using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_DVD.model;

using System.Configuration;
using System.Data.SQLite;

namespace CRUD_DVD.lib
{
    internal class dataLogic
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        private static dataLogic _instance = null;

        public dataLogic()
        {

        }

        public static dataLogic Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new dataLogic();
                }
                return _instance;
            }
        }

        public bool save(data obj)
        {
            bool replies = true;
            using (SQLiteConnection conn = new SQLiteConnection(cadena))
            {
                conn.Open();
                string query = "insert into data(firstname,lastName,name_DVD,rental_date,deli_date) values (@firstname,@lastName,@name_DVD,@rental_date,@deli_date)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.Add(new SQLiteParameter("@firstname", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@lastName", obj.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@name_DVD", obj.name_DVD));
                cmd.Parameters.Add(new SQLiteParameter("@rental_date", obj.fecha_renta));
                cmd.Parameters.Add(new SQLiteParameter("@deli_date", obj.fecha_entrega));
                cmd.CommandType = System.Data.CommandType.Text;
                if(cmd.ExecuteNonQuery() < 1)
                {
                    replies = false;
                }
            }
            return replies;
        }

        public List<data> add()
        {
            List<data> list = new List<data>();
            using (SQLiteConnection conn = new SQLiteConnection(cadena))
            {
                conn.Open();
                string query = "select * from data";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new data()
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Nombre = reader["firstname"].ToString(),
                            Apellido = reader["lastName"].ToString(),
                            name_DVD = reader["name_DVD"].ToString(),
                            fecha_renta = reader["rental_date"].ToString(),
                            fecha_entrega = reader["deli_date"].ToString(),
                        });
                    }
                }
            }
            return list;
        }

        public bool updater(data obj)
        {
            bool replies = true;
            using (SQLiteConnection conn = new SQLiteConnection(cadena))
            {
                conn.Open();
                string query = "Update data set firstname = @firstname,lastName = @lastName, name_DVD = @name_DVD, rental_date = @rental_date , deli_date = @deli_date where ID = @ID";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.Add(new SQLiteParameter("@ID", obj.ID));
                cmd.Parameters.Add(new SQLiteParameter("@firstname", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@lastName", obj.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@name_DVD", obj.name_DVD));
                cmd.Parameters.Add(new SQLiteParameter("@rental_date", obj.fecha_renta));
                cmd.Parameters.Add(new SQLiteParameter("@deli_date", obj.fecha_entrega));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    replies = false;
                }
            }
            return replies;
        }

        public bool delete(data obj)
        {
            bool replies = true;
            using (SQLiteConnection conn = new SQLiteConnection(cadena))
            {
                conn.Open();
                string query = "delete from data where ID = @ID";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.Add(new SQLiteParameter("@ID", obj.ID));
                cmd.Parameters.Add(new SQLiteParameter("@firstname", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@lastName", obj.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@name_DVD", obj.name_DVD));
                cmd.Parameters.Add(new SQLiteParameter("@rental_date", obj.fecha_renta));
                cmd.Parameters.Add(new SQLiteParameter("@deli_date", obj.fecha_entrega));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    replies = false;
                }
            }
            return replies;
        }

        public bool deleteall(data obj)
        {
            bool replies = true;
            using (SQLiteConnection conn = new SQLiteConnection(cadena))
            {
                conn.Open();
                string query = "delete from data where ID = @ID";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.Add(new SQLiteParameter("@ID", obj.ID));
                cmd.Parameters.Add(new SQLiteParameter("@firstname", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@lastName", obj.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@name_DVD", obj.name_DVD));
                cmd.Parameters.Add(new SQLiteParameter("@rental_date", obj.fecha_renta));
                cmd.Parameters.Add(new SQLiteParameter("@deli_date", obj.fecha_entrega));
                cmd.CommandType = System.Data.CommandType.Text;
                if (cmd.ExecuteNonQuery() < 1)
                {
                    replies = false;
                }
            }
            return replies;
        }
    }
}
