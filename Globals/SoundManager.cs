using Godot;
using System;
using System.Collections.Generic;

public partial class SoundManager : Node
{
    public const string SOUND_MAIN_MENU = "main";
    public const string SOUND_IN_GAME = "ingame";
    public const string SOUND_SUCCESS = "success";
    public const string SOUND_GAME_OVER = "gameover";
    public const string SOUND_SELECT_TILE = "tile";
    public const string SOUND_SELECT_BUTTON = "button";

    private static readonly Dictionary<string, AudioStream> SOUNDS = new Dictionary<string, AudioStream>
    {
        { SOUND_MAIN_MENU, GD.Load<AudioStream>("res://assets/sounds/bgm_action_3.mp3") },
        { SOUND_IN_GAME, GD.Load<AudioStream>("res://assets/sounds/bgm_action_4.mp3") },
        { SOUND_SUCCESS, GD.Load<AudioStream>("res://assets/sounds/sfx_sounds_fanfare3.wav") },
        { SOUND_GAME_OVER, GD.Load<AudioStream>("res://assets/sounds/sfx_sounds_powerup12.wav") },
        { SOUND_SELECT_TILE, GD.Load<AudioStream>("res://assets/sounds/sfx_sounds_impact1.wav") },
        { SOUND_SELECT_BUTTON, GD.Load<AudioStream>("res://assets/sounds/sfx_sounds_impact7.wav") }
    };

    public static SoundManager Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public static void PlaySound(AudioStreamPlayer player, string key)
    {
        if (!SOUNDS.ContainsKey(key))
            return;

        player.Stop();
        player.Stream = SOUNDS[key];
        player.Play();
    }

    public static void PlayButtonClick(AudioStreamPlayer player)
    {
        PlaySound(player, SOUND_SELECT_BUTTON);
    }

    public static void PlayTileClick(AudioStreamPlayer player)
    {
        PlaySound(player, SOUND_SELECT_TILE);
    }
}