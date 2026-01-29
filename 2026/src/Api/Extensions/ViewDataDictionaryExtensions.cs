using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Application.Api.Extensions;

public static class ViewDataDictionaryExtensions
{
    extension<TModel>(ViewDataDictionary<TModel> viewData)
    {
        public string ValidationClass<TProperty>(Expression<Func<TModel,TProperty>> selector) => 
            viewData.ValidationClass(((MemberExpression)selector.Body).Member.Name);

        private string ValidationClass(string key) =>
            viewData.ModelState.GetValidationState(key) switch
            {
                ModelValidationState.Valid => string.Empty,
                ModelValidationState.Skipped => string.Empty,
                ModelValidationState.Unvalidated => string.Empty,
                ModelValidationState.Invalid => "is-invalid",
                _ => string.Empty
            };
    }
}

