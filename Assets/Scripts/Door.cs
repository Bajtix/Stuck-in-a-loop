using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;


    public float autocloseTime = -1;
    public void Open()
    {
        animator.SetBool("open",true);

        if (autocloseTime > 0)
            StartCoroutine("CloseTask");

    }

    public void Close()
    {
        animator.SetBool("open", false);
    }

    private IEnumerator CloseTask()
    {
        yield return new WaitForSeconds(autocloseTime);
        Close();
    }
}
