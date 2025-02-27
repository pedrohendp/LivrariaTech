using LivrariaTech.Api.Infraestructure.DataAccess;
using LivrariaTech.Api.Infraestructure.Services.LoggedUser;
using LivrariaTech.Exception;

namespace LivrariaTech.Api.UseCases.Checkouts
{
    public class RegisterBookCheckoutUseCase
    {
        private const int MAX_DAYS_TO_RETURN = 7;

        private readonly LoggedUserService _loggedUser;
        public RegisterBookCheckoutUseCase (LoggedUserService loggedUser)
        {
            _loggedUser = loggedUser;
        }
        public void Execute (Guid bookId)
        {
            var dbContext = new LivrariaTechDbContext();

            Validate(bookId,dbContext);

            var user = _loggedUser.GetUser(dbContext);

            dbContext.Checkouts.Add(new Domain.Entities.Checkout
            {
                UserId = user.Id,
                BookId = bookId,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(MAX_DAYS_TO_RETURN)
            }); 

            dbContext.SaveChanges();
        }

        private void Validate (Guid bookId, LivrariaTechDbContext dbContext)
        {
            var book = dbContext.Books.FirstOrDefault(book => book.Id == bookId) ?? 
                throw new NotFoundException("Livro não encontrado.");

            var amountBooksNotReturned = dbContext
                .Checkouts
                .Count(checkout => checkout.BookId == bookId && checkout.ReturnedDate != null);

            if (amountBooksNotReturned == book.Amount)
            {
                throw new NotFoundException("Livro não disponível para empréstimo.");
            }

        }
    }
}
