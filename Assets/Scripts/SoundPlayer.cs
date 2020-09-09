using System.Collections;
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
    bgm_main_normal,
    bgm_main_angel,
    bgm_main_devil,
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

    public void PlayMainBackGroundMusic() {
        AudioSource normalSource = sources[sources.Length - 3];
        normalSource.clip = musicTable.GetTable()[BackGroundMusicType.bgm_main_normal];
        normalSource.volume = 0.8f;
        normalSource.Play();
        AudioSource angelSource = sources[sources.Length - 2];
        angelSource.clip = musicTable.GetTable()[BackGroundMusicType.bgm_main_angel];
        angelSource.volume = 0;
        angelSource.Play();
        AudioSource devilSource = sources[sources.Length - 1];
        devilSource.clip = musicTable.GetTable()[BackGroundMusicType.bgm_main_devil];
        devilSource.volume = 0;
        devilSource.Play();
    }

    public void ChangeMainBackGroundMusic(int normal, int angel, int devil) {
        AudioSource normalSource = sources[sources.Length - 3];
        AudioSource angelSource = sources[sources.Length - 2];
        AudioSource devilSource = sources[sources.Length - 1];
        normalSource.volume = normal;
        angelSource.volume = angel;
        devilSource.volume = devil;
    }

    IEnumerator ChangeMusicCoroutine(AudioSource from, AudioSource to) {
        float changeFrame = 2;
        for(int i = 0; i < changeFrame; i++) {
            from.volume = 0.8f * (1 - (float)i / changeFrame);
            to.volume = 0.8f * ((float)i / changeFrame);
            yield return null;
        }
        from.volume = 0;
        to.volume = 0.8f;

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


