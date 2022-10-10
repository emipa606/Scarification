using System.Collections.Generic;
using System.Linq;
using Verse;

namespace BodyModTraits;

public static class Internal
{
    public static int countBodyMods(HediffSet hediffSet)
    {
        var num = 0;
        var hediffs = hediffSet.hediffs;
        foreach (var hediff in hediffs)
        {
            if (hediff.def.defName is "Tattooed" or "Scarified")
            {
                num++;
                continue;
            }

            if (hediff is Hediff_Implant && hediff.def.defName.StartsWith("EM") &&
                (hediff.def.defName.EndsWith("Sma") || hediff.def.defName.EndsWith("Med") ||
                 hediff.def.defName.EndsWith("Big")))
            {
                num++;
            }
        }

        return num;
    }

    public static void updateHediffs()
    {
        var listOfHediffs = new List<string> { "Tattooed", "Scarified" };
        var hediffs = from HediffDef hediff in DefDatabase<HediffDef>.AllDefsListForReading
            where listOfHediffs.Contains(hediff.defName)
            select hediff;
        foreach (var hediffDef in hediffs)
        {
            hediffDef.isBad = LoadedModManager.GetMod<BodyModTraitsMod>().GetSettings<BodyModTraitsSettings>()
                .IsBad;
        }
    }
}