using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PHUC.BasicGame
{
    public class shopItemUI : MonoBehaviour
    {
        public Text priceText;
        public Image hud;
        public Button button;

        public void UpdateUI(shopItem item, int itemIndex)
        {
            if (item == null) return;
            if(hud)
            {
                hud.sprite = item.previewImg;
            }
            bool isunlocked = Playerpref.getBool(ConstClass.Player_Prefix_Pref + itemIndex); // xem mo khoa hay chua ? // player_1
            
           // tiep den kiem tra 2 truong hop mo khoa hay chua
           if(isunlocked) // neu da mo khoa
            {
                if(Playerpref.curPlayerId == itemIndex) // neu chi so player hien tai dc chon bang chi so item
                {
                    if(priceText)
                    {
                        priceText.text = "ACTIVE"; // dang su dung // neu mo khoa va duoc lua chon
                    }    
                } else if(priceText)
                {
                    priceText.text = "OWNED"; // neu mo khoa va khong duoc lua chon
                }    
            }  
           else
            {
                if(priceText)
                {
                    priceText.text = item.price.ToString();
                }    
            }    
        }
    }
}
