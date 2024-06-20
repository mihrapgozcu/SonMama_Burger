using FluentValidation;
using SonMama_Burger.VM;

namespace SonMama_Burger.Validations
{
	public class UpdateUserVMValidator:AbstractValidator<UpdateUserVM>
	{
		public UpdateUserVMValidator()
		{
			RuleFor(x => x.Ad).NotEmpty().WithMessage("İsim boş geçilemez!");
			RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyad boş geçilemez!");
			RuleFor(x => x.Cinsiyet).NotNull().WithMessage("Cinsiyet boş geçilemez!");
			RuleFor(x => x.DogumTarihi).NotNull().WithMessage("Doğum tarihi boş geçilemez!");
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası boş geçilemez!");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez!");
			RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-mail adresi giriniz");
		}
	}
}
