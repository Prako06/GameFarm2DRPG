using UnityEngine;

public class MovementAnimationParameterControl : MonoBehaviour
{
    private Animator animator;

    //use this for initialisation

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventHandler.MovementEvent += SetAnimationParameters;
    }

    private void OnDisable()
    {
        EventHandler.MovementEvent -= SetAnimationParameters;
    }

    private void SetAnimationParameters(float Xinput, float Yinput, bool isWalking, bool isIdle, ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isAxingToolRight, bool isAxingToolLeft, bool isAxingToolUp, bool isAxingToolDown,
    bool isPickAxingToolRight, bool isPickAxingToolLeft, bool isPickAxingToolUp, bool isPickAxingToolDown,
    bool isPickingUpRight, bool isPickingUpLeft, bool isPickingUpUp, bool isPickingUpDown,
    bool isWateringToolRight, bool isWateringToolLeft, bool isWateringToolUp, bool isWateringToolDown,
    bool idleRight, bool idleLeft, bool idleUp, bool idleDown)
    {
        animator.SetFloat(Settings.Xinput, Xinput);
        animator.SetFloat(Settings.Yinput, Yinput);
        animator.SetBool(Settings.isWalking, isWalking);


        if (isUsingToolRight)
            animator.SetTrigger(Settings.isUsingToolRight);
        if (isUsingToolLeft)
            animator.SetTrigger(Settings.isUsingToolLeft);
        if (isUsingToolUp)
            animator.SetTrigger(Settings.isUsingToolUp);
        if (isUsingToolDown)
            animator.SetTrigger(Settings.isUsingToolDown);

        if (isAxingToolRight)
            animator.SetTrigger(Settings.isAxingToolRight);
        if (isAxingToolLeft)
            animator.SetTrigger(Settings.isAxingToolLeft);
        if (isAxingToolUp)
            animator.SetTrigger(Settings.isAxingToolUp);
        if (isAxingToolDown)
            animator.SetTrigger(Settings.isAxingToolDown);

        if (isPickAxingToolRight)
            animator.SetTrigger(Settings.isPickAxingToolRight);
        if (isPickAxingToolLeft)
            animator.SetTrigger(Settings.isPickAxingToolLeft);
        if (isPickAxingToolUp)
            animator.SetTrigger(Settings.isPickAxingToolUp);
        if (isPickAxingToolDown)
            animator.SetTrigger(Settings.isPickAxingToolDown);

        if (isPickingUpRight)
            animator.SetTrigger(Settings.isPickingUpRight);
        if (isPickingUpLeft)
            animator.SetTrigger(Settings.isPickingUpLeft);
        if (isPickingUpUp)
            animator.SetTrigger(Settings.isPickingUpUp);
        if (isPickingUpDown)
            animator.SetTrigger(Settings.isPickingUpDown);

        if (isWateringToolRight)
            animator.SetTrigger(Settings.isWateringToolRight);
        if (isWateringToolLeft)
            animator.SetTrigger(Settings.isWateringToolLeft);
        if (isWateringToolUp)
            animator.SetTrigger(Settings.isWateringToolUp);
        if (isWateringToolDown)
            animator.SetTrigger(Settings.isWateringToolDown);

        if (idleRight)
            animator.SetTrigger(Settings.idleRight);
        if (idleLeft)
            animator.SetTrigger(Settings.idleLeft);
        if (idleUp)
            animator.SetTrigger(Settings.idleUp);
        if (idleDown)
            animator.SetTrigger(Settings.idleDown);
    }
}
