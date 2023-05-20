using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PHUC.BasicGame
{
   
    public class TickBoss : MonoBehaviour
    {
       

        public void TickBS(bool tick)
        {
            gameObject.SetActive(tick);
        }    
    }
}
