namespace TauCode.IO;

public static class PathExtensions
{
    public static string CreateTempFilePath(string? namePrefix = null, string? extension = null)
    {
        namePrefix ??= "ztemp-";
        extension ??= ".dat";

        if (!extension.StartsWith("."))
        {
            extension = $".{extension}";
        }

        var name = $"{namePrefix}{Guid.NewGuid()}{extension}";
        var dir = Path.GetTempPath();

        var path = Path.Combine(dir, name);
        return path;
    }
}