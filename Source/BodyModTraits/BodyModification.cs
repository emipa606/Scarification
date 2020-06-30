using RimWorld;
using System.Collections.Generic;
using Verse;

namespace BodyModTraits
{
    class Internal
    {
        public static int countBodyMods(HediffSet hediffSet)
        {
            int num = 0;
            List<Hediff> hediffs = hediffSet.hediffs;
            for (int i = 0; i < hediffs.Count; i++)
            {
                if (hediffs[i].def.defName == "Tattooed" || hediffs[i].def.defName == "Scarified")
                {
                    num++;
                    continue;
                }
                if (hediffs[i] is Hediff_Implant && hediffs[i].def.defName.StartsWith("EM") &&
                    (hediffs[i].def.defName.EndsWith("Sma") || hediffs[i].def.defName.EndsWith("Med") || hediffs[i].def.defName.EndsWith("Big")))
                {
                    num++;
                }
            }
            return num;
        }
    }

    class BodyModificationEnthusiast : TraitDef
    {
    }
    class BodyModificationPurist : TraitDef
    {
    }
}
