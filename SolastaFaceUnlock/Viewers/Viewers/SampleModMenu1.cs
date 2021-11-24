using UnityModManagerNet;
using ModKit;

namespace SolastaFaceUnlock.Menus.Viewers
{
    public class SampleModMenu1 : IMenuSelectablePage
    {
        public string Name => "Unlock Options";

        public int Priority => 0;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            bool toggle;

            toggle = Main.Settings.UnlockNPCs;
            if (UI.Toggle("Unlock NPC faces", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.UnlockNPCs = toggle;
            }

            toggle = Main.Settings.UnmarkedSorcerers;
            if (UI.Toggle("Allow unmarked Sorcerers", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.UnmarkedSorcerers = toggle;
            }

            toggle = Main.Settings.UnlockSorcerer;
            if (UI.Toggle("Unlock Sorcerer markings for all characters", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.UnlockSorcerer = toggle;
            }

            toggle = Main.Settings.UnlockEyeStyles;
            if (UI.Toggle("Unlock eye styles", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.UnlockEyeStyles = toggle;
            }

            toggle = Main.Settings.UnlockGlowingEyes;
            if (UI.Toggle("Unlock glowing eye colors", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.UnlockGlowingEyes = toggle;
            }

            toggle = Main.Settings.UnlockGlowingBodyDecorations;
            if (UI.Toggle("Unlock glowing colors for all markings and tattoos", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.UnlockGlowingBodyDecorations = toggle;
            }
        }
    }
}

