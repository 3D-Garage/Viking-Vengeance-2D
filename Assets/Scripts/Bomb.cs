using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] float radius = 3f;
    [SerializeField] Vector2 explosionForce = new Vector2(10f, 0f);

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    void ExplodeBomb()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Player"));

        if (playerCollider)
        {
            Vector2 directionToPlayer = playerCollider.transform.position - transform.position;

            directionToPlayer.Normalize();

            Vector2 dynamicExplosionForce = new Vector2(
                directionToPlayer.x * explosionForce.x,
                directionToPlayer.y * explosionForce.y
            );

            playerCollider.GetComponent<Rigidbody2D>().AddForce(dynamicExplosionForce);

            playerCollider.GetComponent<Player>().PlayerHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAnimator.SetTrigger("Tszzz");
    }

    void DestroyBomb()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
