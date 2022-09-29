using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocailMedia.Data.DTO
{
    public class PostDTO
    {
        public string PostId { get; set; }

        public string PostTitle { get; set; }
        public string PostMessage { get; set; }
        public string PostImage { get; set; }
        public int LikeCount { get; set; }
        public List<string> PostComment { get; set; }
    }
}
