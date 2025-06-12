using RimWorld;
using Verse;

namespace VanillaBrewingExpanded
{
    public class Hediff_AntiInfections : Hediff_High
    {

        public override void PostAdd(DamageInfo? dinfo)
        {
            base.PostAdd(dinfo);
            Hediff hediff = this.pawn.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.WoundInfection, false);
            if (hediff != null)
            {
                hediff.Severity -= 0.05f;
                
            }
           

        }
    }
}

