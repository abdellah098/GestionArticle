
 namespace CrudApp
 {
     public static class Config
     {
         public static string ConnectionString { get; set;}
         public static void SetConnectionString(string connectionString)
         {
             ConnectionString = connectionString;
         }
         public static string GetConnectionString()
         {
             return ConnectionString;
         }
     }
 }


