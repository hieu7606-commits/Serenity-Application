namespace Serene.MovieDB;

/// <summary>
/// Stored in Person.Gender as its integer value, so never renumber an existing member.
/// </summary>
[EnumKey("MovieDB.Gender")]
public enum Gender
{
    [Description("Male")]
    Male = 1,
    [Description("Female")]
    Female = 2
}
