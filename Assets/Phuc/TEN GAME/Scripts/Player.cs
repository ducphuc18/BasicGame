using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PHUC.BasicGame
{
    public class Player : MonoBehaviour,IcomponentChecking
    {
        private Animator m_amin;
        public float actRate;
        private float curActRate;
        bool isattacked;
        bool isdead;
        private Gamenanager m_gameManager;
        // Start is called before the first frame update
        void Start()
        {
            m_amin = GetComponent<Animator>();
            curActRate = actRate;
            m_gameManager = FindObjectOfType<Gamenanager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isattacked)
            {
                if (m_amin)
                {
                    m_amin.SetBool(ConstClass.Attack_Amin, true);
                }
                isattacked = true;

            }

            if (isattacked)
            {
                curActRate -= Time.deltaTime;
                if (curActRate <= 0)
                {
                    isattacked = false;
                    curActRate = actRate;
                }
            }
        }
        public void PlayAttackSound()
        {
            if(m_gameManager.audioController)
            {
                m_gameManager.audioController.PlaySound(m_gameManager.audioController.playerAttackSound);
            }    
        }    
        public bool iscomponentNull()
        {
            return m_amin == null || m_gameManager == null ;
        }    
        public void resetAtackAmin()
        {
            m_amin.SetBool(ConstClass.Attack_Amin, false);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(ConstClass.Enemy_Weapon_Tag) && !isdead)
            {
                m_amin.SetTrigger(ConstClass.Dead_Amin);
                isdead = true;
                gameObject.layer = LayerMask.NameToLayer(ConstClass.Dead_Layer);
                m_gameManager.GameOver();
            }
        }
    }
}
