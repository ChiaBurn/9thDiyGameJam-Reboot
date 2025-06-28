# ReboBot: A Puzzle Game about Repairing Machines

**ReboBot** is a short, story-driven puzzle game developed in Unity 6 for the 
"9th DIY Game Jam: Reboot".  
You play as a maintenance robot following the commands of a researcher to repair machines using puzzle-based mechanics.

---

## 🧩 Gameplay Overview

- The game consists of two stages, each containing three puzzle levels and a stage-end score summary.

- Each level follows this structure:
  - **Intro Scene**: The level starts with a narrative sequence, including an image of the machine to be repaired and multiple dialogue lines from the researcher.
  - **Puzzle Phase**: Players complete a jigsaw puzzle by placing all pieces into the board. Once all pieces are placed, the level ends.
  - **Result Scene**: Based on puzzle accuracy, a success or failure image is shown, followed by corresponding dialogue.

- After each stage (three levels), a **Scoreboard** appears, showing:
  - A star rating (0 to 3) based on successful repairs
  - Commentary based on performance
  - Clicking the scoreboard proceeds to the next stage

- If the player fails all levels in Stage 1, the game restarts from the beginning. Stage 2 also ends the game.

---

## 👨‍💻 My Role

I served as the sole programmer for the team and developed the entire game using **Unity 6**.  
This was my first time using Unity. Prior to this, I had only used Godot for game development.

---

## ⚙️ Technical Highlights

- Built a **dynamic jigsaw puzzle system** that slices an image into configurable segments, enabling difficulty scaling.
- Developed a **narrative dialogue system** using `Queue<T>` and `yield return new WaitForSeconds()` to display multi-line, typewriter-style dialogue with adjustable speed.
- Managed global state, scoring, and scene transitions using **Singleton patterns**.
- Implemented smooth **fade-in/fade-out transitions** using Unity's `Animation` system.

---

## 💡 Challenges & Future Improvements

- **Hardcoded story text** in the code made narrative editing time-consuming and required new builds for each change. Future versions should load dialogue from external files (e.g., JSON or CSV), allowing non-programmers to edit content directly. Localization for English/Chinese is also planned.
- Initially planned to include other puzzle types (e.g., swapping or sliding puzzles), but these were cut due to time constraints. We used puzzle complexity (number of pieces) to simulate difficulty variation.
- Designed for vertical mobile screens to support casual players and family/friends, but the current layout causes excessive zoom on desktop browsers. Future versions should better support both screen formats.
- The **scoreboard** currently switches between different images based on results; ideally, this should be implemented using UI components and logic for better scalability.
- The game lacks a **Main Menu** and **Ending Scene**, which impacts the overall polish and user experience.

---

## 📎 Links

- 🔗 Play on itch.io: https://chiaburn.itch.io/rebobot
- 👩‍💻 Source code: https://github.com/ChiaBurn/9thDiyGameJam-Reboot
- ▶️ Gameplay video: https://www.youtube.com/watch?v=PoXL3IEu_rs

---

👥 Team & Credits

Game Design & Narrative Design: riverRobot

Game Design & Jigsaw Puzzle Art: InsaneBanana

Programming: Chia-Hui (me)

Art & Visual Assets: [xuanshao 玄少](https://lit.link/en/xuanshao1965) (All images are protected and may not be downloaded, reused, or used in AI training in any form.)

---

Let me know if you’d like to collaborate, give feedback, or discuss puzzle-based narrative games. Thanks for checking out ReboBot!
