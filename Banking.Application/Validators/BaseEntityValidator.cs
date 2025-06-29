using Banking.Core.Entities.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Validators;

public class BaseEntityValidator<T> : AbstractValidator<T> where T : BaseEntity
{
	public BaseEntityValidator()
	{
		RuleFor(x => x.Id)
			.NotEmpty()
			.WithMessage("Id alanı boş olamaz");

		RuleFor(x => x.CreatedAt)
			.NotEmpty()
			.WithMessage("Oluşturma tarihi boş olamaz")
			.LessThanOrEqualTo(DateTime.UtcNow)
			.WithMessage("Oluşturma tarihi gelecek bir tarih olamaz");
	}
}
