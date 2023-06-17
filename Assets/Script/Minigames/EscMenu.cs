using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public GameObject objectToToggle;
    public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            bool currentValue = animator.GetBool("isOpen");

            animator.SetBool("isOpen", !currentValue);
            // Toggle the active state of the object
          //  objectToToggle.SetActive(!objectToToggle.activeSelf);
           
        }
    }
}
