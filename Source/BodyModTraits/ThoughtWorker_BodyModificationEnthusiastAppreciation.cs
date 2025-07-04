﻿using RimWorld;
using Verse;

namespace BodyModTraits;

public class ThoughtWorker_BodyModificationEnthusiastAppreciation : ThoughtWorker
{
    protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn other)
    {
        if (!p.RaceProps.Humanlike)
        {
            return false;
        }

        if (!p.story.traits.HasTrait(TraitDef.Named("BodyModificationEnthusiast")))
        {
            return false;
        }

        if (!RelationsUtility.PawnsKnowEachOther(p, other))
        {
            return false;
        }

        if (other.def != p.def)
        {
            return false;
        }

        var num = Internal.CountBodyMods(other.health.hediffSet);
        return num > 0 ? ThoughtState.ActiveAtStage(num - 1) : false;
    }
}