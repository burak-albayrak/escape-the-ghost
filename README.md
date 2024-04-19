# Ghost Chase Game

## Overview

Ghost Chase is a 2D arcade-style game developed using Unity. The game challenges players to navigate through various levels while avoiding ghosts and collecting prizes. The game becomes more challenging with each level, testing the player's reflexes and strategy.

## Features

### Key Features

- **Multiple Levels**: The game offers four unique levels, each with its own set of challenges, enemies, and environments.
- **Dynamic Ghost Movement**: Ghosts move unpredictably, making each playthrough different and challenging.
- **Interactive Gameplay**: Players must collect prizes while evading ghosts and navigating obstacles.
- **Game Over Screen**: A detailed game over screen shows the player's score and provides an option to restart or return to the main menu.

### Additional Features

- **Randomized Prize Locations**: Prizes appear at random locations in each level, adding an element of surprise.
- **Collision Detection**: The game uses collision detection to handle interactions between the player, ghosts, and other objects.
- **Scoring System**: Players earn points for each prize collected, with bonus points for completing levels quickly.

## Gameplay

### Controls

- **Movement**: Use the arrow keys or WASD keys to move the player character.

### Objectives

- **Collect Prizes**: Navigate the player to collect prizes scattered across the level.
- **Avoid Ghosts**: Ghosts roam the levels and must be avoided to prevent losing a life.
- **Reach the Exit**: Each level has an exit that the player must reach to progress to the next level.

## Ghost Types

### Normal Ghost

- **Color**: Blue, Yellow
- **Movement**: Moves in a straight line until it encounters an obstacle or changes direction.
- **Speed**: Moderate
- **Behavior**: Wanders aimlessly around the level, changing direction when it hits a wall or obstacle.

### Red Ghost

- **Color**: Red
- **Movement**: Moves erratically and follows the player.
- **Speed**: Fast
- **Behavior**: Aggressively chases the player when within a certain range, otherwise roams randomly.

## Setup and Installation

### Prerequisites

- **Unity Hub**: Make sure you have Unity Hub installed.
- **Unity 2019 or Later**: The project requires Unity 2019 or a later version.

### Technologies Used

- **Unity Game Engine**: The game is built using Unity, a popular game development engine.
- **C# Programming Language**: The game logic and mechanics are implemented using C#.

### Code Structure

- **GameOverScreen**: Manages the game over screen and displays the player's score.
- **GhostScript**: Controls the movement and behavior of ghosts, including both normal and red ghosts.
- **MainMenu**: Handles interactions in the main menu and starts the game.
- **PlayerScript_lvlX**: Manages player movement and interactions for each level (X represents the level number).
