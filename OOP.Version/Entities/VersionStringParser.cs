using OOP.Version.Exceptions;

namespace OOP.Version.Entities;

public class VersionStringParser
{
    public static uint GetMajor(string versionString) => ParseElementAt(versionString, elementIndex: 0);

    public static uint GetMinor(string versionString) => ParseElementAt(versionString, elementIndex: 1);

    public static uint GetPatch(string versionString) => ParseElementAt(versionString, elementIndex: 2);

    private static uint ParseElementAt(string versionString, int elementIndex)
    {
        string[] splitedVersion = versionString.Split('.');

        if (splitedVersion.Length > elementIndex)
        {
            if (uint.TryParse(splitedVersion.ElementAt(elementIndex), out uint major))
                return major;

            throw new InvalidVersionStringException();
        }

        return 0;
    }
}
