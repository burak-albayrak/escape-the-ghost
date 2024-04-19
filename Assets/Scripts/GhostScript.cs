using UnityEngine;

public enum MovementDirection
{
    Right,
    Left,
    Up,
    Down
}

public enum GhostColor
{
    Blue,
    Yellow
}

public class GhostScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public float horizontalSpeed = 3f;
    public float verticalSpeed = 3f;

    private MovementDirection horizontalDirection;
    private MovementDirection verticalDirection;

    public GhostColor ghostColor;

    void Start()
    {
        horizontalDirection = (MovementDirection)Random.Range(0, 2);
        verticalDirection = (MovementDirection)Random.Range(2, 4);

        ghostColor = (GhostColor)Random.Range(0, 2);
        SetGhostColor();
    }

    void Update()
    {
        if (horizontalDirection == MovementDirection.Right)
        {
            transform.Translate(Vector2.right * horizontalSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * horizontalSpeed * Time.deltaTime);
        }

        if (verticalDirection == MovementDirection.Up)
        {
            transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * verticalSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (collision.contacts.Length > 0)
            {
                Vector2 contactNormal = collision.contacts[0].normal;
                if (contactNormal == Vector2.right || contactNormal == Vector2.left)
                {
                    if (horizontalDirection == MovementDirection.Right)
                    {
                        horizontalDirection = MovementDirection.Left;
                    }
                    else
                    {
                        horizontalDirection = MovementDirection.Right;
                    }
                }
                else if (contactNormal == Vector2.up || contactNormal == Vector2.down)
                {
                    if (verticalDirection == MovementDirection.Up)
                    {
                        verticalDirection = MovementDirection.Down;
                    }
                    else
                    {
                        verticalDirection = MovementDirection.Up;
                    }
                }
            }
        }
        else if (collision.gameObject.CompareTag("Ghost"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void SetGhostColor()
    {
        if (spriteRenderer != null)
        {
            Color color = Color.white;
            switch (ghostColor)
            {
                case GhostColor.Blue:
                    color = Color.blue;
                    break;
                case GhostColor.Yellow:
                    color = Color.yellow;
                    break;
            }

            spriteRenderer.color = color;
        }
    }
}