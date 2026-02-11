using FluentValidation;
using RentACarApp.Application.Features.Mediator.Commands.ReviewCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator() {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Adı Boş Geçmeyiniz !");
            RuleFor(x => x.Name).MinimumLength(20).WithMessage("En az 20 karakter giriniz !");
            RuleFor(x => x.StarCount).InclusiveBetween(1, 5).WithMessage("Yıldız değeri 1 ile 5 arasında olmalıdır!");

        }
    }
}
