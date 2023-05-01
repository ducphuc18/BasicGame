using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PHUC.BasicGame
{
    public class SettingDialogue : Dialogue,IcomponentChecking
    {
        public Slider musicSlider;
        public Slider soundSlider;
        private AudioController m_audioController;
        public bool iscomponentNull()
        {
            return m_audioController == null || musicSlider == null || soundSlider == null;
        }
        public override void show(bool isshow)
        {
            base.show(isshow);
            m_audioController = FindObjectOfType<AudioController>();
            if (iscomponentNull()) return;
            musicSlider.value = Playerpref.musicVol;
            soundSlider.value = Playerpref.soundVol;
        }
        public void OnMusicChange(float value)
        {
            if (iscomponentNull()) return;
            m_audioController.musicVolume = value;
            m_audioController.musicAudioSource.volume = value;
            Playerpref.musicVol = value;
        }    
        public void OnSoundChange(float value)
        {
            if (iscomponentNull()) return;
            m_audioController.soundVolume = value;
            m_audioController.soundAudioSource.volume = value;
            Playerpref.soundVol = value;
        }    


    }
}
