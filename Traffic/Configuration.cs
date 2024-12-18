using System.IO;
using Newtonsoft.Json;

public class Configuration
{
    public int PocetVozidel { get; set; }
    public int DelkaSilnic { get; set; }
    public int IntervalSemaforu { get; set; }

    public static Configuration Load(string path)
    {
        var json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<Configuration>(json);
    }
}
