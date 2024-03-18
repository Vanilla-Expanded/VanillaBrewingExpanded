using RimWorld;
using UnityEngine;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace VanillaBrewingExpanded
{



    public class VanillaBrewingExpanded_Mod : Mod
    {


        public VanillaBrewingExpanded_Mod(ModContentPack content) : base(content)
        {
            GetSettings<VanillaBrewingExpanded_Settings>();
        }
        public override string SettingsCategory() => "Vanilla Brewing Expanded";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            VanillaBrewingExpanded_Settings.DoWindowContents(inRect);
        }
    }


}
