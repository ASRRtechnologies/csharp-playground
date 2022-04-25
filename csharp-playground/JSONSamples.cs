using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace csharp_playground;

public class JsonSamples
{
    public void CreateJsonUsingJObject()
    {
        var jObject = new JObject(
            new JProperty("views",
                new JObject(
                    new JProperty("phase", "test"
                    )
                )
            )
        );

        Console.WriteLine("Using JObject: {0}", jObject);
    }

    public void CreateJsonUsingDynamicAccessor()
    {
        
        JObject jObject = new JObject
        {
            { "Date", DateTime.Now },
            { "Year", 1995 }, 
            { "Views", new JObject
                {
                    { "Phase", "Do, etc." },
                    { "Age", 28 }
                }
            }
        };
        
        Console.WriteLine("Using dynamic object: {0}", jObject);
    }

    public void CreateJsonUsingOOPObject()
    {
        var customObject = new CustomObject();
        customObject.phase.views.DO = "TEST";
        string output = JsonConvert.SerializeObject(customObject);
        
        Console.WriteLine("Using OOP object: {0}", output);

    }

    private class CustomObject
    {
        public Phase phase { get; set; } = new();
    }

    private class Phase
    {
        public Views views { get; set; } = new();
    }

    private class Views
    {
        public string? DO { get; set; }
    }
    
}