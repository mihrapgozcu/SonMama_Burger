using FluentValidation;
using SonMama_Burger.VM;

namespace SonMama_Burger.Validations
{
	public class ResetPasswordVMValidator:AbstractValidator<ResetPasswordVM>
	{
		public ResetPasswordVMValidator()
		{
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez!").Equal(x => x.ConfirmPassword).WithMessage("Şifre ve Şifre Tekrarı aynı olmalıdır!");
			RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrarı boş geçilemez!");
		}

	}
}
