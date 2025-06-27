using RimWorld;
using Verse;

namespace BodyModTraits;

internal class ThoughtWorker_HasAddedBodyMod : ThoughtWorker
{
    protected override ThoughtState CurrentStateInternal(Pawn p)
    {
        var num = Internal.CountBodyMods(p.health.hediffSet);
        return num > 0 ? ThoughtState.ActiveAtStage(num - 1) : false;
    }
}