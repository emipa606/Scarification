using Verse;

namespace BodyModTraits;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class BodyModTraitsSettings : ModSettings
{
    public bool IsBad;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref IsBad, "IsBad");
    }
}