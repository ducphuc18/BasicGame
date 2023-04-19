using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PHUC.BasicGame
{
    public class Weapon : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
           if(collision.CompareTag(ConstClass.Enemy_Tag))
           {
             Enemy enemy = collision.GetComponent<Enemy>();
                enemy.Die();
           }
        }
    }
}
