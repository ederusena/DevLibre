using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevLibre.Models
{
    public class CreateProjectCommentInputModel
    {
        public int IdProject { get; set; }
        public int IdUser { get; set; }
        public string Content { get; set; }
        
    }
}