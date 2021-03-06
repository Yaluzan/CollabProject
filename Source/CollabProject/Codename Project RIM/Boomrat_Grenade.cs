﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace Codename_Project_RIM
{
    public class Boomrat_Grenade : Projectile
    {
        protected override void Impact(Thing hitThing)
        {
            Map map = base.Map;
            base.Impact(hitThing);
            PawnKindDef kindDef = PawnKindDef.Named("Boomrat");
            Pawn pawn = PawnGenerator.GeneratePawn(kindDef);
            GenSpawn.Spawn(pawn, base.Position, map);
            pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, null, false, false, null);
            pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.Range(60000, 135000);
        }
    }
}