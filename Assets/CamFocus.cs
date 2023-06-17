using UnityEngine;

public class CamFocus : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool currentValue = animator.GetBool("IsFocused");
            animator.SetBool("IsFocused", !currentValue);
      

        }
    }
}
