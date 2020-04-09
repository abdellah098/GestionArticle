using System;
using System.Data;
using System.Data.SqlClient;
namespace CrudApp.Models
{
    public class Article
    {
        public int Reference { get; set; }
        public string Designation { get; set; }
        public string Categorie { get; set; }
        public float Prix { get; set; } 
        public int Quantite { get; set; }
        public string Promo { get; set; }

        public Article()
        {

        }   
        public Article(int Reference, string Designation, string Categorie, float Prix, int Quantite, string Promo )
        {
            this.Reference = Reference;
            this.Designation = Designation;
            this.Categorie = Categorie;
            this.Prix = Prix;
            this.Quantite = Quantite;
            this.Promo = Promo;
        }
        public Article(SqlDataReader dr)
        {
            this.Reference = (Int32)dr["Reference"];
            this.Designation = (String)dr["Designation"];
            this.Categorie = (String)dr["Categorie"];
            this.Prix = Convert.ToSingle(dr["Prix"]);
            this.Quantite = (Int32)dr["Quantite"];
            this.Promo = (String)dr["Promo"];
        }
    }
}