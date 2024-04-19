using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript_lvl1 : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject redGhostPrefab;
    public GameObject prizePrefab;
    public GameOverScreen GameOverScreen;

    public float moveSpeed = 500f;

    int maxPlatform = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpawnRedGhost();
        SpawnScore();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;

        rb.velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            rb.velocity = Vector2.zero;
        }

        if (col.gameObject.tag == "Ghost")
        {
            GameOver();
        }

        if (col.gameObject.CompareTag("Prize"))
        {
            SceneManager.LoadScene("Level2");
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverScreen.Setup(maxPlatform);
    }

    void SpawnScore()
    {
        Vector3 playerPosition = transform.position;

        float spawnDistance = 500f;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = playerPosition + spawnDistance * new Vector3(randomDirection.x, randomDirection.y, 0f);

        float minX = 179f;
        float maxX = 1750f;
        float minY = 160f;
        float maxY = 900f;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, minX, maxX);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, minY, maxY);

        Instantiate(prizePrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnRedGhost()
    {
        Vector3 playerPosition = transform.position;

        float spawnDistance = 500f; 
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = playerPosition + spawnDistance * new Vector3(randomDirection.x, randomDirection.y, 0f);

        float minX = 179f;
        float maxX = 1750f;
        float minY = 160f;
        float maxY = 900f;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, minX, maxX);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, minY, maxY);

        Instantiate(redGhostPrefab, spawnPosition, Quaternion.identity);
    }
}