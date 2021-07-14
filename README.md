# SolastaFaceUnlock

This mod unlocks 55 NPC faces and makes them available for character creation. Finally, you can look just like NPC_TavernGuy!
Disclaimer: Some faces may not work with all bear shapes!
Note: All of the unlocked Human faces are available under all origins.

V0.0.2: Added Bald option for males and females of all races.

V0.0.3: Unlocked 1 new Skin/Face color. Unlocked 3 glowing eye colors. The swatches do not properly reflect their color, so click on them to see. They are the three on the bottom row.

V0.0.4: Removed bugged skin "FaceShape_NPC_Idriel_Fair_Brow", updated description to 55 faces.

V0.0.5: Removed bald hairstyle as it has been officially added to the game as of 1.1.16(Sorcerer Update). 


# How to Compile

0. Install all required development pre-requisites:
	- [Visual Studio 2019 Community Edition](https://visualstudio.microsoft.com/downloads/)
	- [.NET "Current" x86 SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
1. Download and install [Unity Mod Manager (UMM)](https://www.nexusmods.com/site/mods/21)
2. Execute UMM, Select Solasta, and Install
3. Download and install [SolastaModApi](https://www.nexusmods.com/solastacrownofthemagister/mods/48) using UMM
4. Create the environment variable *SolastaInstallDir* and point it to your Solasta game home folder
	- tip: search for "edit the system environment variables" on windows search bar
5. Use "Install Release" or "Install Debug" to have the Mod installed directly to your Game Mods folder

NOTE Unity Mod Manager and this mod template make use of [Harmony](https://go.microsoft.com/fwlink/?linkid=874338)

# How to Debug

1. Open Solasta game folder
	* Rename Solasta.exe to Solasta.exe.original
	* Rename UnityPlayer.dll to UnityPlayer.dll.original
	* Add below entries to *Solasta_Data\boot.config*:
		```
		wait-for-managed-debugger=1
		player-connection-debug=1
		```
2. Download and install [7zip](https://www.7-zip.org/a/7z1900-x64.exe)
3. Download [Unity Editor 2019.4.19](https://download.unity3d.com/download_unity/ca5b14067cec/Windows64EditorInstaller/UnitySetup64-2019.4.19f1.exe)
4. Open Downloads folder
	* Right-click UnitySetup64-2019.4.1f1.exe, 7Zip -> Extract Here
	* Navigate to Editor\Data\PlaybackEngines\windowsstandalonesupport\Variations\win64_development_mono
		* Copy *UnityPlayer.dll* and *WinPixEventRuntime.dll* to clipboard
	* Navigate to the Solasta game folder
		* Rename *UnityPlayer.dll* to *UnityPlayer.dll.original*
		* Paste *UnityPlayer.dll* and *WinPixEventRuntime.dll* from clipboard
5. You can now attach the Unity Debugger from Visual Studio 2019, Debug -> Attach Unity Debug

# How to publish (first time)

1. Create a new repo on GitHub on Browser UI
2. Run CREATE_SOLASTA_MOD.PS1 on my computer to get template and first commit to Repo
3. Develop / Test the Mod
4. Create new hidden Mod on Nexus page with minimum required entries. Get Nexus URL
5. Edit version entries on CSPROJ, Info.json, and Repository.json (I always start with 0.0.1)
6. Edit Info.json and fix Nexus URL
7. Release Mod on GitHub using Vx.y.z as TAG/RELEASE convention (I always start with V0.0.1)
8. Update Nexus page with download file and set mod to unhidden

# How to publish (update)

1. Develop / Test the Mod
2. Edit version entries on CSPROJ, Info.json, and Repository.json
3. Update DownloadURL on Repository.json
4. Release Mod on GitHub using Vx.y.z as TAG/RELEASE convention
5. Update Nexus page with new release
