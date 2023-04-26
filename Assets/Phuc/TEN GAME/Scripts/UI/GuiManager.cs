using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PHUC.BasicGame
{
    public class GuiManager : MonoBehaviour
    {
        public GameObject homeGui;
        public GameObject gameGui;
        public Dialogue gameOverDialogue;
        public Text mianCoinText;
        public Text gamePlayCoinText;

        public void ShowGameGUI(bool isshow)
        {
            if(homeGui)
            {
                homeGui.SetActive(!isshow);
            } 
            if(gameGui)
            {
                gameGui.SetActive(isshow);
            }    
        }  
        public void UpdateMainCoins()
        {
            if(mianCoinText)
            {
                mianCoinText.text = Playerpref.coins.ToString();
            }    
        } 
        public void UpdateGamePLayCoins()
        {
            if(gamePlayCoinText)
            {
                gamePlayCoinText.text = Playerpref.coins.ToString();
            }    
        }    
    }    
}
