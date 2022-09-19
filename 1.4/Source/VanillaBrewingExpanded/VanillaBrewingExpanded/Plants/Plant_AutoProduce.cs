
using RimWorld;
using System;
using Verse;

namespace VanillaBrewingExpanded
{
    public class Plant_AutoProduce : Plant
    {
        public int counter = 0;

        public override void ExposeData()
        {
            base.ExposeData();
      
            Scribe_Values.Look<int>(ref this.counter, "counter", 0, false);

        }

        public override void TickLong()
        {
            base.TickLong();
            counter++;
           
            if (counter>60 && this.Growth>0.7) {
                counter = 0;
                Random random = new Random();
                if (random.NextDouble() > 0.4) {
                    Thing thing = ThingMaker.MakeThing(this.def.plant.harvestedThingDef, null);
                    thing.SetForbidden(true);
                    if (random.NextDouble() < 0.4)
                    {
                        thing.stackCount = 2;
                    } else {
                        thing.stackCount = 4;
                    }                       
                    GenPlace.TryPlaceThing(thing, this.Position+IntVec3.South, this.Map, ThingPlaceMode.Near, null, null, default(Rot4));
                }
                

            }
        }

      
    }
}
