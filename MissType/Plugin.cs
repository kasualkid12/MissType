using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using MissType.Windows;

namespace MissType;

public sealed class Plugin : IDalamudPlugin
{
    [PluginService] internal static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService] internal static ICommandManager CommandManager { get; private set; } = null!;
    [PluginService] internal static IPluginLog Log { get; private set; } = null!;

    private const string CommandName = "/misstype";
    private const string CommandAlias = "/mt";

    public Configuration Configuration { get; init; }
    public readonly WindowSystem WindowSystem = new("MissType");
    private ConfigWindow ConfigWindow { get; init; }

    public Plugin()
    {
        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();

        ConfigWindow = new ConfigWindow(this);
        WindowSystem.AddWindow(ConfigWindow);

        PluginInterface.UiBuilder.Draw += WindowSystem.Draw;
        PluginInterface.UiBuilder.OpenConfigUi += OpenConfigUi;

        CommandManager.AddHandler(CommandName, new CommandInfo(OnOpenSettings)
        {
            HelpMessage = "Open Miss Type settings.",
        });
        CommandManager.AddHandler(CommandAlias, new CommandInfo(OnOpenSettings)
        {
            HelpMessage = "Alias for /misstype.",
        });

        Log.Information("Miss Type loaded.");
    }

    public void Dispose()
    {
        PluginInterface.UiBuilder.Draw -= WindowSystem.Draw;
        PluginInterface.UiBuilder.OpenConfigUi -= OpenConfigUi;
        WindowSystem.RemoveAllWindows();
        ConfigWindow.Dispose();
        CommandManager.RemoveHandler(CommandName);
        CommandManager.RemoveHandler(CommandAlias);
    }

    private void OpenConfigUi() => ConfigWindow.Toggle();
    private void OnOpenSettings(string command, string args) => ConfigWindow.Toggle();
}
