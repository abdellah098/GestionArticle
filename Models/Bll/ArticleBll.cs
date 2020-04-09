using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CrudApp;
using CrudApp.Models;
using CrudApp.Dal;
namespace CrudApp.Bll
{
    public class ArticleBll
    {
        public static List<Article> SeletAllArticles()
        {
            return ArticleDAL.SelectAll();
        }
        public static Article SelectArticle(int Reference)
        {
            return ArticleDAL.selectArticle(Reference);
        }
        public static void Update(Article P)
        {
            ArticleDAL.Update(P);
        }
        public static void Delete(int Reference)
        {
            ArticleDAL.Delete(Reference);
        }
        public static void Insert(Article P)
        {
            ArticleDAL.Insert(P);
        }
        public static List<Article> SearchArticles(string KeyWord)
        {
            return ArticleDAL.SearchArticles(KeyWord);
        }
    
    }
}