using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] float climingSpeed = 9f;
    [SerializeField] Vector2 hitKick = new Vector2(50f, 50f);
    Rigidbody2D myRigidbody2D;
    Animator myAnimator;
    //Player Body
    BoxCollider2D myPlayerBody;
    //Player Feet
    PolygonCollider2D myPlayersFeet;

    float startingGravityScale;
    bool isHurting = false;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        //BoxCollider2D
        myPlayerBody = GetComponent<BoxCollider2D>();
        myPlayersFeet = GetComponent<PolygonCollider2D>();
        startingGravityScale = myRigidbody2D.gravityScale;
    }

    void Update()
    {
        if (!isHurting)
        {
            Run();
            Jump();
            Climb();
            if (myPlayerBody.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            {
                PlayerHit();

            }
        }
    }

    private void PlayerHit()
    {
        myRigidbody2D.gravityScale = startingGravityScale;

        myAnimator.SetBool("Climbing", false);

        myRigidbody2D.velocity = hitKick * new Vector2(-transform.localScale.x, 1f);

        myAnimator.SetTrigger("Hitting");
        isHurting = true;
        StartCoroutine(StopHurting());
    }

    IEnumerator StopHurting()
    {
        yield return new WaitForSeconds(0.5f);
        isHurting = false;
    }


    private void Climb()
    {
        if (isHurting)
        {
            return;
        }

        if (myPlayerBody.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 climbingVelocity = new Vector2(myRigidbody2D.velocity.x, controlThrow * climingSpeed);

            myRigidbody2D.velocity = climbingVelocity;
            myAnimator.SetBool("Climbing", true);
            myRigidbody2D.gravityScale = 0f;
        }
        else
        {
            myAnimator.SetBool("Climbing", false);
            myRigidbody2D.gravityScale = startingGravityScale;
        }
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
