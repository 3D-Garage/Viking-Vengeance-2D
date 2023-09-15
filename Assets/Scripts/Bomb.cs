using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAnimator.SetTrigger("Tszzz");
    }

    void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
