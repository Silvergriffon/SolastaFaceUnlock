using UnityModManagerNet;
using ModKit;
using static SolastaFaceUnlock.Main;

namespace SolastaFaceUnlock.Menus.Viewers
{
    public class SampleModMenu1 : IMenuSelectablePage
    {
        public string Name => "Sorcerer Origins";

        public int Priority => 2;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (Mod == null || !Mod.Enabled) return;

            UI.Toggle("Hide Sorcerer Body Decorations", ref Main.Settings.toggleBodyDec, 0, UI.AutoWidth());
            //UI.Toggle("Toggle Me 2", ref Main.Settings.toggleTest2, 0, UI.AutoWidth());
        }
    }
}

