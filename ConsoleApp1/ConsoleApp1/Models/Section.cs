using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Section
    {
        public Guid Id { get; set; } = Guid.NewGuid();  
        public string Title { get; set; }   
        public List<Paragraph> Paragraphs { get; set; } = new List<Paragraph> { };  
    }
}
