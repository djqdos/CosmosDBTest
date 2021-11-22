using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class PropertyReport
    {
        public Guid Id { get; set; }

        public string Title { get; set; }       

        public List<Section> Sections { get; set; } = new List<Section>();
    }
}
