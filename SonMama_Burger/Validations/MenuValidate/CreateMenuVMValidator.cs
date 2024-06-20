using FluentValidation;
using SonMama_Burger.VM.MenuVM;

namespace SonMama_Burger.Validations.MenuValidate
{
	public class CreateMenuVMValidator:AbstractValidator<CreateMenuVM>
	{
		public CreateMenuVMValidator()
		{
			RuleFor(x => x.Adi).NotEmpty().WithMessage("Ad alani bos gecilemez!");
			RuleFor(x => x.Fiyat).NotEmpty().WithMessage("Fiyat alani bos gecilemez!");

		}

	}
}
