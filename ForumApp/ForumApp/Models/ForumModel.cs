using System;
namespace ForumApp.Models
{
    public class ForumModel
    {
        public ForumModel()
        {
        }
        public int Id { get; set; }
        public string  Title { get; set; }
        public string  FullDescription { get; set; }
        public String CreationDate { get; set; }
        public string User { get; set; }
    }
}
