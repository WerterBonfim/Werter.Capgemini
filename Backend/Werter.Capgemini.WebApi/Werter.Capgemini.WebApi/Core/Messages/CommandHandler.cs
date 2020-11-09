using System.Threading.Tasks;
using FluentValidation.Results;
using Werter.Capgemini.WebApi.Core.Data;

namespace Werter.Capgemini.WebApi.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        public CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork unitOfWork)
        {
            var inseriu = await unitOfWork.Commit();
            if (!inseriu)
                AdicionarErro("Houve um erro ao persistir os dados");

            return ValidationResult;
        }
    }
}