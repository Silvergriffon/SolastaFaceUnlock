using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using SolastaModApi;
using SolastaModApi.Extensions;
using ModKit;
using ModKit.Utility;

namespace SolastaFaceUnlock
{
    public static class Main
    {
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static ModManager<Core, Settings> Mod { get; private set; }
        internal static MenuManager Menu { get; private set; }
        internal static Settings Settings { get { return Mod.Settings; } }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                Logger = modEntry.Logger;

                Mod = new ModManager<Core, Settings>();
                Menu = new MenuManager();
                modEntry.OnToggle = OnToggle;

                Translations.Load(MOD_FOLDER);
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool enabled)
        {
            if (enabled)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Mod.Enable(modEntry, assembly);
                Menu.Enable(modEntry, assembly);
            }
            else
            {
                Menu.Disable(modEntry);
                Mod.Disable(modEntry, false);
                ReflectionCache.Clear();
            }
            return true;
        }

        public class BaldieBuilder : BaseDefinitionBuilder<MorphotypeElementDefinition>
        {
            protected BaldieBuilder(string name, string guid, string title_string, string description_string) : base(name, guid)
            {
                if (title_string != "")
                {
                    Definition.GuiPresentation.Title = title_string;
                }
                if (description_string != "")
                {
                    Definition.GuiPresentation.Description = description_string;
                }
            }

            public static MorphotypeElementDefinition createMorphotype(string name, string guid, string title_string, string description_string)
            {
                return new BaldieBuilder(name, guid, title_string, description_string).AddToDB();
            }
        }


    internal static void OnGameReady()
        {
            string[] originallowed = new string[] { "Origin_NonHuman" };
            string[] humanorigin = new string[] { "Origin_CA", "Origin_AS", "Origin_AF" };
            string[] all_origins = new string[] { "Origin_NonHuman", "Origin_CA", "Origin_AS", "Origin_AF" };
            MorphotypeElementDefinition face_to_unlock = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Priest_of_Arun;
            MorphotypeElementDefinition face_to_unlock2 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Ceannard;
            MorphotypeElementDefinition face_to_unlock3 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Galar_Goldentongue;
            MorphotypeElementDefinition face_to_unlock4 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Gromnir_Stonefist;
            MorphotypeElementDefinition face_to_unlock5 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Joris_Nikannen;
            MorphotypeElementDefinition face_to_unlock6 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Beryl_Stonebeard;
            MorphotypeElementDefinition face_to_unlock7 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Gormdottir;
            MorphotypeElementDefinition face_to_unlock8 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Gorim_Ironsoot;
            MorphotypeElementDefinition face_to_unlock9 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Daliat_Sunbird;
            MorphotypeElementDefinition face_to_unlock10 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Ilastar_Keenmind_Airgetine;
            MorphotypeElementDefinition face_to_unlock11 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Iolair_Faisech;
            MorphotypeElementDefinition face_to_unlock12 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Llygath_Steelmind;
            MorphotypeElementDefinition face_to_unlock13 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Mardracht;
            MorphotypeElementDefinition face_to_unlock14 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Medwal_Strongfire;
            MorphotypeElementDefinition face_to_unlock15 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Ceiwad_Silverflower;
            MorphotypeElementDefinition face_to_unlock16 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Adrasteia_Epimeles_Aspis;
            MorphotypeElementDefinition face_to_unlock17 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Idriel_Fair_Brow;
            MorphotypeElementDefinition face_to_unlock18 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Joriel_Fox_Eye;
            MorphotypeElementDefinition face_to_unlock19 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Kiaradth_BrightSpark;
            MorphotypeElementDefinition face_to_unlock20 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Kythaela_Wildspring;
            MorphotypeElementDefinition face_to_unlock21 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Lizzaria_of_Grimhold;
            MorphotypeElementDefinition face_to_unlock22 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_HalfElf_NPC_Edvan_Danantar;
            MorphotypeElementDefinition face_to_unlock23 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_HalfElf_NPC_Dek;
            MorphotypeElementDefinition face_to_unlock24 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_HalfElf_NPC_Hugo_Requer;
            MorphotypeElementDefinition face_to_unlock25 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_HalfElf_NPC_Carran_Rightower;
            MorphotypeElementDefinition face_to_unlock26 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_HalfElf_NPC_Karel_Martel;
            MorphotypeElementDefinition face_to_unlock27 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_HalfElf_NPC_Zhoron;
            MorphotypeElementDefinition face_to_unlock28 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_HalfElf_NPC_Alena;
            MorphotypeElementDefinition face_to_unlock29 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_HalfElf_NPC_Verissa_Ironshell;
            MorphotypeElementDefinition face_to_unlock30 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Priest_of_Maraike;
            MorphotypeElementDefinition face_to_unlock31 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Wilf_Warmhearth;
            MorphotypeElementDefinition face_to_unlock32 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Annie_Bagmordah;
            MorphotypeElementDefinition face_to_unlock33 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Mildred_Warmhearth;
            MorphotypeElementDefinition face_to_unlock34 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Maddy_Greenisle;
            MorphotypeElementDefinition face_to_unlock35 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Beric_Sunblaze;
            MorphotypeElementDefinition face_to_unlock36 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Robar_Sharp;
            MorphotypeElementDefinition face_to_unlock37 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Dalon_Lark;
            MorphotypeElementDefinition face_to_unlock38 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Halman_Summer;
            MorphotypeElementDefinition face_to_unlock39 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Arwin_Merton;
            MorphotypeElementDefinition face_to_unlock40 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Morden_Kyre;
            MorphotypeElementDefinition face_to_unlock41 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Razan_Holarant;
            MorphotypeElementDefinition face_to_unlock42 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Talbut_the_Grey;
            MorphotypeElementDefinition face_to_unlock43 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Ron;
            MorphotypeElementDefinition face_to_unlock44 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Aksha;
            MorphotypeElementDefinition face_to_unlock45 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Morgan;
            MorphotypeElementDefinition face_to_unlock46 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Leira_Kean;
            MorphotypeElementDefinition face_to_unlock47 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Lena;
            MorphotypeElementDefinition face_to_unlock48 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Heather_Merran;
            MorphotypeElementDefinition face_to_unlock49 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Atima_Bladeburn;
            MorphotypeElementDefinition face_to_unlock50 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Lisbath_Townsend;
            MorphotypeElementDefinition face_to_unlock51 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Priestess_of_Pakri;
            face_to_unlock.SetOriginAllowed(originallowed);
            face_to_unlock2.SetOriginAllowed(originallowed);
            face_to_unlock3.SetOriginAllowed(originallowed);
            face_to_unlock4.SetOriginAllowed(originallowed);
            face_to_unlock5.SetOriginAllowed(originallowed);
            face_to_unlock6.SetOriginAllowed(originallowed);
            face_to_unlock7.SetOriginAllowed(originallowed);
            face_to_unlock8.SetOriginAllowed(originallowed);
            face_to_unlock9.SetOriginAllowed(originallowed);
            face_to_unlock10.SetOriginAllowed(originallowed);
            face_to_unlock11.SetOriginAllowed(originallowed);
            face_to_unlock12.SetOriginAllowed(originallowed);
            face_to_unlock13.SetOriginAllowed(originallowed);
            face_to_unlock14.SetOriginAllowed(originallowed);
            face_to_unlock15.SetOriginAllowed(originallowed);
            face_to_unlock16.SetOriginAllowed(originallowed);
            face_to_unlock17.SetOriginAllowed(originallowed);
            face_to_unlock18.SetOriginAllowed(originallowed);
            face_to_unlock19.SetOriginAllowed(originallowed);
            face_to_unlock20.SetOriginAllowed(originallowed);
            face_to_unlock21.SetOriginAllowed(originallowed);
            face_to_unlock22.SetOriginAllowed(originallowed);
            face_to_unlock23.SetOriginAllowed(originallowed);
            face_to_unlock24.SetOriginAllowed(originallowed);
            face_to_unlock25.SetOriginAllowed(originallowed);
            face_to_unlock26.SetOriginAllowed(originallowed);
            face_to_unlock27.SetOriginAllowed(originallowed);
            face_to_unlock28.SetOriginAllowed(originallowed);
            face_to_unlock29.SetOriginAllowed(originallowed);
            face_to_unlock30.SetOriginAllowed(originallowed);
            face_to_unlock31.SetOriginAllowed(originallowed);
            face_to_unlock32.SetOriginAllowed(originallowed);
            face_to_unlock33.SetOriginAllowed(originallowed);
            face_to_unlock34.SetOriginAllowed(originallowed);
            face_to_unlock35.SetOriginAllowed(humanorigin);
            face_to_unlock36.SetOriginAllowed(humanorigin);
            face_to_unlock37.SetOriginAllowed(humanorigin);
            face_to_unlock38.SetOriginAllowed(humanorigin);
            face_to_unlock39.SetOriginAllowed(humanorigin);
            face_to_unlock40.SetOriginAllowed(humanorigin);
            face_to_unlock41.SetOriginAllowed(humanorigin);
            face_to_unlock42.SetOriginAllowed(humanorigin);
            face_to_unlock43.SetOriginAllowed(humanorigin);
            face_to_unlock44.SetOriginAllowed(humanorigin);
            face_to_unlock45.SetOriginAllowed(humanorigin);
            face_to_unlock46.SetOriginAllowed(humanorigin);
            face_to_unlock47.SetOriginAllowed(humanorigin);
            face_to_unlock48.SetOriginAllowed(humanorigin);
            face_to_unlock49.SetOriginAllowed(humanorigin);
            face_to_unlock50.SetOriginAllowed(humanorigin);
            face_to_unlock51.SetOriginAllowed(humanorigin);
            face_to_unlock.SetPlayerSelectable(true);
            face_to_unlock2.SetPlayerSelectable(true);
            face_to_unlock3.SetPlayerSelectable(true);
            face_to_unlock4.SetPlayerSelectable(true);
            face_to_unlock5.SetPlayerSelectable(true);
            face_to_unlock6.SetPlayerSelectable(true);
            face_to_unlock7.SetPlayerSelectable(true);
            face_to_unlock8.SetPlayerSelectable(true);
            face_to_unlock9.SetPlayerSelectable(true);
            face_to_unlock10.SetPlayerSelectable(true);
            face_to_unlock11.SetPlayerSelectable(true);
            face_to_unlock12.SetPlayerSelectable(true);
            face_to_unlock13.SetPlayerSelectable(true);
            face_to_unlock14.SetPlayerSelectable(true);
            face_to_unlock15.SetPlayerSelectable(true);
            face_to_unlock16.SetPlayerSelectable(true);
//            face_to_unlock17.SetPlayerSelectable(true) - causes failure to load into game
            face_to_unlock18.SetPlayerSelectable(true);
            face_to_unlock19.SetPlayerSelectable(true);
            face_to_unlock20.SetPlayerSelectable(true);
            face_to_unlock21.SetPlayerSelectable(true);
            face_to_unlock22.SetPlayerSelectable(true);
            face_to_unlock23.SetPlayerSelectable(true);
            face_to_unlock24.SetPlayerSelectable(true);
            face_to_unlock25.SetPlayerSelectable(true);
            face_to_unlock26.SetPlayerSelectable(true);
            face_to_unlock27.SetPlayerSelectable(true);
            face_to_unlock28.SetPlayerSelectable(true);
            face_to_unlock29.SetPlayerSelectable(true);
            face_to_unlock30.SetPlayerSelectable(true);
            face_to_unlock31.SetPlayerSelectable(true);
            face_to_unlock32.SetPlayerSelectable(true);
            face_to_unlock33.SetPlayerSelectable(true);
            face_to_unlock34.SetPlayerSelectable(true);
            face_to_unlock35.SetPlayerSelectable(true);
            face_to_unlock36.SetPlayerSelectable(true);
            face_to_unlock37.SetPlayerSelectable(true);
            face_to_unlock38.SetPlayerSelectable(true);
            face_to_unlock39.SetPlayerSelectable(true);
            face_to_unlock40.SetPlayerSelectable(true);
            face_to_unlock41.SetPlayerSelectable(true);
            face_to_unlock42.SetPlayerSelectable(true);
            face_to_unlock43.SetPlayerSelectable(true);
            face_to_unlock44.SetPlayerSelectable(true);
            face_to_unlock45.SetPlayerSelectable(true);
            face_to_unlock46.SetPlayerSelectable(true);
            face_to_unlock47.SetPlayerSelectable(true);
            face_to_unlock48.SetPlayerSelectable(true);
            face_to_unlock49.SetPlayerSelectable(true);
            face_to_unlock50.SetPlayerSelectable(true);
            face_to_unlock51.SetPlayerSelectable(true);

            CharacterRaceDefinition humanity = DatabaseHelper.CharacterRaceDefinitions.Human;
            CharacterRaceDefinition halfelfkind = DatabaseHelper.CharacterRaceDefinitions.HalfElf;
            CharacterRaceDefinition dwarfkind = DatabaseHelper.CharacterRaceDefinitions.Dwarf;
            CharacterRaceDefinition halflingses = DatabaseHelper.CharacterRaceDefinitions.Halfling;
            CharacterRaceDefinition elfkind = DatabaseHelper.CharacterRaceDefinitions.Elf;
            halfelfkind.RacePresentation.MaleFaceShapeOptions.Add("FaceShape_HalfElf_NPC_Bartender");
            humanity.RacePresentation.FemaleFaceShapeOptions.Add("FaceShape_NPC_Heather_Merran");
            halfelfkind.RacePresentation.FemaleFaceShapeOptions.Add("FaceShape_NPC_Princess");
            humanity.RacePresentation.MaleFaceShapeOptions.Add("FaceShape_NPC_TavernGuy");
            humanity.RacePresentation.MaleFaceShapeOptions.Add("FaceShape_NPC_TomWorker");
            MorphotypeElementDefinition face_to_unlock52 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_HalfElf_NPC_Bartender;
            MorphotypeElementDefinition face_to_unlock53 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Heather_Merran;
            MorphotypeElementDefinition face_to_unlock54 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Princess;
            MorphotypeElementDefinition face_to_unlock55 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_TavernGuy;
            MorphotypeElementDefinition face_to_unlock56 = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_TomWorker;
            face_to_unlock52.SetOriginAllowed(originallowed);
            face_to_unlock53.SetOriginAllowed(humanorigin);
            face_to_unlock54.SetOriginAllowed(originallowed);
            face_to_unlock55.SetOriginAllowed(humanorigin);
            face_to_unlock56.SetOriginAllowed(humanorigin);
            face_to_unlock52.SetPlayerSelectable(true);
            face_to_unlock53.SetPlayerSelectable(true);
            face_to_unlock54.SetPlayerSelectable(true);
            face_to_unlock55.SetPlayerSelectable(true);
            face_to_unlock56.SetPlayerSelectable(true);

            MorphotypeElementDefinition skin_to_unlock = DatabaseHelper.MorphotypeElementDefinitions.FaceAndSkin_Defiler;
            skin_to_unlock.SetOriginAllowed(all_origins);
            skin_to_unlock.SetPlayerSelectable(true);

            MorphotypeElementDefinition eyes_to_unlock = DatabaseHelper.MorphotypeElementDefinitions.EyeColorDefiler;
            MorphotypeElementDefinition eyes_to_unlock2 = DatabaseHelper.MorphotypeElementDefinitions.EyeColorInfiltrator;
            MorphotypeElementDefinition eyes_to_unlock3 = DatabaseHelper.MorphotypeElementDefinitions.EyeColorNecromancer;
            eyes_to_unlock.SetOriginAllowed(all_origins);
            eyes_to_unlock2.SetOriginAllowed(all_origins);
            eyes_to_unlock3.SetOriginAllowed(all_origins);
            eyes_to_unlock.SetPlayerSelectable(true);
            eyes_to_unlock2.SetPlayerSelectable(true);
            eyes_to_unlock3.SetPlayerSelectable(true);

            void ToggleSorcererBodyDecorations()
            {
                CharacterSubclassDefinition sorcerer_draconic = DatabaseHelper.CharacterSubclassDefinitions.SorcerousDraconicBloodline;
                CharacterSubclassDefinition sorcerer_mana_painter = DatabaseHelper.CharacterSubclassDefinitions.SorcerousManaPainter;
                CharacterSubclassDefinition sorcerer_child_of_rift = DatabaseHelper.CharacterSubclassDefinitions.SorcerousChildRift;

                if (!Main.Settings.toggleBodyDec)
                {
                    return;
                }

                sorcerer_draconic.SetMorphotypeSubclassFilterTag(GraphicsDefinitions.MorphotypeSubclassFilterTag.Default);
                sorcerer_mana_painter.SetMorphotypeSubclassFilterTag(GraphicsDefinitions.MorphotypeSubclassFilterTag.Default);
                sorcerer_child_of_rift.SetMorphotypeSubclassFilterTag(GraphicsDefinitions.MorphotypeSubclassFilterTag.Default);

            }

            ToggleSorcererBodyDecorations();


        }
    }
}
