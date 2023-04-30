using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace PHUC.BasicGame
{
    public class ShopDialogue : Dialogue,IcomponentChecking
    {
        public Transform gridRoot;//cua content
        public shopItemUI itemUiPrefab;
        private shopManager m_shopManager;
        private Gamenanager m_gamenanager;

        public override void show(bool isshow)
        {
            Playerpref.coins = 10000;
            base.show(isshow);
            m_shopManager = FindObjectOfType<shopManager>();
            m_gamenanager = FindObjectOfType<Gamenanager>();
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (iscomponentNull()) return;
            ClearChild();
            var items = m_shopManager.items; // danh sach chua phan tu boss
            if (items == null || items.Length <=0)return;
            for(int i = 0; i < items.Length; i++)
            {
                int index = i;
                var item = items[index];
                var itemUIClone = Instantiate(itemUiPrefab,Vector3.zero,quaternion.identity);
                itemUIClone.transform.SetParent(gridRoot);//set vi tri la con cua object content
                itemUIClone.transform.localScale = Vector3.one;// set lai scale
                itemUIClone.transform.position = Vector3.zero;
                itemUIClone.UpdateUI(item, index);// cap nhat l?i doi tuong
                if(itemUIClone.button)
                {
                    itemUIClone.button.onClick.RemoveAllListeners();// xoa het su kien cua onclick
                    itemUIClone.button.onClick.AddListener(() => ItemEvent(item, index));
                }     
                
            }    


             
        }
        private void ItemEvent(shopItem item,int itemIndex)
        {
           if(item == null) return;
            bool unlocked = Playerpref.getBool(ConstClass.Player_Prefix_Pref + itemIndex);
            if(unlocked)
            {
                if (itemIndex == Playerpref.curPlayerId) return;
                Playerpref.curPlayerId = itemIndex;
                //Debug.Log(Playerpref.curPlayerId);
                m_gamenanager.ActivePlayer();
                UpdateUI();// ve lai shop
            }
            else if(Playerpref.coins >= item.price)
            {
                Playerpref.coins -= item.price;// khi mua tru di so tien da mua
                Playerpref.setBool(ConstClass.Player_Prefix_Pref + itemIndex, true);// roi mo khoa nhan vat
                Playerpref.curPlayerId = itemIndex;
                UpdateUI();
                if(m_gamenanager.guiManager)
                {
                    m_gamenanager.guiManager.UpdateMainCoins();
                }
                m_gamenanager.ActivePlayer();
            }
            else
            {
                Debug.Log("BAN KHONG DU TIEN");
            }
        }    
        public void ClearChild()
        {
            if(gridRoot == null || gridRoot.childCount <= 0) return; // childcount la con cua lop transfrom
            for(var i = 0; i < gridRoot.childCount; i++)//
            {
                var child = gridRoot.GetChild(i);
                if(child)
                {
                    Destroy(child.gameObject);// child.gameobject có nghia gameobject chua con cua no
                }    
            }    
        }    
        public bool iscomponentNull()
        {
            return m_shopManager == null || m_gamenanager == null || gridRoot == null;
        }    
    }
}
