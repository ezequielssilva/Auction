using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Auction.Web.Helpers
{
    public class ValidationWrapper : IValidationWrapper
    {
        public ModelStateDictionary ModelState
        {
            private set;
            get;
        }

        public bool IsValid => ModelState.IsValid;

        public void MapTo(IList<ValidationModel> errors)
        {
            foreach (ValidationModel model in errors)
                ModelState.AddModelError(model.Attribute, model.Message);
        }

        public void SetModelState(ModelStateDictionary modelState)
        {
            ModelState = modelState;
        }
    }
}
