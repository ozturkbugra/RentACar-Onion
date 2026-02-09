using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Dto.CarFeatureDtos
{
    public class ResultListCarFeatureByCarIdDto
    {
        public int carFeatureID { get; set; }
        public int carID { get; set; }
        public int featureID { get; set; }
        public string featureName { get; set; }
        public bool available { get; set; }
    }
}
