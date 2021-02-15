using System.Collections.Generic;

namespace Auction.Core
{
    public interface IValidationCollection
    {
        void AddError(string attribute, string message);
        bool IsValid { get; }
        IList<ValidationModel> GetErrors();
    }
}
