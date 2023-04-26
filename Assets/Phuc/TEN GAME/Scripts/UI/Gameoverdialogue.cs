using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PHUC.BasicGame
{
    public class Gameoverdialogue : Dialogue
    {
        public Text bestScoreText;

        public override void show(bool isshow)
        {
            base.show(isshow);
            if(bestScoreText != null)
            {
                bestScoreText.text = Playerpref.bestScore.ToString("0000");
            }    
        }
        public void Replay()
        {
            Close();
            SceneManager.LoadScene(ConstClass.Gameplay_Scene);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
