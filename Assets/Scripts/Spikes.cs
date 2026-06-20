using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float slowSpeed = 2f;
    public float duration = 1.5f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerMovement movement = collider.GetComponent<PlayerMovement>();
            if (movement != null)
            {
                movement.ActivateSlowdown(slowSpeed, duration);
            }
        }
    }
}