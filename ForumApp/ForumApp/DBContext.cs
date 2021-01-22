using System;
using ForumApp.Models;
using System.Collections.Generic;

namespace ForumApp
{
    //Encapsulates the access to the database
    public class DBContext
    {
        private const string _connString = @"Server =.\MyServer; Database = MyDB; Trusted_Connection = True;";

        private List<ForumModel> _posts;

        public DBContext()
        {
        }

        public List<HomeModel> GetUsers()
        {
    
            List<HomeModel> users = new List<HomeModel>();
            /*
             try
             {
                 //sql connection object
                 using (SqlConnection conn = new SqlConnection(_connString))
                 {

                     //retrieve the SQL Server instance version
                     string query = @"SELECT userName, password, Id
                                  FROM Users;
                                  ";
                     //define the SqlCommand object
                     SqlCommand cmd = new SqlCommand(query, conn);

                     //open connection
                     conn.Open();

                     //execute the SQLCommand
                     SqlDataReader dr = cmd.ExecuteReader();



                     //check if there are records
                     if (dr.HasRows)
                     {
                         while (dr.Read())
                         {

                             string user = dr.GetString(0);
                             string password = dr.GetString(1);
                             int id = int32.parse(dr.GetString(2));
                             users.Add(new HomeModel() { Id = id, UserName = user, Password = password });
                         }
                     }
                     else
                     {
                         throw new Exception("No data found.");
                     }

                     //close data reader
                     dr.Close();

                     //close connection
                     conn.Close();
                     return List;
                 }
             }
             catch (Exception ex)
             {

                 throw;
             }
           */
            // for testing purposes
            users = new List<HomeModel>
                {
                    new HomeModel() { UserName="lms", Password="123" }
                };
            return users;
        }


        public List<ForumModel> GetPosts()
        {
            /*
             try
             {
                 //sql connection object
                 using (SqlConnection conn = new SqlConnection(_connString))
                 {

                     //retrieve the SQL Server instance version
                     string query = @"SELECT forumPost.id forumPost.title, forumPost.fulldescription, forumPost.creationdDate, Users.userName 
                                       FROM forumPost;
                                       INNER JOIN forumPost.userId = Users.id;";
                     //define the SqlCommand object
                     SqlCommand cmd = new SqlCommand(query, conn);

                     //open connection
                     conn.Open();

                     //execute the SQLCommand
                     SqlDataReader dr = cmd.ExecuteReader();


                    _posts = new List<ForumModel>();
                     //check if there are records
                     if (dr.HasRows)
                     {
                         while (dr.Read())
                         {
                             int    id = int32.parse(dr.GetString(0));
                             string title = dr.GetString(1);
                             string fullDescription = dr.GetString(2);
                             string creationDate  = dr.GetString(3);
                             string userName = dr.GetString(4);
                             _posts.Add(new ForumModel() { Id = id, Title = title, FullDescription = fullDescription,
                                        CreationDate = creationDate, UserName = userName});
                         }
                     }
                     else
                     {
                         throw new Exception("No data found.");
                     }

                     //close data reader
                     dr.Close();

                     //close connection
                     conn.Close();
                     return List;
                 }
             }
             catch (Exception ex)
             {

                 throw;
             }
             */
            // for testing purposes
            if (_posts == null)
            {
                _posts = new List<ForumModel>();
                _posts.Add(new ForumModel()
                {
                    Id = 1,
                    Title = "FIRST Post",
                    FullDescription = "Details of the first post",
                    CreationDate = DateTime.Now.ToShortDateString(),
                    User = "lms"
                }); ;
                _posts.Add(new ForumModel()
                {
                    Id = 2,
                    Title = "SECOND Post",
                    FullDescription = "Details of the second post",
                    CreationDate = DateTime.Now.ToShortDateString(),
                    User = "rgb"
                });
                _posts.Add(new ForumModel()
                {
                    Id = 3,
                    Title = "THIRD Post",
                    FullDescription = "Details of the third post",
                    CreationDate = DateTime.Now.ToShortDateString(),
                    User = "lms"
                });
            }
            return _posts;
        }

        public void InsertPost(ForumModel model, string user)
        {
            /*
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO forumPost (title,fullDescription,creationDate, useriD) VALUES (@title,@fullDescription,@creationDate, @useriD)";
                int userId = GetUsers().Find(u => u.UserName == user).Id;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", model.Title);
                    command.Parameters.AddWithValue("@fullDescription", model.FullDescription);
                    command.Parameters.AddWithValue("@creationDate", model.CreationDate);
                    command.Parameters.AddWithValue("@useriD", userId);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        throw new Exception("Error inserting data into Database!");
                }
            }
            */

            // for testing purposes
            model.Id = GetPosts().Count + 1;
            model.CreationDate = DateTime.Now.ToShortDateString();
            model.User = user;
            //Insert in database
            GetPosts().Add(model);
        }

        public void UpdatePost(ForumModel model)
        {
            /*
          using (SqlConnection connection = new SqlConnection(_connectionString))
          {
              String query = "INSERT INTO forumPost (title,fullDescription,creationDate, useriD) VALUES (@title,@fullDescription,@creationDate, @useriD)";
              query = "Update forumPost set titte='"model.Title"+"', fullDescription='"+ model.fullDescription +"' where id=" + model.Id;

              using (SqlCommand command = new SqlCommand(query, connection))
              {
                  connection.Open();
                  int result = command.ExecuteNonQuery();

                  // Check Error
                  if (result < 0)
                      throw new Exception("Error inserting data into Database!");
              }
          }
          */
            // for testing purposes
         ForumModel post = GetPosts().Find(p => p.Id == model.Id);
         post.Title = model.Title;
         post.FullDescription = model.FullDescription;
                    
        }
    }
}
