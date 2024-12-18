using CoffeeShopWEBAPI.Model;
using FluentValidation;

//public int CountryID { get; set; }
//public string CountryName { get; set; }
//public string CountryCode { get; set; }

namespace CoffeeShopWEBAPI.Validations
{
    public class CountryValidation : AbstractValidator<CountryModel>
    {
        public CountryValidation() { 
            RuleFor(c => c.CountryName).NotEmpty().WithMessage("Country Name Should not be empty...!!!")
                .MaximumLength(100).WithMessage("Country Name cannot exceed 100 characters.");
            RuleFor(c => c.CountryCode).NotEmpty().WithMessage("Country Code Should not be empty...!!!");
        }
    }
}
