using UnityEngine;

public class RedGhostScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    private GameObject player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            Vector3 movement = direction * moveSpeed * Time.deltaTime;

            transform.position += movement;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.Translate(Vector2.zero);
        }
    }
}