using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform player;
    public Vector2 offset;
    public float smooth = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
    }

}
