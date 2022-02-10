using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseProject.Core.Dtos.Comment
{
    public class CommentAddDto
    {
        public bool IsActive { get; set; }
        public string Text { get; set; }
        public string ArticleId { get; set; }
        [JsonIgnore]
        public Article Article { get; set; }
    }
}
