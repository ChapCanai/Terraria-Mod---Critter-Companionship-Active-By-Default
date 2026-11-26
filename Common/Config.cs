using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CritterCompanionshipActiveByDefault.Common
{
    public class Config : ModConfig
    {
        public static Config Instance;
        public override void OnLoaded() { Instance = this; }

        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        public bool ModActive;

        [DefaultValue(true)]
        public bool CheckPiggyBank;

        [DefaultValue(true)]
        public bool CheckSafe;

        [DefaultValue(true)]
        public bool CheckDefendersForge;

        [DefaultValue(true)]
        public bool ProtectAgainstNPCs;
    }
}