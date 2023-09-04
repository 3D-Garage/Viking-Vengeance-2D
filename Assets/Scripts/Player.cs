using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 15f;
    Rigidbody2D myRigidbody2D;
    Animator myAnimator;
    //Player Body
    BoxCollider2D myPlayerBody;
    //Player Feet
    PolygonCollider2D myPlayersFeet;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myPlayerBody = GetComponent<BoxCollider2D>();
        myPlayersFeet = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        Run();
        Jump();

    }

    private void Run()
    {
        float contolThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(contolThrow * runSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;
        FlipSprite();
        RunningStateChanging();
    }

    private void Jump()
    {
        //If we arent touching the ground we wont jump in the air
        if (!myPlayersFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        bool isJumpinmg = CrossPlatformInputManager.GetButtonDown("Jump");
        if (isJumpinmg)
        {
            Vector2 jumpVelocity = new Vector2(myRigidbody2D.velocity.x, jumpSpeed);
            myRigidbody2D.velocity = jumpVelocity;
        }
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
