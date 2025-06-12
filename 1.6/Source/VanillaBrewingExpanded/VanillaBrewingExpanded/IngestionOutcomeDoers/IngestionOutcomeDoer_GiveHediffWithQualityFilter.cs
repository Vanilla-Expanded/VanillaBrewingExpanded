
using System.Collections.Generic;
using RimWorld;
using Verse;
namespace VanillaBrewingExpanded
{
    public class IngestionOutcomeDoer_GiveHediffWithQualityFilter : IngestionOutcomeDoer
    {
        public HediffDef hediffDef;

        public float severity = -1f;

        public ChemicalDef toleranceChemical;

        private bool divideByBodySize;

        public bool multiplyByGeneToleranceFactors;

        public QualityCategory minQuality;

        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            CompQuality comp = ingested.TryGetComp<CompQuality>();
            if (comp != null) { 
                if(comp.Quality>= minQuality)
                {
                    Hediff hediff = HediffMaker.MakeHediff(hediffDef, pawn);
                    float effect = ((!(severity > 0f)) ? hediffDef.initialSeverity : severity);
                    AddictionUtility.ModifyChemicalEffectForToleranceAndBodySize(pawn, toleranceChemical, ref effect, multiplyByGeneToleranceFactors, divideByBodySize);
                    hediff.Severity = effect;
                    pawn.health.AddHediff(hediff);
                    pawn.mindState.inspirationHandler.TryStartInspiration(InspirationDefOf.Inspired_Creativity);
                }
            
            }

            
        }

        public override IEnumerable<StatDrawEntry> SpecialDisplayStats(ThingDef parentDef)
        {
            if (!parentDef.IsDrug || !(chance >= 1f))
            {
                yield break;
            }
            foreach (StatDrawEntry item in hediffDef.SpecialDisplayStats(StatRequest.ForEmpty()))
            {
                yield return item;
            }
        }
    }
}