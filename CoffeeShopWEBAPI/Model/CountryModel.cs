﻿    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    namespace CoffeeShopWEBAPI.Model
    {
        public class CountryModel
        {
            public int CountryID { get; set; }
            public string CountryName { get; set; }
            public string CountryCode { get; set; }
        }
    }
