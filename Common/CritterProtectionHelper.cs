using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CritterCompanionshipActiveByDefault.Common
{
    public static class CritterProtectionHelper
    {
        public const int activeBookID = 4767;
        public const int inactiveBookID = 5453;

        public static bool HasItem(Player player, int id)
        {
            var config = Config.Instance;
            if (config == null) return false;

            bool has_item = player.HasItemInInventoryOrOpenVoidBag(id);

            if (config.CheckPiggyBank)
                has_item |= player.HasItem(id, player.bank.item);

            if (config.CheckSafe)
                has_item |= player.HasItem(id, player.bank2.item);

            if (config.CheckDefendersForge)
                has_item |= player.HasItem(id, player.bank3.item);

            return has_item;
        }

        public static bool ShouldProtectCritters(Player player)
        {
            var config = Config.Instance;
            if (config == null) return false;
            if (!config.ModActive) return false;
            if (HasItem(player, activeBookID)) return true;
            if (HasItem(player, inactiveBookID)) return false;
            return true;
        }
    }
}