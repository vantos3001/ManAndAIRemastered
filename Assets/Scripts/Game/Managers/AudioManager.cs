using Game;
using Game.Dialogue;
using UnityEngine;

public static class AudioManager
{
    private static AudioSource MusicSource;
    private static AudioSource SoundSource;
    
    public static void Load()
    {
        MusicSource = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        SoundSource = GameObject.FindWithTag("Sound").GetComponent<AudioSource>();

        EventManager.DialoguePhraseChanged += OnDialoguePhraseChanged;
    }

    private static void OnDialoguePhraseChanged(DialogueNode node)
    {
        if (!string.IsNullOrEmpty(node.GetMusicName()))
        {
            PlayMusic(node.GetMusicName());
        }
        
        if (!string.IsNullOrEmpty(node.GetSoundName()))
        {
            PlaySound(node.GetSoundName());
        }

        if (node.GetAction() == "stop_audio")
        {
            ClearAll();
        }
    }

    private static void PlayMusic(string musicName)
    {
        var audioClip = DataManager.GetMusic(musicName);
        MusicSource.clip = audioClip;
        MusicSource.Play();
    }
    
    private static void PlaySound(string soundName)
    {
        var audioClip = DataManager.GetSound(soundName);
        SoundSource.clip = audioClip;
        SoundSource.Play();
    }

    private static void ClearSound()
    {
        SoundSource.Stop();
    }
    
    private static void ClearMusic()
    {
        MusicSource.Stop();
    }

    private static void ClearAll()
    {
        ClearMusic();
        ClearSound();
    }
}
