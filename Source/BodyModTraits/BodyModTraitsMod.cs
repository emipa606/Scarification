﻿using Mlie;
using UnityEngine;
using Verse;

namespace BodyModTraits;

[StaticConstructorOnStartup]
internal class BodyModTraitsMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static BodyModTraitsMod Instance;

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
        Instance = this;
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
            settings ??= GetSettings<BodyModTraitsSettings>();

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
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Gap();
        listingStandard.CheckboxLabeled("Scar.modsAreBad".Translate(), ref Settings.IsBad,
            "Scar.modsAreBad.tooltip".Translate());
        listingStandard.Gap();
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("Scar.version".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        Internal.UpdateHediffs();
    }
}