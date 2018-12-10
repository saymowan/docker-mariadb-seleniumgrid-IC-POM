using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.Uteis.Helper
{
    public class ConexaoBD
    {

        public static MySqlConnection GetDBConnection()
        {
            string connectionString = "Server=" + ConfigurationManager.AppSettings["DatabaseServer"] + ";" +
                                      "Port=" + ConfigurationManager.AppSettings["Port"] + ";" +
                                      "Database=" + ConfigurationManager.AppSettings["DatabaseName"] + ";" +
                                      "UID=" + ConfigurationManager.AppSettings["DBUser"] + "; " +
                                      "Password=" + ConfigurationManager.AppSettings["DBPassword"] + ";" +
                                      "SslMode="+ ConfigurationManager.AppSettings["SslMode"];
            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }

  
        public void DBRunQuery(string query)
        {

            //string x = "Server=192.168.99.100;Port = 3306; Database=bugtracker;UID=mantisbt;Password=mantisbt;SslMode=none";

            using (MySqlCommand cmd = new MySqlCommand(query, GetDBConnection()))
            {    //watch out for this SQL injection vulnerability below
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                cmd.Connection.Close();
            }

        }

        public void criarProjetoCarga()
        {
            string query_project = "select id from mantis_project_table order by id desc limit 1;";
            string id_project = string.Empty;

            MySqlCommand cmd = new MySqlCommand(query_project, GetDBConnection());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id_project = reader.GetString(0);
            }
            cmd.Connection.Close();

            //verifica se tem projeto
            if (id_project.Equals(string.Empty))
            {
                id_project = criarNovoProjetoDB();
            }
        }

        public List<string> cargaTarefas()
        {
            string query_project = "select id from mantis_project_table order by id desc limit 1;";
            string query_tasks_project = string.Empty;
            string query_insert_tasks_project = string.Empty;
            string query_insert_tasks = string.Empty;
            string id_project = string.Empty;
            string id_task = string.Empty;
            var rtList = new List<string>();

            MySqlCommand cmd = new MySqlCommand(query_project, GetDBConnection());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id_project = reader.GetString(0);
            }
            cmd.Connection.Close();

            //verifica se tem projeto
            if (id_project.Equals(string.Empty))
            {
                id_project = criarNovoProjetoDB();
            }

            rtList.Add(id_project);


            query_tasks_project = "select id from mantis_bug_table where project_id = '" + id_project + "' order by id desc limit 1";
            cmd = new MySqlCommand(query_tasks_project, GetDBConnection());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id_task = reader.GetString(0);
            }
            cmd.Connection.Close();


            if (id_task.Equals(string.Empty))
            {
                query_insert_tasks_project = @"INSERT INTO `mantis_bug_table` (`id`, `project_id`, `reporter_id`, `handler_id`, `duplicate_id`, `priority`, `severity`, `reproducibility`, `status`, `resolution`, `projection`, `eta`, `bug_text_id`, `os`, `os_build`, `platform`, `version`, `fixed_in_version`, `build`, `profile_id`, `view_state`, `summary`, `sponsorship_total`, `sticky`, `target_version`, `category_id`, `date_submitted`, `due_date`, `last_updated`) VALUES
            (1, 1, 1, 1, 0, 30, 50, 70, 50, 10, 10, 10, 1, '', '', '', '', '', '', 0, 10, 'Resumo teste', 0, 0, '', 1, 1538000103, 1, 1538000103),
	        (2, 1, 1, 0, 0, 30, 80, 70, 10, 10, 10, 10, 2, '', '', '', '', '', '', 0, 10, 'Resumo teste 2', 0, 0, '', 1, 1538000823, 1, 1538000823),
	        (3, 1, 1, 0, 0, 30, 50, 70, 10, 10, 10, 10, 3, '', '', '', '', '', '', 0, 10, 'Resumo teste 3', 0, 0, '', 1, 1538000859, 1, 1538000859);";

                rtList.Add("Resumo teste ");
                rtList.Add("Resumo teste 2");
                rtList.Add("Resumo teste 3");
            }
            else
            {
                query_insert_tasks_project = @"INSERT INTO `mantis_bug_table` (`id`, `project_id`, `reporter_id`, `handler_id`, `duplicate_id`, `priority`, `severity`, `reproducibility`, `status`, `resolution`, `projection`, `eta`, `bug_text_id`, `os`, `os_build`, `platform`, `version`, `fixed_in_version`, `build`, `profile_id`, `view_state`, `summary`, `sponsorship_total`, `sticky`, `target_version`, `category_id`, `date_submitted`, `due_date`, `last_updated`) VALUES
            ("+ (Int32.Parse(id_task) + 1) + $@", 1, 1, 1, 0, 30, 50, 70, 50, 10, 10, 10, 1, '', '', '', '', '', '', 0, 10, 'Resumo teste " + (Int32.Parse(id_task) + 1) + $@"', 0, 0, '', 1, 1538000103, 1, 1538000103),
	        ("+ (Int32.Parse(id_task) + 2) + $@", 1, 1, 0, 0, 30, 80, 70, 10, 10, 10, 10, 2, '', '', '', '', '', '', 0, 10, 'Resumo teste " + (Int32.Parse(id_task) + 2) + $@"', 0, 0, '', 1, 1538000823, 1, 1538000823),
	        ("+ (Int32.Parse(id_task) + 3) + $@", 1, 1, 0, 0, 30, 50, 70, 10, 10, 10, 10, 3, '', '', '', '', '', '', 0, 10, 'Resumo teste " + (Int32.Parse(id_task) + 3) + $@"', 0, 0, '', 1, 1538000859, 1, 1538000859);";

                rtList.Add("Resumo teste " + (Int32.Parse(id_task) + 1).ToString());
                rtList.Add("Resumo teste " + (Int32.Parse(id_task) + 2).ToString());
                rtList.Add("Resumo teste " + (Int32.Parse(id_task) + 3).ToString());
            }

            cmd = new MySqlCommand(query_insert_tasks_project, GetDBConnection());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return rtList;
        }

        public string criarNovoProjetoDB()
        {
            string query = @"INSERT INTO `mantis_project_table` (`id`, `name`, `status`, `enabled`, `view_state`, `access_min`, `file_path`, `description`, `category_id`, `inherit_global`) VALUES
                                (1, 'Projeto de teste', 10, 1, 10, 10, '', '', 1, 1);";
            MySqlCommand cmd = new MySqlCommand(query, GetDBConnection());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return "1";
        }

      



    }// fim class
}// fim namespce
