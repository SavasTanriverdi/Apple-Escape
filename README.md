```markdown
# Apple Escape

This is a Unity-based game project where the player collects apples and avoids enemies to complete levels.

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Scripts Overview](#scripts-overview)
  - [Player](#player)
  - [GameDirector](#gamedirector)
  - [EnemyManager](#enemymanager)
  - [Enemy](#enemy)
- [Contributing](#contributing)
- [License](#license)

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/SavasTanriverdi/game-project.git
   ```
2. Open the project in Unity.

## Usage

- Use `W`, `A`, `S`, `D` keys to move the player.
- Press `Left Shift` to run.
- Collect apples to unlock the door.
- Avoid enemies to stay alive.
- Press `R` to restart the level.

## Project Structure

```
Assets/
├── Scripts/
│   ├── Elements/
│   │   ├── Player.cs
│   │   ├── Enemy.cs
│   ├── Manager/
│   │   ├── GameDirector.cs
│   │   ├── EnemyManager.cs
├── Prefabs/
│   ├── Enemy.prefab
│   ├── Player.prefab
│   ├── ZPrefab.prefab
```

## Scripts Overview

### Player

The `Player` script handles player movement, collision detection, and interactions with collectable items and doors.

### GameDirector

The `GameDirector` script manages the overall game state, including restarting levels and handling level completion.

### EnemyManager

The `EnemyManager` script is responsible for creating, deleting, and managing enemies in the game.

### Enemy

The `Enemy` script controls enemy behavior, including following the player and handling animations.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes.

## License

This project is licensed under the MIT License.
```
