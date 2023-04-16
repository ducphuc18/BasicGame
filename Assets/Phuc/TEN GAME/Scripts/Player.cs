using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator m_amin;
    public float actRate;
    private float curActRate;
    bool isattacked;

    // Start is called before the first frame update
    void Start()
    {
        m_amin = GetComponent<Animator>();
        curActRate = actRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isattacked)
        {
            if(m_amin)
            {
                m_amin.SetBool(ConstClass.Attack_Amin, true);
            }
            isattacked = true;

        }
       
        if (isattacked)
        {
            curActRate -= Time.deltaTime;
            if(curActRate <=0)
            {
              isattacked=false;
              curActRate = actRate;
            }
        }
    }
    public void resetAtackAmin()
    {
        m_amin.SetBool(ConstClass.Attack_Amin, false);
    }
}
