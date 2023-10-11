using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{

    public Animator m_animator;
    public int m_isWalkingHash;
    public int m_isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        m_isWalkingHash= Animator.StringToHash("isWalking"); 
        m_isRunningHash= Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool pressForward = Input.GetKey(KeyCode.W);
        bool pressRun= Input.GetKey(KeyCode.LeftShift);
        bool isWalking= m_animator.GetBool(m_isWalkingHash);
        bool isRunning= m_animator.GetBool(m_isRunningHash);
        
        if (pressForward && !isWalking)
        {
            m_animator.SetBool(m_isWalkingHash, true);
        }

        if(!pressForward && isWalking)
        {
            m_animator.SetBool(m_isWalkingHash, false);
        }
        
        if(!isRunning&&pressForward && pressRun)
        {
            m_animator.SetBool(m_isRunningHash, true);
        }
        
        if(isRunning&&(!pressForward || !pressRun))
        {
            m_animator.SetBool(m_isRunningHash, false);
        }
    }
}
