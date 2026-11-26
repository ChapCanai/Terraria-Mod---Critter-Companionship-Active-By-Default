using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CritterCompanionshipActiveByDefault.Common
{
    public class CritterProtectionGlobalNPC : GlobalNPC
    {
        public override bool CanBeHitByNPC(NPC npc, NPC attacker)
        {
            if (!NPCID.Sets.CountsAsCritter[npc.type]) return true;

            var config = Config.Instance;
            if (config == null) return true;
            if (!config.ModActive) return true;
            if (!config.ProtectAgainstNPCs) return true;

            return false;
        }

        bool IsPlayerProjectile(Projectile projectile) => projectile.owner < Main.maxPlayers;
        bool IsNPCProjectile(Projectile projectile) => projectile.hostile || !IsPlayerProjectile(projectile);

        public override bool? CanBeHitByProjectile(NPC npc, Projectile projectile)
        {
            if (!NPCID.Sets.CountsAsCritter[npc.type]) return null;

            var config = Config.Instance;
            if (config == null) return null;
            if (!config.ModActive) return null;
            if (!config.ProtectAgainstNPCs) return null;
            if (IsPlayerProjectile(projectile)) return null;

            if (IsNPCProjectile(projectile)) return false;

            return null;
        }
    }
}

// public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
// {
//     if (!NPCID.Sets.CountsAsCritter[npc.type]) return;
//     if (!projectile.hostile) return;

//     var config = Config.Instance;
//     if (config == null) return;
//     if (!config.ModActive) return;
//     if (!config.ProtectAgainstNPCs) return;

//     modifiers.FinalDamage *= 0f;
// }