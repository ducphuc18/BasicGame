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
        public int score { get => m_score; set => m_score = value; }
        void Start()
        {
            
            if (iscomponentNull()) { return; }
            guiManager.ShowGameGUI(false);
            guiManager.UpdateMainCoins();
              
        }
        public void playGame()
        {
            StartCoroutine(SpawnEnemy());
            guiManager.ShowGameGUI(true);
            guiManager.UpdateGamePLayCoins();
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
        public bool iscomponentNull()
        {
            return guiManager == null;
        }    
    }
}
