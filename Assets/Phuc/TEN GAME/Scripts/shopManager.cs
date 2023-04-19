using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PHUC.BasicGame
{
    public class shopManager : MonoBehaviour
    {
       public shopItem[] items;
        void Start()
        {
            Init();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Init()
        {
            if (items == null || items.Length <= 0) return;
            for(int i = 0; i < items.Length; i++)
            {
                var item = items[i];
                string dataKey = ConstClass.Player_Prefix_Pref + i;
                if(i == 0)
                {
                  Playerpref.setBool(dataKey, true);
                }
                else
                {
                    if(!PlayerPrefs.HasKey(dataKey))
                    {
                        Playerpref.setBool(dataKey, false);
                    }    
                    
                }    
            }    
        }
    }
}    
