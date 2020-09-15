using UnityEngine;

public class cameraCollider : MonoBehaviour
{
    static Collider2D camCollider;

    private void Awake()
    {
        camCollider = GetComponent<Collider2D>();
    }

    public static Collider2D getCollider()
    {
        return camCollider;
    }
}
