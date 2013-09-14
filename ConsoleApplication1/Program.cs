using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            Console.WriteLine("Foo: {0}",foo.IsReadOnly);
            Console.WriteLine("Bar: {0}", bar.IsReadOnly);
            Console.WriteLine("Baz: {0}", baz.IsReadOnly);
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
        [ReadOnly(true)]
        public string Foo { get; set; }

        [Editable(true)]
        [ReadOnly(true)]
        public string Bar { get; set; }
        
        [Editable(false)]
        [ReadOnly(false)]
        public string Baz { get; set; }
    }
}
