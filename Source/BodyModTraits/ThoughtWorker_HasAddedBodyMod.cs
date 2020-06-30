using RimWorld;
using Verse;

namespace BodyModTraits
{
    class ThoughtWorker_HasAddedBodyMod : ThoughtWorker
    {		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			int num = Internal.countBodyMods(p.health.hediffSet);
			if (num > 0)
			{
				return ThoughtState.ActiveAtStage(num - 1);
			}
			return false;
		}
	}
}
