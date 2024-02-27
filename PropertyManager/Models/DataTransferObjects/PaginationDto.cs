using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataTransferObjects
{
    public class PaginationDto
    {
        public int count { get; set;}
        public List<object> data { get; set;}
    }
}
