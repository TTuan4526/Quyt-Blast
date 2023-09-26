using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioManager : MonoBehaviour
{
    public static AudioManager ins;

    private void Awake()
    {
        if (ins != null)
            Destroy(ins.gameObject);
        else
            ins = this;
    }

    [SerializeField] private AudioSource[] sfx;
    [SerializeField] private AudioSource[] bgm;

    public bool playBgm = true;
    private int bgmIndex;

    private void Update()
    {
        if (playBgm)
        {
            if (!bgm[bgmIndex].isPlaying)
                PlayBGM(bgmIndex);
        }
    }

    public void PlaySFX(int sfxIndex)
    {
        if (sfxIndex < sfx.Length)
        {
            sfx[sfxIndex].pitch = Random.Range(.85f, 1.1f);
            sfx[sfxIndex].Play();
        }
    }

    public void StopSFX(int index)
    {
        if (index < sfx.Length)
        {
            sfx[index].Stop();
        }
    }

    public void PlayRandomBGM()
    {
        bgmIndex = Random.Range(0, bgm.Length);
        PlayBGM(bgmIndex);
    }

    public void PlayBGM(int _bgmIndex)
    {
        bgmIndex = _bgmIndex;

        StopAllBGM();

        bgm[bgmIndex].volume = 0.5f;
        bgm[bgmIndex].Play();
    }

    public void StopAllBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
}

