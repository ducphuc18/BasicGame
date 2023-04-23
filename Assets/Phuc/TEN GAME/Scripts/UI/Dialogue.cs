using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace PHUC.BasicGame
{
    public class Dialogue : MonoBehaviour
    {
        public Text titleText;
        public Text contentText;

        public virtual void show(bool isshow)
        {
            gameObject.SetActive(isshow);
        } 
        public virtual void UpdateDialogue(string tittle,string content)
        {
            if(titleText)
            {
                titleText.text = tittle;
            }
            if(contentText)
            {
                contentText.text = tittle;
            }    
        }   
        public virtual void UpdateDialogue()
        {

        } 
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }    
    }
}
