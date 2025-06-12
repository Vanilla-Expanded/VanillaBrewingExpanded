
using RimWorld;
using System;
using System.Collections.Generic;
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

        public override IEnumerable<Gizmo> GetGizmos()
        {

            foreach (Gizmo item in base.GetGizmos())
            {
                yield return item;
            }
            if (DebugSettings.ShowDevGizmos)
            {
                Command_Action command_Action = new Command_Action();
                command_Action.defaultLabel = "DEV: Produce fruit";
                command_Action.action = delegate
                {
                    ProduceFruit();
                };
                yield return command_Action;
            }

        }





        public override void TickLong()
        {
            base.TickLong();
            counter++;

            if (counter > 60 && this.Growth > 0.7)
            {
                counter = 0;
                if (Rand.Chance(0.6f))
                { ProduceFruit(); }



            }
        }

        public void ProduceFruit()
        {

            Thing thing = ThingMaker.MakeThing(this.def.plant.harvestedThingDef, null);

            if (Rand.Chance(0.4f))
            {
                thing.stackCount = 2;
            }
            else
            {
                thing.stackCount = 4;
            }
            GenPlace.TryPlaceThing(thing, this.Position + IntVec3.South, this.Map, ThingPlaceMode.Near, null, null, default(Rot4));
            switch (VanillaBrewingExpanded_Settings.homeAreaOrAlways)
            {
                case HomeAreaOrAlways.Never:
                    thing.SetForbidden(true);
                    break;
                case HomeAreaOrAlways.HomeArea:

                    if (thing.Position.InBounds(this.Map) && !Map.areaManager.Home[thing.Position])
                    {
                        thing.SetForbidden(true);
                    }

                    
                    break;
                case HomeAreaOrAlways.Always:
                    break;
            }


        }


    }
}
