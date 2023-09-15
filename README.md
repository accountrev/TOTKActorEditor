# TOTKActorEditor
A save file actor editor for The Legend of Zelda: Tears of the Kingdom. Intended with emulator use in mind, but also works on Switch if patient.

**Supported versions: 1.1.0, 1.1.1, 1.1.2, 1.2.0, 1.2.1**

# Purpose
This tool was created mainly as a way to edit the actors that are stored in a TOTK save file. There were no save file editors that would allow you to edit an actor "without any restrictions" (unless you know how to use Master Mode on Mark's save file editor), so this was created to fulfill that need.

# A fair warning!
This tool will edit the save file you provide it, meaning that any changes that you make while editing your save file is **IRREVERSABLE**.

This tool may also cause damage to your save file, as corruption or softlocks may occur when editing actors.

Please, please, please, make a backup of your save files before using this tool. I am not responsible for any damages caused by your main save files.

# What is considered as an actor?
If you aren't into modding or tinkering around with the game files, you may not know what an actor is.

An actor is any object represented within the game space. A few examples would be terrain, wooden platforms, Link, enemies, NPCs, items, etc. There are 15,049 actors in Tears of the Kingdom that have various features within them.

# How to use
Please refer to the Wiki for more information.

# Building
## Dependancies
-   [Microsoft .NET SDK 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
-   [ImGui.NET 1.89.5](https://www.nuget.org/packages/ImGui.NET/1.89.5)
-   [ClickableTransparenOverlay 8.1.0](https://www.nuget.org/packages/ClickableTransparentOverlay/8.1.0)
-   [Veldrid.ImGui](https://www.nuget.org/packages/Veldrid.ImGui/)
-   [Vortice.Mathematics](https://www.nuget.org/packages/Vortice.Mathematics/)
-   [NAudio](https://www.nuget.org/packages/NAudio/)