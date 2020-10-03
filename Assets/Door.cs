using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;

    public void Open()
    {
        animator.SetBool("open",true);
    }

    public void Close()
    {
        animator.SetBool("open", false);
    }
}
