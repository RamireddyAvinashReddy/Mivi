using MiviTest.Models;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text;

namespace MiviTest
{
    public class CommonFunctions
    {
        public static Result GetCollection()
        {
            var assembly = typeof(CommonFunctions).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("MiviTest.collection.json");

            using (var reader = new StreamReader(stream, Encoding.GetEncoding("iso-8859-1")))
            {
                return JsonConvert.DeserializeObject<Result>(reader.ReadToEnd());
            }
        }
    }
}