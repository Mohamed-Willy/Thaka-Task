🧠 Thaka Task – ZERO1 Skills Unity Developer Project
This project was developed as part of the ZERO1-Skills Unity Developer interview task. It simulates an educational robot scenario where a player collects points by navigating to specific zones.

🛠 Unity Version
Unity 6000.0.25f1

🚀 How to Run
1- Clone the repository:
      git clone https://github.com/Mohamed-Willy/Thaka-Task.git
2- Open the project via Unity Hub using the specified Unity version.
3- Open the main scene (e.g., MainScene or the scene available in /Assets/Scenes/).
4- Press Play to begin the simulation.

🎮 Gameplay Features
Feature	Description
Player Movement	Controlled via WASD or Arrow keys using NavMeshAgent.
Camera Follow	Dynamic third-person camera that follows the player.
Scoring System	Earn +10 points when reaching a target zone.
UI Feedback	Real-time score display using TextMeshPro.
Auto Save/Load	Score is saved/loaded automatically using JSON + PlayerPrefs.
Gamification	Motivational feedback, animations, and optional enhancements.

🧾 Scripts Overview
Script Name	Purpose
PlayerController.cs	Controls movement using NavMeshAgent + animation blending.
CameraFollower.cs	Smooth third-person camera follow.
ZoneHandler.cs	Handles zone trigger, awards points, and destroys zone object.
ScoreViewer.cs	Displays current score and supports reset functionality.
DataManager.cs	Singleton class for saving/loading player data as JSON.
PlayerData.cs	Stores and modifies player score.

📁 Folder Structure
bash
Copy
Edit
Assets/
│
├── Scenes/
│   └── MainScene.unity
│
├── Scripts/
│   ├── PlayerController.cs
│   ├── CameraFollower.cs
│   ├── ZoneHandler.cs
│   ├── ScoreViewer.cs
│   ├── DataManager.cs
│   └── PlayerData.cs
│
├── Prefabs/           # (if used)
├── UI/                # UI elements like canvas and buttons

📌 Notes & Assumptions
All game objects are built using Unity primitives (e.g., Cube, Plane).
Player movement is handled by Unity’s NavMeshAgent system.
Score data is serialized to playerdata.json and stored using PlayerPrefs.
The camera follows the player in a third-person perspective.

🎉 Bonus Features
Modular and decoupled design using DataManager singleton.
Clean folder and script organization.
Score reset support with real-time UI updates
Debug logs for save/load visibility.

🧪 Tested On
Windows 10 using the Unity Editor
