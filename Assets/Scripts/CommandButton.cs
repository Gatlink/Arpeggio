using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Pulse))]
[RequireComponent(typeof(FadeOut))]
public class CommandButton : MonoBehaviour
{
    public float Frequency = 1; // pulsation per second
    public string Axis;

    private FadeOut _fadeOut;

    public void Awake()
    {
        _fadeOut = GetComponent<FadeOut>();
        GetComponent<Pulse>().Frequency = Frequency;
    }

    public void Update()
    {
        if (Input.GetAxis(Axis) > 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        StartCoroutine(StartDying());
    }

    private IEnumerator StartDying()
    {
        _fadeOut.enabled = true;
        enabled = false;

        while (!_fadeOut.Faded)
            yield return null;

        Destroy(gameObject);
    }
}