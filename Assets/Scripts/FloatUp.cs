using UnityEngine;

public class FloatUp : MonoBehaviour
{
    public float Speed = 0.4f;
    public float Sway = 0.05f;

    public void Update()
    {
        Vector3 direction = Vector2.up + Vector2.right * Mathf.Sin(Time.time % (Mathf.PI * 2));
        transform.position = transform.position + direction * Speed * Time.deltaTime;
    }
}