using FluentValidation;
using SonMama_Burger.VM;
namespace SonMama_Burger.Validations
{
	public class ContactUsVMValidator:AbstractValidator<ContactUsVM>
	{
		public ContactUsVMValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen ad ve soyad bilgisi giriniz!");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen Email bilgisi giriniz!");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen konu bilgisi giriniz!");
			RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen mesajınızı  giriniz!");
		}

	}
}
