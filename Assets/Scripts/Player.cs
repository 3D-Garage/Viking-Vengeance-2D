using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    Rigidbody2D myRigidbody2D;
    Animator myAnimator;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        Run();
    }

    private void Run()
    {
        float contolThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(contolThrow * runSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;
        FlipSprite();
        RunningStateChanging();
    }

    private void RunningStateChanging()
    {
        bool runningHorizantaly = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;

        myAnimator.SetBool("Running", runningHorizantaly);

    }

    private void FlipSprite()
    {
        bool runningHorizantaly = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;

        if (runningHorizantaly)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }
}
