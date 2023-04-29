using System.Collections.Generic;
using Verse;
using System.Linq;
using UnityEngine;
using System;



namespace VanillaBrewingExpanded
{
    public class VanillaBrewingExpanded_Settings : ModSettings

    {


        public static HomeAreaOrAlways homeAreaOrAlways = HomeAreaOrAlways.HomeArea;
 
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref homeAreaOrAlways, "homeAreaOrAlways", HomeAreaOrAlways.HomeArea, true);
         
        }

        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls = new Listing_Standard();

            ls.Begin(inRect);
            ls.Gap(10f);
            var unforbidLabel = ls.Label("VBE_UnforbidDroppedFruit".Translate());
            if (RadioButtonLabeledLeft(new Rect(unforbidLabel.position.x + 450, unforbidLabel.position.y, 150f, 21f), "VBE_Never".Translate(), homeAreaOrAlways == HomeAreaOrAlways.Never, "VBE_NeverDesc".Translate()))
            {
                homeAreaOrAlways = HomeAreaOrAlways.Never;
            }
            if(RadioButtonLabeledLeft(new Rect(unforbidLabel.position.x + 600, unforbidLabel.position.y, 150f, 21f), "VBE_HomeArea".Translate(), homeAreaOrAlways == HomeAreaOrAlways.HomeArea, "VBE_HomeAreaDesc".Translate()))
            {
                homeAreaOrAlways = HomeAreaOrAlways.HomeArea;
            }
            if (RadioButtonLabeledLeft(new Rect(unforbidLabel.position.x + 750, unforbidLabel.position.y, 150f, 21f), "VBE_Always".Translate(), homeAreaOrAlways == HomeAreaOrAlways.Always, "VBE_AlwaysDesc".Translate()))
            {
                homeAreaOrAlways = HomeAreaOrAlways.Always;
            }

            ls.End();
        }

        public static bool RadioButtonLabeledLeft(Rect rect, string labelText, bool chosen, string tooltip)
        {

            TextAnchor anchor = Text.Anchor;
            Text.Anchor = TextAnchor.MiddleLeft;
            Widgets.Label(new Rect(rect.position + new Vector2(24f, 0f), rect.size - new Vector2(24f, 0f)), labelText);
            TooltipHandler.TipRegion(rect, tooltip);
            Text.Anchor = anchor;
            return Widgets.RadioButton(rect.x, rect.y + rect.height / 2f - 12f, chosen);
        }


    }

 










}
