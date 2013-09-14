using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelMetadata foo = GetModelMetadata<Model>("Foo");
            ModelMetadata bar = GetModelMetadata<Model>("Bar");
            ModelMetadata baz = GetModelMetadata<Model>("Baz");

            Console.WriteLine("Foo: {0}",foo.TemplateHint ?? "N/A");
            Console.WriteLine("Bar: {0}", bar.TemplateHint ?? "N/A");
            Console.WriteLine("Baz: {0}", baz.TemplateHint ?? "N/A");
        }

        static ModelMetadata GetModelMetadata<TModel>(string propertyName)
        {
            ModelMetadataProvider provider = ModelMetadataProviders.Current;
            ModelMetadata containerMetadata = new ModelMetadata(provider,
                null, () => null, typeof(Model), null);
            return containerMetadata.Properties.FirstOrDefault(p => p.PropertyName
                == propertyName);
        }
    }


    public class Model
    {
        public string Foo { get; set; }

        [UIHint("Template A")]
        [UIHint("Template B")]
        public string Bar { get; set; }
        
        [UIHint("Template A")]
        public string Baz { get; set; }
    }
}
