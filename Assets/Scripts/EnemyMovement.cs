using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public Transform raycast;

     [SerializeField] float raycastDistanceDown = 2f;
     [SerializeField] float raycastDistanceFront = 1f;
     bool isFacingRight = true;
     LayerMask ignoreRay;
     Vector2 frontRayDirection = Vector2.right;

    private void Start()
    {
        ignoreRay = LayerMask.GetMask("Enemy", "Collectable", "Ignore Raycast");
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D raycastHit2DDown = Physics2D.Raycast(raycast.position, Vector2.down, raycastDistanceDown, ~ignoreRay);//down ray(enemy not drop from top).
        RaycastHit2D raycastHit2DFront = Physics2D.Raycast(raycast.position, frontRayDirection, raycastDistanceFront, ~ignoreRay);//front ray(for checking frong collider).
        //Debug.DrawRay(raycast.position, Vector2.down * 2, Color.green);

        if (raycastHit2DDown.collider == false || raycastHit2DFront.collider == true) // checking for collider (player and coins set to ignoreRaycast).
            
        {
                if (isFacingRight == true)
                {
                    frontRayDirection = Vector2.left;
                    transform.eulerAngles = new Vector2(0, -180);
                    isFacingRight = false;
                } else
                {
                    frontRayDirection = Vector2.right;
                    transform.eulerAngles = new Vector2(0, 0);
                    isFacingRight = true;
                }
        }
    }
}
