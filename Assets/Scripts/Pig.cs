using System.Collections;
using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] float pigRunSpeed = 5f;
    Rigidbody2D pigRigidbody2D;
    Animator pigAnimator;
    bool pigDyingState = false;
    // Start is called before the first frame update
    void Start()
    {
        pigRigidbody2D = GetComponent<Rigidbody2D>();
        pigAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();

    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);

    }

    public void Dying()
    {
        Debug.Log("Dying method called.");
        pigAnimator.SetTrigger("Die");
        pigDyingState = true;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        pigRigidbody2D.bodyType = RigidbodyType2D.Static;
        StartCoroutine(DestroyEnemy());
    }

    private void EnemyMovement()
    {
        if (pigDyingState != true)
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
