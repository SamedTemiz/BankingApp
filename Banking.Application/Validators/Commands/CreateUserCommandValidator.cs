using Banking.Application.DTOs.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Validators.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Ad alanı boş olamaz")
            .MaximumLength(50)
            .WithMessage("Ad maksimum 50 karakter olabilir")
            .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$")
            .WithMessage("Ad sadece harf içerebilir");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Soyad alanı boş olamaz")
            .MaximumLength(50)
            .WithMessage("Soyad maksimum 50 karakter olabilir")
            .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$")
            .WithMessage("Soyad sadece harf içerebilir");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email alanı boş olamaz")
            .EmailAddress()
            .WithMessage("Geçerli bir email adresi giriniz")
            .MaximumLength(100)
            .WithMessage("Email maksimum 100 karakter olabilir");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Şifre alanı boş olamaz")
            .MinimumLength(6)
            .WithMessage("Şifre en az 6 karakter olmalıdır")
            .MaximumLength(100)
            .WithMessage("Şifre maksimum 100 karakter olabilir")
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,}$")
            .WithMessage("Şifre en az bir küçük harf, bir büyük harf ve bir rakam içermelidir");

        RuleFor(x => x.PhoneNumber)
            .Matches("^[0-9\\s\\-\\+\\(\\)]+$")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
            .WithMessage("Geçerli bir telefon numarası giriniz")
            .MaximumLength(20)
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
            .WithMessage("Telefon numarası maksimum 20 karakter olabilir");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Today)
            .When(x => x.DateOfBirth.HasValue)
            .WithMessage("Doğum tarihi bugünden önce olmalıdır")
            .GreaterThan(DateTime.Today.AddYears(-120))
            .When(x => x.DateOfBirth.HasValue)
            .WithMessage("Doğum tarihi mantıklı bir tarih olmalıdır");
    }
}
