
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform InteractionTrasform;
    public Transform player;
    bool hasInteracted = false;
    private void OnDrawGizmosSelected()
    {
        if (InteractionTrasform == null)
            InteractionTrasform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTrasform.position, radius);
    }
    public virtual void Interact()
    {
    }
    void Update()
    {
        if (!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, InteractionTrasform.position);
            if (distance<=radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
}
