using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Core
{
    public class Article
    {

        public string Id { get; set; }
        public  bool IsActive { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }



    }
}
