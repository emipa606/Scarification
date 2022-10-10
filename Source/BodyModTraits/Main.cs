using Verse;

namespace BodyModTraits;

[StaticConstructorOnStartup]
internal static class Main
{
    static Main()
    {
        Internal.updateHediffs();
    }
}