// Copyright 1998-2015 Epic Games, Inc. All Rights Reserved.
using System.IO;

namespace UnrealBuildTool.Rules
{
	public class SpeechRecognition : ModuleRules
	{

        private string ModulePath
        {
            get { return Path.GetDirectoryName(RulesCompiler.GetModuleFilename(this.GetType().Name)); }
        }

        private string ThirdPartyPath
        {
            get { return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/")); }
        }

		public SpeechRecognition(TargetInfo Target)
		{
			PublicIncludePaths.AddRange(
				new string[] {
                    "SpeechRecognition/Public",
					// ... add public include paths required here ...
				}
				);

			PrivateIncludePaths.AddRange(
				new string[] {
					"SpeechRecognition/Private",
					// ... add other private include paths required here ...
				}
				);

			PublicDependencyModuleNames.AddRange(
				new string[]
				{
				    "Core", 
				    "CoreUObject", 
				    "Engine", 
				    "InputCore",
				    "RHI"
					// ... add other public dependencies that you statically link with here ...
				}
				);

			PrivateDependencyModuleNames.AddRange(
				new string[]
				{

				}
				);

			DynamicallyLoadedModuleNames.AddRange(
				new string[]
				{
					// ... add any modules that your module loads dynamically here ...
				}
				);

            LoadSphinxBase(Target);
            LoadPocketSphinx(Target);
		}


        public bool LoadSphinxBase(TargetInfo Target)
        {
            bool isLibrarySupported = false;

            if ((Target.Platform == UnrealTargetPlatform.Win64) || (Target.Platform == UnrealTargetPlatform.Win32))
            {
                isLibrarySupported = true;

                string PlatformString = (Target.Platform == UnrealTargetPlatform.Win64) ? "x64" : "x86";
                string LibrariesPath = Path.Combine(ThirdPartyPath, "SphinxBase", "Libraries");

                PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "SphinxBase" + PlatformString + ".lib"));
            }

            if (isLibrarySupported)
            {
                // Include path
                PublicIncludePaths.Add(Path.Combine(ThirdPartyPath, "SphinxBase", "Includes"));
                PrivateIncludePaths.Add(Path.Combine(ThirdPartyPath, "SphinxBase", "Includes"));
            }

            Definitions.Add(string.Format("WITH_SPHINX_BASE_BINDING={0}", isLibrarySupported ? 1 : 0));

            return isLibrarySupported;
        }

        public bool LoadPocketSphinx(TargetInfo Target)
        {
            bool isLibrarySupported = false;

            if ((Target.Platform == UnrealTargetPlatform.Win64) || (Target.Platform == UnrealTargetPlatform.Win32))
            {
                isLibrarySupported = true;

                string PlatformString = (Target.Platform == UnrealTargetPlatform.Win64) ? "x64" : "x86";
                string LibrariesPath = Path.Combine(ThirdPartyPath, "PocketSphinx", "Libraries");

                PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "PocketSphinx" + PlatformString + ".lib"));
            }

            if (isLibrarySupported)
            {
                // Include path
                PublicIncludePaths.Add(Path.Combine(ThirdPartyPath, "PocketSphinx", "Includes"));
                PrivateIncludePaths.Add(Path.Combine(ThirdPartyPath, "PocketSphinx", "Includes"));
            }

            Definitions.Add(string.Format("WITH_POCKET_SPHINX_BINDING={0}", isLibrarySupported ? 1 : 0));

            return isLibrarySupported;
        }
	}
}