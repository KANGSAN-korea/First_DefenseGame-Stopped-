using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCube : Interactable
{
    Animator animator;
    private string startPrompt;

    private void Start()
    {
        animator = GetComponent<Animator>();
        startPrompt = promptMessage;
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            promptMessage = startPrompt;
        }
        else
        {
            promptMessage = "Animating..";
        }
    }
    protected override void Interact()
    {
        animator.Play("Spin");
    }
}
