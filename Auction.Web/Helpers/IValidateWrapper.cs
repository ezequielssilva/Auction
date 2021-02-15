using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Auction.Web.Helpers
{
    public interface IValidationWrapper
    {
        bool IsValid { get; }

        void SetModelState(ModelStateDictionary modelState);

        void MapTo(IList<ValidationModel> errors);
    }
}
