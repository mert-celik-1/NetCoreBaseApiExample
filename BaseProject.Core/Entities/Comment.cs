using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Core
{
    public class Comment
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public string Text { get; set; }
        public string ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
