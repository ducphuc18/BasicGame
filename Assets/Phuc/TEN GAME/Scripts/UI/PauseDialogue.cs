using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PHUC.BasicGame
{
    public class PauseDialogue : Dialogue
    {
        public override void show(bool isshow)
        {
            base.show(isshow);
            Time.timeScale = 0f;
        }
        public override void Close()
        {
            base.Close();
            Time.timeScale = 1f;
        }
        public void Resume()
        {
            Close();
        }    
        public void Replay()
        {
            SceneManager.LoadScene(ConstClass.Gameplay_Scene);
            Close();
        }    
    }
}
   
