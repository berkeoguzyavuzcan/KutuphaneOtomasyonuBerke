using FluentValidation;
using KütüphaneOtomasyonuBerke.Object.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneOtomasyonuBerke.Tools.FluentValidation.Books
{
    public class BookInsertValidator : AbstractValidator<InsertBook>
    {
        public BookInsertValidator()
        {
            RuleFor(b => b.BookName).NotEmpty().MaximumLength(200).WithMessage("Kitap Adını Boş Bırakamazsınız.");

            RuleFor(x => x.PublisherName)
                .NotEmpty().MaximumLength(200).WithMessage("Yayınevi alanını boş bırakamazsınız");

            
        }
    }
}
