using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Paragraph
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ParagraphText { get; set; }
    }
}
