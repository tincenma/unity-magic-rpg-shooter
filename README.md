# Unity 3D Magic Shooter

## Overview
A mini 3D magic shooter game prototype built with Unity 2022.3.12f1. It demonstrates a fully animated character with first‑person and third‑person cameras, smooth movement, magic casting, and pause functionality.

## Features
- **Camera Modes**: Press `V` to toggle between first‑person and third‑person views.
- **Movement**: Walk, run (hold `Left Shift`), and jump (`Space`).
- **16‑Direction Animations**: Blend Trees for smooth directional movement and separate jump animations.
- **Magic Casting**:
  - Orb spawn in a hand while casting.
  - Shooting spawns projectile with splash and hit effects.
- **Sound Effects**: Casting and hit sounds synchronized with actions.
- **Pause Menu**: Press `Esc` to open/close pause menu; stops time and unlocks cursor.

## Controls
| Action                   | Key / Button            |
|--------------------------|-------------------------|
| Move                     | `W` / `A` / `S` / `D`    |
| Sprint                   | `Left Shift`             |
| Jump                     | `Space`                  |
| Look Around              | Mouse Move               |
| Cast Magic / Shoot       | Left Mouse Button        |
| Switch Camera            | `V`                      |
| Pause / Resume           | `Esc`                    |

## Installation
1. **Clone repository**:
   ```bash
   git clone https://github.com/yourusername/unity-magic-shooter.git
   ```
2. **Open** in Unity Hub with **Unity 2022.3.12f1 (LTS)**.
3. **Open** the scene `Assets/MyGame/Scenes/MainMenu.unity`.
4. **Play** the scene.

## Script Overview
- **PlayerController.cs**: Handles movement input, camera rotation, jump/run logic, and animation parameters.
- **PlayerMagic.cs**: Manages orb creation, attachment to hand, shooting logic, and audio for casting.
- **MagicProjectile.cs**: Controls projectile flight, lifetime, collision detection, hit effect, and hit sound.
- **MenuManager.cs**: Manages the transition between Unity scenes.

## Customization
- **Movement Settings**: Adjust speeds, gravity, and turning speed in `PlayerController` component.
- **Animation Tree**: Edit Blend Trees in the Animator Controller to swap or refine clips.
- **Magic Effects**: Swap particle prefabs (StarInHand, StarShootSplash, StarHit) in `PlayerMagic` and `MagicProjectile` components.
- **Audio**: Replace or adjust `shootClip` and `hitClip` in the respective scripts.
- **UI**: Modify UI layouts:
  - The pause menu `Assets/MyGame/Scenes/Game.unity` → `Canvas/PauseMenu`.
  - The main menu `Assets/MyGame/Scenes/MainMenu.unity` → `Canvas/MainMenu`.
  - The settings menu `Assets/MyGame/Scenes/Settings.unity` → `Canvas/SettingsMenu`.

## Dependencies
- Unity 2022.3 LTS
- (Optional) Cinemachine for camera smoothing.

## License
This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Credits
- **Unity Technologies**: Engine and Editor.
- **Particle Effects**: User‑created assets.
- **Audio Assets**: User‑created or royalty‑free sources.

