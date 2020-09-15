using UnityEngine;

public class CanGetDamage : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
            animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            animator.SetBool("IsDead", true);
        }
    }
}
