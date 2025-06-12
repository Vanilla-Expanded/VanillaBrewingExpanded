using RimWorld;
using Verse;

namespace VanillaBrewingExpanded
{
    public class Hediff_AntiMuscleParasites : Hediff_High
    {

        public override void PostAdd(DamageInfo? dinfo)
        {
            base.PostAdd(dinfo);
           

            Hediff hediff = this.pawn.health.hediffSet.GetFirstHediffOfDef(HediffDef.Named("MuscleParasites"), false);
            if (hediff != null)
            {

                hediff.Tended(0.5f, 0.5f);


            }

        }
    }
}

