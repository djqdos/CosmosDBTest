using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DTO
{
    public class PropertyReportDTO
    {
        public Guid Id { get; set; }

        public List<SectionDTO> Sections { get; set; } = new List<SectionDTO>();
    }
}
