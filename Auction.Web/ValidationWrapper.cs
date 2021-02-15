using Auction.Core;
using Auction.Core.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Collections.Generic;

namespace Auction.Web
{
    public class ValidationWrapper : IValidationWrapper
    {
        public ModelStateDictionary ModelState
        {
            private set;
            get;
        }

        public bool IsValid => throw new System.NotImplementedException();

        public void SetModelState(IEnumerable modelState)
        {
            ModelState = (ModelStateDictionary)modelState;
        }

        public void MapTo(IList<ValidationModel> errors)
        {
            foreach (ValidationModel model in errors)
                ModelState.AddModelError(model.Attribute, model.Message);
        }
    }
}
