using System.Collections;
using UnityEngine;

[RequireComponent(typeof(FadeOut))]
public class Command : MonoBehaviour
{
    public string Axis;

    private FadeOut _fadeOut;

    public void Start()
    {
        _fadeOut = GetComponent<FadeOut>();
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