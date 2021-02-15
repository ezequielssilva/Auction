using System.Collections;
using System.Collections.Generic;

namespace Auction.Core.Validations
{
    public interface IValidationWrapper
    {
        bool IsValid { get; }

        void SetModelState(IEnumerable modelState);
        //void AddError(string atrribute, string message);

        void MapTo(IList<ValidationModel> errors);
    }
}
