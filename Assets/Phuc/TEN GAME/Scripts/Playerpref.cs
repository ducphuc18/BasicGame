using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PHUC.BasicGame
{
    public static class Playerpref
    {
        public static int bestScore
        {
            set
            {
                int oldScore = PlayerPrefs.GetInt(ConstClass.Best_Score_Pref, 0);
                if (oldScore < value)
                {
                    PlayerPrefs.SetInt(ConstClass.Best_Score_Pref, value);
                }

            }
            get => PlayerPrefs.GetInt(ConstClass.Best_Score_Pref, 0);

        }
        public static int curPlayerId
        {
            set => PlayerPrefs.SetInt(ConstClass.Cur_Player_Id_Pref, value);
            get => PlayerPrefs.GetInt(ConstClass.Cur_Player_Id_Pref, 0);
        }
        public static int coins
        {
            set => PlayerPrefs.SetInt(ConstClass.Coin_Pref, value);
            get => PlayerPrefs.GetInt(ConstClass.Coin_Pref,0);
        }
        public static float musicVol
        {
            set => PlayerPrefs.SetFloat(ConstClass.Music_Vol_Pref, value);
            get => PlayerPrefs.GetFloat(ConstClass.Music_Vol_Pref, 0);
        }
        public static float soundVol
        {
            set => PlayerPrefs.SetFloat(ConstClass.Sound_Vol_Pref,value);
            get => PlayerPrefs.GetFloat (ConstClass.Sound_Vol_Pref, 0);
        }
        public static void setBool(string key, bool value)
        {
            if(value)
            {
                PlayerPrefs.SetInt(key, 1);
            }
            else
            {
                PlayerPrefs.SetInt(key, 0);
            }
        }
        public static bool getBool(string key)
        {
            return PlayerPrefs.GetInt(key) == 1?true:false;
        }
    }
   
}
