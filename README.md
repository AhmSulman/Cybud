# Cybud

A WPF desktop "personal assistant" for Windows that puts a journal, a schedule, a finance tracker and an AI chat in one app.

![C#](https://img.shields.io/badge/C%23-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-.NET-0C54C2?style=flat-square)

## Features

| View | What it does |
|---|---|
| **Landing / Register** | User sign-up and entry screen |
| **Journal** | Write and keep dated journal entries |
| **Schedule** | Plan and track your schedule |
| **Finance Manager** | Track income and expenses |
| **Chat** | AI chat assistant through the OpenAI API |

## Build

1. Open `Cybud_WPF_0.1.sln` in Visual Studio (Windows).
2. Restore NuGet packages and build.
3. For the chat view, add your OpenAI API key in `Models/ChatAIService.cs`. Don't commit it.

A GitHub Actions workflow (`.github/workflows/dotnet.yml`) builds the project on push.

> **Status:** early version (0.1). The chat uses the legacy `text-davinci-003` completions endpoint, which OpenAI has retired, so it needs updating to the Chat Completions API to work.

## License

AGPL-3.0
