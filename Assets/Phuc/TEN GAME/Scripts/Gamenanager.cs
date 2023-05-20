using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PHUC.BasicGame
{
    public class Gamenanager : MonoBehaviour,IcomponentChecking
    {
        public float spawnTime;
        public Enemy[] enemies;
        public GuiManager guiManager;
        private bool isGameOver;
        private int m_score;
        private  Player m_curPlayer;
        public shopManager m_shopManager;
        public AudioController audioController;
        public int score { get => m_score; set => m_score = value; }//score = m_score
        void Start()
        {
            

            if (iscomponentNull()) { return; }
            guiManager.ShowGameGUI(false);
            guiManager.UpdateMainCoins();
            


        }
        public void playGame()
        {
            if(iscomponentNull()) { return; }
            ActivePlayer();
            StartCoroutine(SpawnEnemy());
            guiManager.ShowGameGUI(true);
            guiManager.UpdateGamePLayCoins();
            audioController.BackGroundMusic();
            
        }
        public void GameOver()
        {
            if(isGameOver) { return; }
            isGameOver = true;
            Playerpref.bestScore = m_score;
            if (guiManager.gameOverDialogue) 
            {
                guiManager.gameOverDialogue.show(true);
            }
            audioController.PlaySound(audioController.gameOver);
            
        }

        IEnumerator SpawnEnemy()
        {
            while(!isGameOver)
            {
                if (enemies != null&& enemies.Length > 0)
                {
                    int enemyIndex = Random.Range(0, enemies.Length);
                    Enemy enemy = enemies[enemyIndex];
                    if (enemy != null)
                    {
                        Instantiate(enemy, new Vector3(11, 0, 0), Quaternion.identity);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }    
            
        }
        public void ActivePlayer()
        {
            if (iscomponentNull()) return;
            if (m_curPlayer != null)
            {
                Destroy(m_curPlayer.gameObject);
            }
            var shopItems = m_shopManager.items;
            if (shopItems == null || shopItems.Length <= 0) return;
            var newPlayerPb = shopItems[Playerpref.curPlayerId].playerPref;
            if(newPlayerPb != null)
            {
                m_curPlayer = Instantiate(newPlayerPb, new Vector3(-7.29f,-0.29f,0f),Quaternion.identity);
            }    
        }    
        public bool iscomponentNull()
        {
            return guiManager == null || m_shopManager == null || audioController == null;
        }    
    }
}
