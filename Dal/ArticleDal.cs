using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CrudApp;
using CrudApp.Models;

namespace  CrudApp.Dal
{
    public class ArticleDAL
    {
        public static int Insert(Article P)
        {
            int InsertResult;
            using (var Con = new  SqlConnection(Config.GetConnectionString()))
            {
            string SqlInsert = "insert into Articles (Reference, Designation, Categorie,Prix, Quantite, Promo ) values (@Reference,@Designation,@Categorie,@Prix,@Quantite,@Promo)";
            Con.Open();
            SqlCommand Cmd = new SqlCommand(SqlInsert,Con);
            Cmd.Parameters.AddWithValue("@Reference",P.Reference);
            Cmd.Parameters.AddWithValue("@Designation",P.Designation);
            Cmd.Parameters.AddWithValue("@categorie",P.Categorie);
            Cmd.Parameters.AddWithValue("@prix",P.Prix);
            Cmd.Parameters.AddWithValue("@promo",P.Promo);
            Cmd.Parameters.AddWithValue("@Quantite",P.Quantite);
            
            InsertResult =  Cmd.ExecuteNonQuery();
            }

            return InsertResult;
        }
        public static int Update(Article P)
        {
            int UpdateResult;
            using (var Con = new SqlConnection(Config.GetConnectionString()))
            {
                 Con.Open();
                 var Cmd = new SqlCommand();
                 Cmd.Connection = Con;
                 Cmd.CommandText = @"update Articles set Designation = @Designation,Categorie = @Categorie,Prix = @Prix,Promo = @Promo, Quantite = @Quantite
                                   where Reference = @Reference ";
                                  
                 Cmd.Parameters.AddWithValue("Designation",P.Designation);
                 Cmd.Parameters.AddWithValue("Categorie",P.Categorie);
                 Cmd.Parameters.AddWithValue("Prix",P.Prix);
                 Cmd.Parameters.AddWithValue("Promo",P.Promo);
                 Cmd.Parameters.AddWithValue("Quantite",P.Quantite);
                 Cmd.Parameters.AddWithValue("Reference",P.Reference);
            
                 UpdateResult =  Cmd.ExecuteNonQuery();
            }
            
            return UpdateResult;
        }
        public static int Delete(int Reference)
        {
           int DeleteResult;
           using (var Con = new SqlConnection(Config.GetConnectionString()))
            {
                Con.Open();
                string Query = "delete from Articles Where Reference = @Reference";
                var Cmd = new SqlCommand(Query);
                Cmd.Connection = Con;
                
                Cmd.Parameters.AddWithValue("Reference",Reference);
                DeleteResult = Cmd.ExecuteNonQuery();
            }
            
            return DeleteResult;
        }
        public static Article selectArticle(int Reference)
        {
            Article P = new Article();
            using (var Con = new SqlConnection(Config.GetConnectionString()))
            {
                Con.Open();
                string Query = "select *  from Articles where Reference = @Reference";
                SqlCommand Cmd = new SqlCommand(Query,Con);
                Cmd.Parameters.AddWithValue("Reference",Reference);
                
                using(var Reader = Cmd.ExecuteReader())
                {               
                    if (Reader == null)
                    {
                        P = null;
                    }
                    
                    if (Reader.Read())
                    {
                        P = new Article(Reader);
                    }   
                }
            }
            return P;
        }
        public static List<Article> SelectAll()
        {
            List<Article> LesArticles;
            using (var Con = new SqlConnection(Config.GetConnectionString()))
            {
                Con.Open();
                var Query = "select * from Articles";
                var Cmd = new SqlCommand(Query,Con);

                using (var Reader = Cmd.ExecuteReader())
                {
                    if(Reader == null)
                    {
                        LesArticles = null;
                    }
                    else
                    {
                        LesArticles = new List<Article>();
                        while (Reader.Read())
                        {
                            var P = new Article(Reader);
                            LesArticles.Add(P);
                        }
                    }
                }
            }
            
            return LesArticles;

        }
        public static List<Article> SearchArticles(string KeyWord)
        {
             List<Article> LesArticles;
             using (var Con = new SqlConnection(Config.GetConnectionString()))
             {
                 Con.Open();
                 var Query = "select * from [Articles] where [Designation] LIKE '%@KeyWord%'  or  [Categorie] LIKE '%@KeyWord%'";
                 var Cmd = new SqlCommand(Query,Con);
                 Cmd.Parameters.AddWithValue("@KeyWord",KeyWord);

                using (var Reader = Cmd.ExecuteReader())
                {
                    if(Reader == null)
                    {
                        LesArticles = null;
                    }
                    else
                    {
                        LesArticles = new List<Article>();
                        while (Reader.Read())
                        {
                            var P = new Article(Reader);
                            LesArticles.Add(P);
                        }
                    }
                }
            }

            return LesArticles;
        }
        
    }
}