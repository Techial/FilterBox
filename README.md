<div align="center">
  <img src="Images/FilterBox.ico"/>
  <h1>FilterBox</h1>
</div>

<div align="center">
  <strong>Save that precious space and bandwith</strong>
</div>
<div align="center">
  Automatically adds the <i>com.dropbox.ignored</i> xattr to filtered files & directories.
</div>

<br />

<div align="center">
  <!-- It works, why? -->
  <a href="https://github.com/Techial/FilterBox">
    <img src="https://forthebadge.com/images/badges/it-works-why.svg"
      alt="It works, why?" />
  </a>
  <!-- C# -->
  <a href="https://docs.microsoft.com/en-us/dotnet/csharp/">
    <img src="https://forthebadge.com/images/badges/made-with-c-sharp.svg"
      alt="Made with C#" />
  </a>
  <!-- Gluten free -->
  <a href="https://github.com/Techial/FilterBox/releases/latest">
    <img src="https://forthebadge.com/images/badges/gluten-free.svg"
      alt="Gluten free" />
  </a>
</div>

<div align="center">
  <sub>Built with ❤︎ by
  <a href="https://github.com/Techial">Techial</a> and
  <a href="https://github.com/Techial/FilterBox/graphs/contributors">
    contributors
  </a>
</div>

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Description](#description)
- [Screenshots](#screenshots)
- [UI](#ui)
- [Support](#support)

## Features

- **small size:** app is intentionally built to run on already existing and popular runtimes to reduce footprint
- **event driven:** does not use any background resources at all
- **performance:** only filters newly renamed or created files
- **customizable:** create your own filters inside the app

## Installation

### Pre-requisites

- Ensure you have the .NET 8.0 runtime installed on your machine. You can download it from [here](https://dotnet.microsoft.com/download/dotnet/8.0).

### Steps

1. Download the latest release of FilterBox from the [releases page](https://github.com/Techial/FilterBox/releases/latest).
2. Extract the downloaded zip file to a directory of your choice.
3. Run `FilterBox.exe` to start the application.

## Description

Have you ever tried coding with Dropbox so you could sync progress and local commits between your computers?
If yes, I'm certain you've Googled **"How to ignore folders Dropbox"**, and found that there's really no easy way out other than having to manually run a Powershell or Shell command every time you create a new app.

This software aims to solve this, by always running in the background checking all file changes to see if they match your filters, and then automatically tells Dropbox to ignore uploading these files and/or folders.
Not only does it save your limited Dropbox storage space for other important stuff, it reduces the amount of bandwith used while developing. I've seen 1GB+ `node_modules` folders. That's **50% of your free Dropbox storage**.

[Download the app](https://github.com/Techial/FilterBox/releases/latest) or check out the source code above, and reserve your cloud storage for the more important files.

## Screenshots

### Main UI:

![FilterBox UI](/Images/FilterBox.png)

### System tray

![System Tray Menu](/Images/SystemTray.png)

## UI

I'll have to admit that UI really wasn't a priority on this project, but I'll gladly accept any help provided. There's really no limit to how far you can go. If you need help translating the app into a library for your own UI, I'll assist.

Open an [issue](https://github.com/Techial/FilterBox/issues/new) and ping me @Techial :)

## Support

Open an issue if you feel like anything needs to be added. I'll gladly review pull requests and merge them if deemed to be useful!
