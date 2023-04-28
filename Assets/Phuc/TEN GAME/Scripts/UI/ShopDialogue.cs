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
