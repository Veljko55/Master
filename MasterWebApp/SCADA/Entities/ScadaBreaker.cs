using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA.Entities
{
    public class ScadaBreaker
    {
        public int Id { get; set; }
        public bool IsOpet { get; set; }
        public string ModelCode { get; set; }
    }
}
