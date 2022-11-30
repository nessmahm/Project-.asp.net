using System.Diagnostics;

namespace TP3.Models
{
    public class Personne
    {
        private int id;
        private string first_name;
        private string last_name;
        private string email;
        private string date_birth = "16/9/2001";
        private string image;
        private string country;

        public Personne(int id, string first_name, string last_name, string email, string image, string country)
        {
            this.Id = id;
            this.First_name = first_name;
            this.Last_name = last_name;
            this.Email = email;
            this.Image = image;
            this.Country = country;
        }

        public int Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Email { get => email; set => email = value; }
        public string Date_birth { get => date_birth; set => date_birth = value; }
        public string Image { get => image; set => image = value; }
        public string Country { get => country; set => country = value; }

        public override string? ToString()
        {
            return  " id = "+ id +", first name = "+ first_name + ", last name = " +last_name +  ", email = "+ email+ ", image = "+ image + ", country = "+country ;
        }
    }
}
