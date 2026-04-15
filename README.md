# Retro FPS Vertical Slice (2000s Style)

A small, playable early-2000s-inspired FPS vertical slice built in Unity. The focus is tight gameplay feel (movement + hitscan shooting), clean architecture, and portfolio-ready packaging.

## What this project demonstrates
- First-person controller (CharacterController), mouse look (yaw/pitch clamp)
- Hitscan weapon with fire cooldown, ammo, and timed reload
- Data-driven tuning via ScriptableObject (WeaponConfig)
- Damageable targets + hit feedback (hit marker + target hit flash)
- Minimal HUD (crosshair + ammo)
- Debug-first workflow (gizmos, visual ray debug)
- Basic scope control and “vertical slice” delivery discipline

## Controls
- **WASD** — Move
- **Mouse** — Look
- **Left Shift** — Sprint
- **Space** — Jump
- **LMB (hold)** — Fire
- **R** — Reload
- **T** — Reset level (reload scene)

## Features
- One weapon (pistol): hitscan raycast, cooldown, ammo, timed reload
- One target type: damageable dummy with hit flash + death (deactivates)
- One small level: multi-room blockout with practice targets
- Minimal feedback loop: muzzle flash + SFX, hit marker, ammo HUD

## How to run (Windows build)
1. Download the latest Windows build from **Releases**.
2. Extract the `.zip`.
3. Run the `.exe` inside the extracted folder.

> Note: share the full build folder (the `.exe` + `*_Data` + any `.dll` files). The `.exe` alone is not enough.

## How to run in Unity
- Unity: **Unity 6** (Built-in Render Pipeline)
- Open scene: `Assets/_Project/Scenes/Main.unity`
- Press Play

## Tech notes (architecture)
- `RetroSlice.Player.PlayerController`  
  CharacterController movement + sprint + jump + gravity.
- `RetroSlice.Player.PlayerLook`  
  Yaw on Player root, pitch on CameraPivot with clamping.
- `RetroSlice.Combat.HitScanShooter`  
  Camera-origin raycast, cooldown gate, ammo + timed reload, muzzle flash + SFX, calls Damageable and HitMarker.
- `RetroSlice.Weapons.WeaponConfig` (ScriptableObject)  
  Centralized tuning (range/cooldown/ammo/reload).
- `RetroSlice.Combat.Damageable`  
  Health + simple death + hit flash reaction.
- `RetroSlice.UI.HUDController`  
  Minimal ammo UI update.
- `RetroSlice.UI.HitMarkerUI`  
  CanvasGroup-based hit marker flash.
- `RetroSlice.Debugging.DebugGizmos`  
  Forward ray + ground marker to debug aim and grounding.
- `RetroSlice.Core.GameBootstrap`  
  Reset hotkey (T) via scene reload.

## Screenshots / GIFs
> Add 3–6 screenshots and 1–2 short GIFs here.

- `./_images/1_M1-T1_structure_and_first_scene.png`
- `./_images/2_M2-T5_Firing_and_Reload.mkv`
- `./_images/2_M2-T5_HitScanShooter_with_PistolConfig_and_audio.png`
- `./_images/3_M4_Shooting_with_HUD_visible.png`
- `./_images/4_M4_Shooting_hit_marker_moment.png`
- `./_images/5_M4_Room_Layout.png`

## Roadmap (small next steps)
- Convert input fully to the New Input System Actions (remove legacy axes usage).
- Replace Instantiate/Destroy muzzle flash with simple pooling (micro-optimization).
- Add optional WebGL build if it stays low-effort.

## Known issues / limitations
- Input handling currently uses compatibility during prototyping (legacy axes may still be used).
- Muzzle flash is instantiated per shot (acceptable for slice; pooling is a future polish).
- Blockout visuals are intentionally simple to keep the 2000s vibe and scope tight.

## Links
- Repo: https://github.com/bubaleh1337/retro-fps-vertical-slice
- LinkedIn: https://www.linkedin.com/in/ekaterina-pyshkova/
- Latest build: (GitHub Releases)