﻿using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Loader.IO.Utility;

namespace Reloaded.Mod.Loader.IO.Config
{
    public class ModSet : ObservableObject, IConfig
    {
        /* Class Members */
        public string[] EnabledMods { get; set; }

        public ModSet() { EnabledMods = Utility.Utility.EmptyStringArray; }
        public ModSet(IApplicationConfig applicationConfig) => EnabledMods = applicationConfig.EnabledMods;

        /// <summary>
        /// Reads a <see cref="ModSet"/> from the hard disk and returns its contents.
        /// </summary>
        public static ModSet FromFile(string filePath) => ConfigReader<ModSet>.ReadConfiguration(filePath);

        /// <summary>
        /// Assigns the list of enabled mods to a given application config.
        /// </summary>
        public void ToApplicationConfig(IApplicationConfig config) => config.EnabledMods = EnabledMods;

        /// <summary>
        /// Saves the current mod collection to a given file path.
        /// </summary>
        public void Save(string filePath) => ConfigReader<ModSet>.WriteConfiguration(filePath, this);

        /// <inheritdoc />
        public void SetNullValues()
        {
            EnabledMods ??= Utility.Utility.EmptyStringArray;
        }
    }
}
