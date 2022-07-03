using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [SerializeField]
    AudioSource bgmAudioSource;

    [SerializeField]
    AudioSource seAudioSource;

    [SerializeField]
    List<BGMSoundData> bGMSoundDatas;

    [SerializeField]
    List<SESoundData> sESoundDatas;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBGM(BGMSoundData.BGM bgm) {

        BGMSoundData data = bGMSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
     }

     public void PlaySE(SESoundData.SE se)
     {
        SESoundData data = sESoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
     }
}

[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        TITLE,
        PLAYING,
        GAMEOVER
    }

    public BGM bgm;
    public AudioClip audioClip;

    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        SHOT,
        HIT,
        MISS,
        GOOD,
    }

    public SE se;
    public AudioClip audioClip;

    [Range(0, 1)]
    public float volume = 1;
}
