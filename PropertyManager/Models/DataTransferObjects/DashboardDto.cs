using Models.Entities;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataTransferObjects
{
    public class DashboardDto
    {
        public List<PropertyOwnership> PropertyOwnerships { get; set; }
        public List<CardData> CardData { get; set; }
        public List<CardData> PropertyTypes { get; set; }
    }

    public class CardData{
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
