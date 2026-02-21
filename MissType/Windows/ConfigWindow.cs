using System;
using System.Numerics;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Windowing;

namespace MissType.Windows;

public class ConfigWindow : Window, IDisposable
{
    private readonly Configuration _configuration;

    public ConfigWindow(Plugin plugin) : base("Miss Type Settings###MissTypeConfig")
    {
        Flags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar;
        Size = new Vector2(400, 200);
        SizeCondition = ImGuiCond.FirstUseEver;
        _configuration = plugin.Configuration;
    }

    public override void Draw()
    {
        ImGui.TextWrapped("Configure which chat channels you are allowed to send messages to.");
        ImGui.Spacing();
        ImGui.Separator();
        ImGui.Spacing();
        ImGui.TextDisabled("Channel allow/block list will go here.");
    }

    public void Dispose() { }
}
