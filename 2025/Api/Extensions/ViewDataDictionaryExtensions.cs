using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Application.Api.Extensions;

public static class ViewDataDictionaryExtensions
{
    public static string ValidationClass<TModel, TProperty>(this ViewDataDictionary<TModel> viewData, Expression<Func<TModel,TProperty>> selector) => 
        viewData.ValidationClass(((MemberExpression)selector.Body).Member.Name);

    public static string ValidationClass<T>(this ViewDataDictionary<T> viewData, string key) =>
        viewData.ModelState.GetValidationState(key) switch
        {
            ModelValidationState.Unvalidated => string.Empty,
            ModelValidationState.Invalid => "is-invalid",
            ModelValidationState.Valid => string.Empty,
            ModelValidationState.Skipped => string.Empty,
            _ => string.Empty
        };
}

