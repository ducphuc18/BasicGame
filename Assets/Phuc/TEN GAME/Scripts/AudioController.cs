using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PHUC.BasicGame
{
    public class AudioController : MonoBehaviour
    {
        [Header("Main Setting :")]
        [Range(0f,1f)]
        public float musicVolume = 0.3f;
        [Range(0f, 1f)]
        public float soundVolume = 1f;
        public AudioSource musicAudioSource;
        public AudioSource soundAudioSource;

        [Header("Music and sound in game")]
        public AudioClip playerAttackSound;
        public AudioClip enemyDeadSound;
        public AudioClip gameOver;
        public AudioClip[] backGroundMusic;


       public void PlaySound(AudioClip[] sounds, AudioSource audioSource = null)
        {
            if(audioSource == null)
            {
                audioSource = soundAudioSource;
            }
            if (audioSource == null) return;
            if (sounds == null || sounds.Length <= 0) return;
            int randomIndex = Random.Range(0,sounds.Length);
            if(sounds[randomIndex])
            {
                audioSource.PlayOneShot(sounds[randomIndex],soundVolume);
            }    

        }  
        public void PlaySound(AudioClip sound, AudioSource audioSource = null)
        {
            if(audioSource == null)
            {
                audioSource = soundAudioSource;
            }
            if (audioSource == null) return;
            if(sound)
            {
                audioSource.PlayOneShot(sound,soundVolume);
            }    
        }    

       public void PlayMusic(AudioClip[] musics,bool islooped = true )
        {
            if(musics == null || musics.Length <= 0) return;
            int randomIndex = Random.Range(0,musics.Length);
            if(musics[randomIndex])
            {
                musicAudioSource.clip = musics[randomIndex];
                musicAudioSource.loop = islooped;
                musicAudioSource.volume = musicVolume;
                musicAudioSource.Play();
            }    
        }
        public void PlayMusic(AudioClip music, bool islooped = true)
        {
            if (musicAudioSource == null || music == null) return;
            musicAudioSource.clip = music;
            musicAudioSource.loop = islooped;
            musicAudioSource.volume = musicVolume;
            musicAudioSource.Play();

        }
        public void SetMusicVolume(float volume)
        {
            if(musicAudioSource == null) return;
            musicAudioSource.volume = volume;
        }   
        public void StopMusic()
        {
            if (musicAudioSource == null) return;

            musicAudioSource.Stop();
        }    
        public void BackGroundMusic()
        {
            PlayMusic(backGroundMusic); // van goi ra duoc vi gia tri bool da duoc gan gia tri
        }    
    }
}    
