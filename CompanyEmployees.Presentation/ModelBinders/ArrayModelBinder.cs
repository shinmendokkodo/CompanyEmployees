using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.ModelBinders;

/// <summary>
/// The ArrayModelBinder class is a custom Model Binder that binds a string of comma-separated values to an array of a specified type.
/// </summary>
public class ArrayModelBinder : IModelBinder
{
    /// <summary>
    /// Asynchronously binds the provided value to an array of the specified type.
    /// </summary>
    /// <param name="bindingContext">The ModelBindingContext object containing the context for model binding.</param>
    /// <returns>A Task that represents the asynchronous operation.</returns>
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        // Check if the model metadata is an enumerable type. If not, set the binding result to failed.
        if (!bindingContext.ModelMetadata.IsEnumerableType)
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        // Get the provided value from the value provider and convert it to a string.
        var providedValue = bindingContext.ValueProvider
            .GetValue(bindingContext.ModelName)
            .ToString();

        // If the provided value is empty or null, set the binding result to success with a null model value.
        if (string.IsNullOrEmpty(providedValue))
        {
            bindingContext.Result = ModelBindingResult.Success(null);
            return Task.CompletedTask;
        }

        // Get the generic type of the model and its type converter.
        var genericType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
        var converter = TypeDescriptor.GetConverter(genericType);

        // Convert the comma-separated string to an array of objects of the specified type.
        var objectArray = providedValue.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => converter.ConvertFromString(x.Trim()))
            .ToArray();

        // Create an array of the specified type and copy the object array to it.
        var guidArray = Array.CreateInstance(genericType, objectArray.Length);
        objectArray.CopyTo(guidArray, 0);
        bindingContext.Model = guidArray;

        // Set the binding result to success with the created array as the model value.
        bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
        return Task.CompletedTask;
    }
}
