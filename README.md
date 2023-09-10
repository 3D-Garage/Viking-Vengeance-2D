# My 2D Unity Game Project

## Introduction

Welcome to the repository for my 2D Unity game. This project is under development and we welcome collaborators. I'm also relatively new to Unity, so if you find the initial setup overwhelming, don't worry—you're not alone. Most of the time, I also find myself searching for answers online. Feel free to ask questions or contribute to this project. This README aims to guide you through the setup process and give you an overview of the project.

## Table of Contents

- [Setup](#setup)
  - [Unity](#unity)
  - [Visual Studio 2022](#visual-studio-2022)
  - [GitHub Desktop](#github-desktop)
- [Branching Strategy](#branching-strategy)
- [Issue Tracking](#issue-tracking)
- [How to Contribute](#how-to-contribute)
- [Project Structure](#project-structure)
- [Support](#support)
- [Educational Links](#educational-links)

## Software Requirements

- **Unity 2022.3.8f1**
- **Visual Studio 2022**
- **GitHub Desktop**

## Setup

### Unity

1. Download and install [Unity](https://unity.com/)
2. Open Unity Hub and click on `Add` to include the project folder (For this you already had to clone it).

### Visual Studio 2022

1. Download and install [Visual Studio 2022]([https://visualstudio.microsoft.com/](https://visualstudio.microsoft.com/free-developer-offers/))
2. Here you need the "Game development with Unity" (WorkLoads), this you should be able to download when you first set up the VS, or you already have VS than you could get it from "Video Studio Installer"
3. Open the project in Unity and it should automatically open Visual Studio with the relevant scripts.

### GitHub Desktop

1. Download and install [GitHub Desktop](https://desktop.github.com/)
2. Open GitHub Desktop, go to `File -> Clone Repository` and enter the repository URL or form GitHub Website when you clone it there is an option to Open it with GitHub Desktop.

## Branching Strategy

**Protected Branches:**
- `master`: This is the production branch. Merging into this branch is restricted.
- `dev`: This is the development branch. All feature branches should be merged into this branch.

**Workflow:**

1. **Creating a new branch**: Always create a new branch for a feature or bugfix. 
2. **Changing Branch Source**: After creating the branch, click on "Change branch source" and select `dev` as the source branch.
3. **Opening in GitHub Desktop**: It's advisable to choose the "Open branch with GitHub Desktop" option for better branch management.

## Issue Tracking

Before starting any development work, you should:

1. Search for an existing issue related to the problem or feature you are working on.
2. If no issue exists, create a new issue describing the problem or feature.
3. Assign yourself to the issue.
4. Create a new branch linked to the issue following the [Branching Strategy] and [Workflow].

## How to Contribute

Since some members might not be familiar with Git and GitHub, we are using GitHub Desktop for easier management. Here's how to make a contribution:

1. Open GitHub Desktop.
2. Select this project from the list.
3. Click on `Fetch Origin` to get the latest changes.
4. Create a new branch for your features or fixes.
5. Open the project from Unity Hub
6. Make changes in Unity and/or Visual Studio 2022.
7. Commit your changes using GitHub Desktop, mentioning what you've done.
8. Click on `Push Origin` to upload your changes to your branch.
9. Create a Pull Request on GitHub and add an admin for __Review!__

## Project Structure

This Unity project uses a specific folder structure within the `Assets` directory to keep things organized. Please take a moment to familiarize yourself with this structure and try to maintain it as you contribute.

### Assets Folder Structure

Here are the main folders you'll find in the `Assets` directory:

- **Animations**: Contains all animation-related files.
- **Materials**: Holds material assets for 2D models and other objects.
- **Prefabs**: Stores predefined game objects that we use frequently.
- **Scenes**: Here you'll find all the different scenes used in the project.
- **Scripts**: Contains all the C# scripts.
- **Sprites**: Houses 2D images that are used in the game.
- **Standard Assets**: A collection of common assets provided by Unity.
- **Tiles**: Holds tile assets used for tilemaps.

Please adhere to this structure when adding new files or modifying existing ones.

## Educational Links

Most of the time I have no idea how to do something, so most of the times im just searching the internet for answers.

Here are some resources for further study:
- [Youtube - Unity Basics](https://www.youtube.com/watch?v=Ii-scMenaOQ&list=PLrnPJCHvNZuCVTz6lvhR81nnaf1a-b67U) - A complete beginner's guide to Unity.
- [Traps in Unity](https://www.youtube.com/watch?v=5EesvCG9_FA&t=10s) - A tutorial for implementing traps in Unity games.


**Documentations:**

- [Unity Documentation](https://docs.unity.com/)
- [Visual Studio Tips and Tricks](https://visualstudiotipsandtricks.com/)
- [GitHub Guides](https://guides.github.com/)

## Support

For any questions or support, please open an issue or contact the project maintainer.
