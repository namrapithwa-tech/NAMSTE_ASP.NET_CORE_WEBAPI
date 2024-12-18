using CoffeeShopWEBAPI.Model;
using FluentValidation;

//public int StateID { get; set; }
//public string StateName { get; set; }
//public int CountryID { get; set; }
//public string StateCode { get; set; }

namespace CoffeeShopWEBAPI.Validations
{
    public class StateValidation : AbstractValidator<StateModel>
    {
        public StateValidation()
        {
            RuleFor(s => s.StateName).NotEmpty().WithMessage("State Name Should not be empty...!!!")
                .MaximumLength(100).WithMessage("State Name cannot exceed 100 characters.");

            RuleFor(s => s.StateCode).NotEmpty().WithMessage("State Code Should not be empty...!!!")
                .Length(2, 10).WithMessage("State Code must be between 2 and 10 characters.");

            RuleFor(s => s.CountryID)
                .GreaterThan(0).WithMessage("Country ID must be greater than 0.");
        }
    }
}
