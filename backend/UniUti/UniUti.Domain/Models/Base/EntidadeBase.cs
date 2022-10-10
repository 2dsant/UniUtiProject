using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniUti.Domain.Models.Base
{
    public class EntidadeBase
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        internal List<string> _errors = new List<string>();
        public IReadOnlyCollection<string> Errors => _errors;
        public bool IsValid => _errors.Count == 0;

        private void AddErrorsList(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                _errors.Add(error.ErrorMessage);
            }
        }

        protected bool Validate<V, O>(V validator, O obj) where V : AbstractValidator<O>
        {
            var validation = validator.Validate(obj);
            if (validation.Errors.Count > 0)
                AddErrorsList(validation.Errors);

            return IsValid;
        }

        public string ErrorsToString()
        {
            var builder = new StringBuilder();

            foreach (var error in _errors)
                builder.AppendLine(error);

            return builder.ToString();
        }
    }
}