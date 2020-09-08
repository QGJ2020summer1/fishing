﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public enum SoundEffectType {
    gameStart,
    getScore,
    tenbin,
    gameEnd,
    hari

}

public enum BackGroundMusicType {
    bgm_main,
}


public class SoundPlayer : MonoBehaviour {

    [SerializeField]
    SoundTable soundTable;

    [SerializeField]
    MusicTable musicTable;

    public static SoundPlayer instance;

    AudioSource[] sources;

    void Start() {
        instance = this;
        sources = GetComponents<AudioSource>();
    }

    public void PlaySoundEffect(SoundEffectType type, float vol = 1f) {
        var free = sources.Where(s => !s.isPlaying).FirstOrDefault();
        if(free == null) return;
        free.clip = soundTable.GetTable()[type];
        free.volume = vol;
        free.Play();
    }

    public void PlayBackGroundMusic(BackGroundMusicType type) {
        AudioSource source = sources.Last();
        source.clip = musicTable.GetTable()[type];
        source.Play();
    }

    [System.Serializable]
    public class SoundTable : Serialize.TableBase<SoundEffectType, AudioClip, SoundPair>{
    }


    [System.Serializable]
    public class SoundPair : Serialize.KeyAndValue<SoundEffectType, AudioClip>{
        public SoundPair (SoundEffectType key, AudioClip value) : base (key, value) {
        }
    }

    [System.Serializable]
    public class MusicTable : Serialize.TableBase<BackGroundMusicType, AudioClip, MusicPair>{
    }


    [System.Serializable]
    public class MusicPair : Serialize.KeyAndValue<BackGroundMusicType, AudioClip>{
        public MusicPair (BackGroundMusicType key, AudioClip value) : base (key, value) {
        }
    }

}


