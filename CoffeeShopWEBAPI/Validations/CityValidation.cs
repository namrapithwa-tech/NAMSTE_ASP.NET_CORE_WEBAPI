
//public int CityID { get; set; }
//public string CityName { get; set; }
//public int CountryID { get; set; }
//public int StateID { get; set; }
//public string CityCode { get; set; }

using CoffeeShopWEBAPI.Model;
using FluentValidation;

namespace CoffeeShopWEBAPI.Validations
{
    public class CityValidation : AbstractValidator<CityModel>
    {
        public CityValidation() {
            RuleFor(ci => ci.CityName)
                .NotEmpty().WithMessage("City Name is required.")
                .MaximumLength(100).WithMessage("City Name cannot exceed 100 characters.");

            RuleFor(ci => ci.CountryID)
                .GreaterThan(0).WithMessage("Country ID must be greater than 0.");

            RuleFor(ci => ci.StateID)
                .GreaterThan(0).WithMessage("State ID must be greater than 0.");

            RuleFor(ci => ci.CityCode)
                .NotEmpty().WithMessage("City Code is required.")
                .Length(2, 10).WithMessage("City Code must be between 2 and 10 characters.");
        }
    }
}
