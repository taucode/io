namespace TauCode.IO;

public static class FileSystemHelper
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

    public static void PurgeDirectory(string directoryPath)
    {
        // todo checks

        var di = new DirectoryInfo(directoryPath);
        di.PurgeDirectory();
    }

    public static void PurgeDirectory(this DirectoryInfo directoryInfo)
    {
        if (directoryInfo == null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        foreach (var file in directoryInfo.GetFiles())
        {
            file.Delete();
        }

        foreach (var dir in directoryInfo.GetDirectories())
        {
            dir.Delete(true);
        }
    }

    public static void CreateDirectoryForFile(string filePath)
    {
        var directoryPath = Path.GetDirectoryName(filePath);
        Directory.CreateDirectory(directoryPath); // todo resharper checks
    }
}