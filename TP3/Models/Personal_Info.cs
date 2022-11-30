using System.Diagnostics;
using System.Data.SQLite;
using System.Collections;



namespace TP3.Models
{
    public class Personal_Info
    {
        private List<Personne> pers_info  ;

        private SQLiteConnection connection;

        public List<Personne> Pers_info { get ; set ; }

        public Personal_Info()
        {
            Pers_info = new List<Personne>();
            Debug.WriteLine("Se connecte a la bd en cours ");
            connection = new SQLiteConnection("Data Source=./SQLitedatabase.db");
            connection.Open();
            Debug.WriteLine("Connectée ! ");
        }

    public Personne GetPerson(int id)
        {
            Personne p=null;
            using (connection)
            {
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * from  personal_info  WHERE id=$id";
                command.Parameters.AddWithValue("$id", id);

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    p = new Personne((int)reader["id"], (string)reader["first_name"], (string)reader["last_name"], (string)reader["email"], (string)reader["image"], (string)reader["country"]);
                    Debug.WriteLine(p);
                }

            }
            return p;
        }

        public List<Personne> GetAllPerson()
        {
            
            using (connection)
            {

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * from  personal_info";
                var reader = command.ExecuteReader();


                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];

                        var p = new Personne(id, first_name, last_name, email, image, country);

                        Pers_info.Add(p);
                    }
                }
                return Pers_info;
            }

           

        } }
    
}
