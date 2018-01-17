using System.IO;
using Newtonsoft.Json;

namespace _23Knots.Input.Loader
{
    public class KeyBindingsLoader
    {
        public KeyBindingsJson KeyBindingsJson { get; set; }

        public KeyBindingsLoader()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Input/Data/KeyBindings.json");
            using (var r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                KeyBindingsJson = JsonConvert.DeserializeObject<KeyBindingsJson>(json);
            }
        }
    }
}
