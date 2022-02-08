using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseProject.Core.Dtos
{
    public class ArticleUpdateDto
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
