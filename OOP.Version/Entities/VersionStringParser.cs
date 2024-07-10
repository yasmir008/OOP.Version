using OOP.Version.Exceptions;

namespace OOP.Version.Entities;

public class VersionStringParser
{
    public static uint GetMajor(string version) => ParseElementAt(version, elementIndex: 0);

    public static uint GetMinor(string version) => ParseElementAt(version, elementIndex: 1);

    public static uint GetPatch(string version) => ParseElementAt(version, elementIndex: 2);

    private static uint ParseElementAt(string version, int elementIndex)
    {
        string[] splitedVersion = version.Split('.');

        if (splitedVersion.Length > elementIndex)
        {
            if (uint.TryParse(splitedVersion.ElementAt(elementIndex), out uint major))
                return major;

            throw new InvalidVersionStringException();
        }

        return 0;
    }
}
