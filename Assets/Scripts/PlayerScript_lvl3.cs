using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerScript_lvl3 : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject redGhostPrefab;
    public GameOverScreen GameOverScreen;
    [FormerlySerializedAs("scorePrefab")] public GameObject onePrefab;
    [FormerlySerializedAs("scorePrefab2")] public GameObject TwoPrefab;
    public GameObject prizePrefab;
    public GameObject ghostPrefab;

    public float moveSpeed = 500f;
    int maxPlatform = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpawnRedGhost();
        SpawnPrize();
        SpawnOne();
        SpawnTwo();
        SpawnGhost();
        SpawnGhost();
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

        if (col.gameObject.CompareTag("Zero"))
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("One") && !col.gameObject.CompareTag("Zero"))
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Prize") && !col.gameObject.CompareTag("Zero") &&
            !col.gameObject.CompareTag("One"))
        {
            SceneManager.LoadScene("Level4");
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverScreen.Setup(maxPlatform);
    }

    void SpawnOne()
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

        Instantiate(onePrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnTwo()
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

        Instantiate(TwoPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnPrize()
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

    void SpawnGhost()
    {
        Vector3 playerPosition = transform.position;

        float spawnDistance = 500f;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition =
            playerPosition + spawnDistance * new Vector3(randomDirection.x, randomDirection.y, 0f);

        float minX = 179f;
        float maxX = 1750f;
        float minY = 160f;
        float maxY = 900f;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, minX, maxX);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, minY, maxY);

        GameObject newGhost = Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);

        newGhost.transform.rotation = Quaternion.identity;
    }
}