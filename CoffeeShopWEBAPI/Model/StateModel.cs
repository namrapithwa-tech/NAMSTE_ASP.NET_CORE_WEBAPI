﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace CoffeeShopWEBAPI.Model
{
    public class StateModel
    {
            public int StateID { get; set; }
            public string StateName { get; set; }
            public int CountryID { get; set; }
            public string StateCode { get; set; }
    }
}