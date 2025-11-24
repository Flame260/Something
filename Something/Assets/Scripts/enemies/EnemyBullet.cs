using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 6f;
    public float lifeTime = 3f;
    private Vector2 Vector2;

    public void SetDirection(Vector2 direction)
    {
        Vector2 = direction.normalized;
    }   

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2 * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerBehaviourScript.Instance.DamagePlayer(3);
            Destroy(gameObject);
        }
    }
}
