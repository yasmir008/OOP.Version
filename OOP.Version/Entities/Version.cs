using OOP.Version.Exceptions;

namespace OOP.Version.Entities;

public class Version
{
    public Version(string version)
    {
        if (string.IsNullOrWhiteSpace(version))
        {
            InitializeDefaultValues();
        }
        else
        {
            _major = VersionStringParser.GetMajor(version);
            _minor = VersionStringParser.GetMinor(version);
            _patch = VersionStringParser.GetPatch(version);
        }

        _mementos = new List<VersionMemento>();
    }

    public Version Major()
    {
        SaveMemento();

        _major++;
        _minor = 0;
        _patch = 0;

        return this;
    }

    public Version Minor()
    {
        SaveMemento();

        _minor++;
        _patch = 0;

        return this;
    }

    public Version Patch()
    {
        SaveMemento();

        _patch++;

        return this;
    }

    public Version Rollback()
    {
        VersionMemento? lastMemento = _mementos.LastOrDefault();

        if (lastMemento is null)
            throw new VersionCannotRollbackException();

        _major = lastMemento.Major;
        _minor = lastMemento.Minor;
        _patch = lastMemento.Patch;

        _mementos.Remove(lastMemento);

        return this;
    }

    public string Release() => $"{_major}.{_minor}.{_patch}";
    public override string ToString() => Release();

    private void InitializeDefaultValues()
    {
        _major = 0;
        _minor = 0;
        _patch = 1;
    }

    private void SaveMemento() => _mementos.Add(new VersionMemento(_major, _minor, _patch));

    private ICollection<VersionMemento> _mementos;
    private uint _major;
    private uint _minor;
    private uint _patch;

    class VersionMemento
    {
        public VersionMemento(uint major, uint minor, uint patch)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public uint Major { get; init; }
        public uint Minor { get; init; }
        public uint Patch { get; init; }
    }
}
