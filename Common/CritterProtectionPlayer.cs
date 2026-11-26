using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CritterCompanionshipActiveByDefault.Common
{
    public class CritterProtectionPlayer : ModPlayer
    {
        public override void ResetEffects()
        {
            Player.dontHurtCritters = CritterProtectionHelper.ShouldProtectCritters(Player);
        }
    }
}