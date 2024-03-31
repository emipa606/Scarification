using Mlie;
using UnityEngine;
using Verse;

namespace BodyModTraits;

[StaticConstructorOnStartup]
internal class BodyModTraitsMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static BodyModTraitsMod instance;

    private static string currentVersion;

    /// <summary>
    ///     The private settings
    /// </summary>
    private BodyModTraitsSettings settings;

    /// <summary>
    ///     Cunstructor
    /// </summary>
    /// <param name="content"></param>
    public BodyModTraitsMod(ModContentPack content) : base(content)
    {
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    public BodyModTraitsSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<BodyModTraitsSettings>();
            }

            return settings;
        }
        set => settings = value;
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Scarification";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("Scar.modsAreBad".Translate(), ref Settings.IsBad,
            "Scar.modsAreBad.tooltip".Translate());
        listing_Standard.Gap();
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("Scar.version".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        Internal.updateHediffs();
    }
}