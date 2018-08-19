using C2C.Core.Enums;
using System.Collections.Generic;

namespace C2C.Core.Domain
{
    public class Device : BaseEntity
    {
        public string ManufacturerName { get; set; }
        public int YearManufactured { get; set; }
        public Channel CommChannel { get; set; }
        public int CommPortNumber { get; set; }
        public string CommProtocol { get; set; }
        public Dimension Dimensions { get; set; }
        public List<Feature> Features { get; set; }
        public PowerStatus PowerStatus { get; set; }
        public ConnectionStatus ConnectionStatus { get; set; }        
    }
}
