using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PHUC.BasicGame
{
    public class Gamenanager : MonoBehaviour
    {
        public float spawnTime;
        public Enemy[] enemies;
        private bool isGameOver;
        private int m_score;
        public int score { get => m_score; set => m_score = value; }
        void Start()
        {
            StartCoroutine(SpawnEnemy());
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
    }
}
