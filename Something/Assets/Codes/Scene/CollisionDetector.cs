using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CollisionDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public LayerMask Wall;
    public Collider2D collider;
    void Start()
    {
    //    Hello(collider);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Hello(Collider2D other)
    {
        Physics2D.OverlapCircle(transform.position, 0.05f, Wall);
        if (gameObject.tag == "Top" && other.gameObject.tag == "Top")
        {
            Debug.Log("Bottom Collide");
        }
    }
}
