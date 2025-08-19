using System;
using System.Data;
using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürünün adınınız boş bırakmayınız.");
        RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürünün adınınız en az 2 karakter olmalıdır."); // en az 2 karakterli olması gerektiğini belirtiyoruz
        RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ürünün adınınız en fazla 50 karakter olmalıdır."); // en fazla 50 karakterli olması gerektiğini belirtiyoruz
        RuleFor(x => x.Price).NotEmpty().WithMessage("Ürünün fiyatı boş bırakmayınız.").GreaterThan(0).WithMessage("Ürünün fiyatı 0'dan büyük olmalıdır.").LessThan(1000).WithMessage("Ürünün fiyatı 1000'den küçük olmalıdır."); // fiyatın boş olmaması ve 0'dan büyük olması gerektiğini belirtiyoruz
        RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürünün açıklaması boş bırakmayınız.");
        
    }
}
