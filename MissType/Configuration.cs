using Dalamud.Configuration;
using System;

namespace MissType;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;

    // Placeholder for future settings (e.g. which channels to allow/block)
    // public HashSet<XivChatType> AllowedChannels { get; set; } = new();

    public void Save()
    {
        Plugin.PluginInterface!.SavePluginConfig(this);
    }
}
