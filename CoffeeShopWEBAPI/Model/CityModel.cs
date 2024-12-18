 using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CoffeeShopWEBAPI.Model
{
    public class CityModel
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public string CityCode { get; set; }
    }
}
