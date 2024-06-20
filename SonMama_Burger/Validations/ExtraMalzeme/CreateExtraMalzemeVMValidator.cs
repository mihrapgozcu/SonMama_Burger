using SonMama_Burger.VM.ExtraMalzemeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SonMama_Burger.Validations.ExtraMalzeme
{
	public class CreateExtraMalzemeVMValidator:AbstractValidator<CreateExtraMalzemeVM>
	{
		public CreateExtraMalzemeVMValidator()
		{
			RuleFor(x => x.Adi).NotEmpty().WithMessage("Ad alani bos gecilemez!");
			RuleFor(x => x.Fiyat).NotEmpty().WithMessage("Fiyat alani bos gecilemez!");
		}
	}
}
