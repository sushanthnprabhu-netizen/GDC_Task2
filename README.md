# IITK Game Dev Recruitment Tasks

## Project Structure

This Unity project contains 3 scenes:

### Task-1 → Movement Feel Fix
Improved platformer movement system with polished jumping mechanics.

### Task-2 → Enemy AI System
Modular enemy AI system containing:
- melee enemies
- ranged enemies
- scout/security camera system
- enemy communication and alert behavior

### Task-3 → Ghost Replay System
Replay-based movement recording system with timed playback and death replay.

---

# Controls

## Task-1 / Task-2 / Task-3

- A / D → Move
- Space → Jump
- R → Manual Ghost Replay

---

# Task-1 Improvements

Problems Fixed:
- inconsistent movement feel
- weak coyote time
- weak jump buffering
- unstable ground detection
- incorrect jump reset behavior

Changes Made:
- improved velocity-based movement
- improved jump timing
- cleaner movement responsiveness
- improved ground check system
- smoother jump handling

---

# Task-2 Enemy AI System

Implemented Systems:
- patrol enemy behavior
- melee enemy chase and attack
- ranged enemy distance management
- scout/security camera behavior
- player detection system
- enemy alert communication
- patrol return behavior

Architecture:
- modular inheritance-based enemy system
- reusable EnemyManager base class
- separated melee, ranged, and scout logic
- interaction-focused AI behavior

---

# Task-3 Ghost Replay System

The replay system records player movement and replays previous actions using timed replay data.

Recorded Data:
- player movement
- jump timing
- idle timing
- replay timestamps

Features:
- interval-based replay recording
- timer-based replay playback
- double jump support
- death-triggered replay
- replay cleanup system
- replay spam prevention
- transparent ghost visuals
- memory optimized recording

The system focuses on replay consistency, cleaner architecture, and reliable playback behavior.

---

