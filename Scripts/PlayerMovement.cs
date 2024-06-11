using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody2D rb;
    private Collider2D boundaryCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boundaryCollider = GameObject.FindGameObjectWithTag("Boundary").GetComponent<Collider2D>();
        rb.gravityScale = 0f; 

        if (SaveManager.SaveFileExists())
        {
            LoadGame();
        }
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        movement = movement.normalized;

        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }

        if (movement.magnitude > 0)
        {
            GetComponent<Animator>().SetBool("Running", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Running", false);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            LoadGame();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }

    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            playerPositionX = transform.position.x,
            playerPositionY = transform.position.y,
            playerVelocityX = rb.velocity.x,
            playerVelocityY = rb.velocity.y
        };

        SaveManager.SaveGame(data);
    }

    public void LoadGame()
    {
        SaveData data = SaveManager.LoadGame();
        if (data != null)
        {
            transform.position = new Vector3(data.playerPositionX, data.playerPositionY, transform.position.z);
            rb.velocity = new Vector2(data.playerVelocityX, data.playerVelocityY);
        }
    }
}
