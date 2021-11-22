using ConsoleApp1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class SectionDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();  
        public string Title { get; set; }   
        public List<ParagraphDTO> Paragraphs { get; set; } = new List<ParagraphDTO> { };  
    }
}
