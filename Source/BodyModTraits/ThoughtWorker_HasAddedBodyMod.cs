using RimWorld;
using Verse;

namespace BodyModTraits
{
    internal class ThoughtWorker_HasAddedBodyMod : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            var num = Internal.countBodyMods(p.health.hediffSet);
            if (num > 0)
            {
                return ThoughtState.ActiveAtStage(num - 1);
            }

            return false;
        }
    }
}