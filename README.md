# Miss Type

A [Dalamud](https://github.com/goatcorp/Dalamud) plugin for Final Fantasy XIV that limits which chat channels you can send messages to.

## Requirements

- [XIVLauncher](https://github.com/goatcorp/XIVLauncher) with Dalamud

## Installation

Miss Type is currently in its development stage. To try out the current features, you will need to [build from source](#building-from-source) and install the plugin locally (e.g. via the Dalamud plugin installer’s “Dev Plugin Locations” option).

## Usage

| Command      | Description                                      |
|-------------|---------------------------------------------------|
| `/misstype` | Open the plugin settings window.                  |
| `/mt`       | Alias for `/misstype`.                            |

You can also open settings from the plugin installer.

## Building from source

Requires [.NET SDK 10.x](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/kasualkid12/MissType.git
cd MissType
dotnet build MissType.sln -c Release
```

Output is in `MissType/bin/Release/`. In the Dalamud plugin installer, use **Local plugin** and select that folder (or your dev plugin folder).

## License

MIT.
