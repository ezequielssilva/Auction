using System.Collections.Generic;

namespace Auction.Core
{
    public class ValidationCollection : IValidationCollection
    {
        private IList<ValidationModel> _Validations;

        public ValidationCollection()
        {
            _Validations = new List<ValidationModel>();
        }

        public void AddError(string attribute, string message)
        {
            _Validations.Add(new ValidationModel(attribute, message));
        }

        public IList<ValidationModel> GetErrors()
        {
            return _Validations;
        }

        public bool IsValid => _Validations.Count == 0;
    }
}
