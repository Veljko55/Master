using System;
using System.Collections.Generic;
using System.Text;

namespace AssetSCADA.Entities
{
    public class ScadaBreaker
    {
        public int Id { get; set; }
        public bool Value { get; set; }
        public string ModelCode { get; set; }
        public bool IsDeleted { get; set; }
        public int SimulatorAddress { get; set; }
    }
}
