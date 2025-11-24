using UnityEngine;
using UnityEngine.Playables;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class BigRoomBattle : MonoBehaviour
{
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Physics2D.OverlapCircle(Player.transform.position, 0.05f);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hi");
        }
    }

}
