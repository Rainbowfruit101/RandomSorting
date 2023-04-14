using Newtonsoft.Json;

namespace ConsoleEnvironment.Models;

public class Settings
{
    public MyRange? LengthRange { get; init; }
    public MyRange? NumberRange { get; init; }
    public Server? Server { get; init; }

    public static Settings Open(FileInfo path)
    {
        if (!path.Exists)
        {
            throw new FileNotFoundException($"{path.FullName} not found");
        }
        var json = File.ReadAllText(path.FullName);
        return JsonConvert.DeserializeObject<Settings>(json);
    }
}