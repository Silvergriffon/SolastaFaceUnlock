using UnityModManagerNet;

namespace SolastaFaceUnlock
{
    public class Core
    {

    }
    
    public class Settings : UnityModManager.ModSettings
    {
        public bool UnlockNPCs = true;
        public bool UnmarkedSorcerers = false;
        public bool UnlockSorcerer = false;
        public bool UnlockEyeStyles = false;
        public bool UnlockGlowingEyes = false;
        public bool UnlockGlowingBodyDecorations = false;
    }
}
