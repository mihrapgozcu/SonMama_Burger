using FluentValidation;
using SonMama_Burger.VM;

namespace SonMama_Burger.Validations
{
	public class LoginVMValidator:AbstractValidator<LoginVM>
	{
		public LoginVMValidator()
		{
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı girmelisiniz!");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez!");
		}
	}
}
