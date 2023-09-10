using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] float pigRunSpeed = 5f;
    Rigidbody2D pigRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        pigRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingLeft())
        {
            pigRigidbody2D.velocity = new Vector2(-pigRunSpeed, 0f);

        }
        else
        {
            pigRigidbody2D.velocity = new Vector2(pigRunSpeed, 0f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(Mathf.Sign(pigRigidbody2D.velocity.x), 1f);
    }

    private bool IsFacingLeft()
    {
        return transform.localScale.x > 0;
    }
}
