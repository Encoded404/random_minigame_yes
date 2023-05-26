using UnityEngine;

public class MiddleDivider : MonoBehaviour
{
    public string targetTag = "Player"; // The tag of the objects to be pushed
    public float pushForce = 10f; // The force applied to push the objects

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            // Calculate the direction away from the trigger object
            Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

            // Apply the push force to the object
            Rigidbody2D otherRigidbody = collision.GetComponent<Rigidbody2D>();
            if (otherRigidbody != null)
            {
                otherRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
