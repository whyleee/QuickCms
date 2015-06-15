using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.ModelBinding;
using QuickCms;

namespace TestSite.Binding
{
    public class ItemModelBinder : IModelBinder
    {
        public async Task<ModelBindingResult> BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof (ItemModel))
            {
                return null;
            }

            var typeName = (string)(await bindingContext.ValueProvider.GetValueAsync("TypeName")).RawValue;
            var fullTypeName = (string) (await bindingContext.ValueProvider.GetValueAsync("FullTypeName")).RawValue;
            var entityType = Type.GetType(fullTypeName);
            var entity = Activator.CreateInstance(entityType);

            foreach (var prop in entity.GetType().GetProperties())
            {
                var value = await bindingContext.ValueProvider.GetValueAsync("Item." + prop.Name);
                var propValue = Convert.ChangeType(GetValue(value), prop.PropertyType);
                prop.SetValue(entity, propValue);
            }

            var model = new ItemModel
            {
                TypeName = typeName,
                FullTypeName = fullTypeName,
                Item = entity
            };

            return new ModelBindingResult(model, bindingContext.ModelName, isModelSet: true);
        }

        private object GetValue(ValueProviderResult result)
        {
            if (result.RawValue is IEnumerable<string> && ((IEnumerable<string>) result.RawValue).Contains("true"))
            {
                return true;
            }

            return result.RawValue;
        }
    }
}
