using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using ModKit;
using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaFaceUnlock
{
    public class Main
    {
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static ModManager<Core, Settings> Mod;
        internal static MenuManager Menu;
        internal static Settings Settings { get { return Mod.Settings; } }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();

                Logger = modEntry.Logger;
                Mod = new ModManager<Core, Settings>();
                Mod.Enable(modEntry, assembly);

                Menu = new MenuManager();
                Menu.Enable(modEntry, assembly);
                
                Translations.Load(MOD_FOLDER);
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }

        internal static void OnGameReady()
		{
			MorphotypeElementDefinition unlock_defiler_skin = DatabaseHelper.MorphotypeElementDefinitions.FaceAndSkin_Defiler;
			unlock_defiler_skin.SetPlayerSelectable(true);
			MorphotypeElementDefinition unlock_neutral_skin = DatabaseHelper.MorphotypeElementDefinitions.FaceAndSkin_Neutral;
			unlock_neutral_skin.SetPlayerSelectable(true);

			if (Main.Settings.UnmarkedSorcerers)
			{
				CharacterSubclassDefinition sorcerer_draconic = DatabaseHelper.CharacterSubclassDefinitions.SorcerousDraconicBloodline;
				CharacterSubclassDefinition sorcerer_mana_painter = DatabaseHelper.CharacterSubclassDefinitions.SorcerousManaPainter;
				CharacterSubclassDefinition sorcerer_child_of_rift = DatabaseHelper.CharacterSubclassDefinitions.SorcerousChildRift;

				sorcerer_draconic.SetMorphotypeSubclassFilterTag(GraphicsDefinitions.MorphotypeSubclassFilterTag.Default);
				sorcerer_mana_painter.SetMorphotypeSubclassFilterTag(GraphicsDefinitions.MorphotypeSubclassFilterTag.Default);
				sorcerer_child_of_rift.SetMorphotypeSubclassFilterTag(GraphicsDefinitions.MorphotypeSubclassFilterTag.Default);
			}

			if (Main.Settings.UnlockNPCs)
			{
				CharacterRaceDefinition humanity = DatabaseHelper.CharacterRaceDefinitions.Human;
				CharacterRaceDefinition halfelfkind = DatabaseHelper.CharacterRaceDefinitions.HalfElf;
				halfelfkind.RacePresentation.FemaleFaceShapeOptions.Add("FaceShape_NPC_Princess");
				halfelfkind.RacePresentation.MaleFaceShapeOptions.Add("FaceShape_HalfElf_NPC_Bartender");
				humanity.RacePresentation.MaleFaceShapeOptions.Add("FaceShape_NPC_TavernGuy");
				humanity.RacePresentation.MaleFaceShapeOptions.Add("FaceShape_NPC_TomWorker");
			}

			foreach (MorphotypeElementDefinition morphotype in DatabaseRepository.GetDatabase<MorphotypeElementDefinition>())
			{
				if (Main.Settings.UnlockNPCs)
				{
					if (morphotype.Category == MorphotypeElementDefinition.ElementCategory.FaceShape)
					{
						morphotype.SetPlayerSelectable(true);
						//In previous builds, FaceShape_NPC_Idriel_Fair_Brow caused the game to fail to load
						//MorphotypeElementDefinition exception_Idriel_Fair_Brow = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Idriel_Fair_Brow;
						//exception_Idriel_Fair_Brow.SetPlayerSelectable(false);
						//FaceShape_NPC_Aksha causes the model to float and changes attack animations
						MorphotypeElementDefinition exception_NPC_Aksha = DatabaseHelper.MorphotypeElementDefinitions.FaceShape_NPC_Aksha;
						exception_NPC_Aksha.SetPlayerSelectable(false);

					}
				}

				if (Main.Settings.UnlockGlowingEyes)
				{
					if (morphotype.Category == MorphotypeElementDefinition.ElementCategory.EyeColor)
					{
						morphotype.SetPlayerSelectable(true);
					}
				}

				if (Main.Settings.UnlockEyeStyles)
				{
					if (morphotype.Category == MorphotypeElementDefinition.ElementCategory.Eye)
					{
						morphotype.SetSubClassFilterMask(GraphicsDefinitions.MorphotypeSubclassFilterTag.All);
					}
				}

				if (Main.Settings.UnlockSorcerer)
				{
					if (morphotype.Category == MorphotypeElementDefinition.ElementCategory.BodyDecoration)
					{
						morphotype.SetSubClassFilterMask(GraphicsDefinitions.MorphotypeSubclassFilterTag.All);
					}
				}

				if (Main.Settings.UnlockGlowingBodyDecorations)
				{
					if (morphotype.Category == MorphotypeElementDefinition.ElementCategory.BodyDecorationColor)
					{
						if (morphotype.SubclassFilterMask == GraphicsDefinitions.MorphotypeSubclassFilterTag.SorcererManaPainter)
						{
							morphotype.SetSubClassFilterMask(GraphicsDefinitions.MorphotypeSubclassFilterTag.All);
						}
					}
				}
			}

		}
	}
}
