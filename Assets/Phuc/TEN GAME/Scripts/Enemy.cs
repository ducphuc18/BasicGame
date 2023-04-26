using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PHUC.BasicGame
{
    public class Enemy : MonoBehaviour,IcomponentChecking
    {
        public float speed;
        private Rigidbody2D m_rigid;
        public float actDistace;
        private Animator m_amin;
        private Player player;
        private bool m_isdead;
        private Gamenanager M_gameManager;
        public int minCoinBonus;
        public int maxCoinBonus;
        
        void Start()
        {
            m_amin = GetComponent<Animator>();
            m_rigid = GetComponent<Rigidbody2D>();
            player = FindObjectOfType<Player>();
            M_gameManager = FindObjectOfType<Gamenanager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (iscomponentNull()) return;
            if(Vector2.Distance(player.transform.position, m_amin.transform.position) <= actDistace)
            {
                m_rigid.velocity = Vector2.zero;
                m_amin.SetBool(ConstClass.Attack_Amin,true);
            }
            else
            {
                m_rigid.velocity = new Vector2(-speed, 0);
            }
        }
        public bool iscomponentNull()
        {
            return m_amin == null || m_rigid == null || M_gameManager == null;
        }    
        public void Die()
        {
            if(!m_isdead )
            {
                m_amin.SetTrigger(ConstClass.Dead_Amin);
                m_rigid.velocity = Vector2.zero;
                gameObject.layer = LayerMask.NameToLayer(ConstClass.Dead_Layer);
                m_isdead = true;
                M_gameManager.score++;
                
                int coinBonus = Random.Range(minCoinBonus,maxCoinBonus);
                Playerpref.coins += coinBonus;
                if(M_gameManager.guiManager)
                {
                    M_gameManager.guiManager.UpdateGamePLayCoins();
                }    
               
                Destroy(gameObject, 2);
            }    
           
        }    
       
    }
}
