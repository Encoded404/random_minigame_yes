using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public GameObject objectToToggle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the active state of the object
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
