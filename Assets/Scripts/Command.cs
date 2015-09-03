using UnityEngine;

[RequireComponent(typeof(FadeOut))]
public class Command : MonoBehaviour
{
    private FadeOut _fadeOut;

    public void Start()
    {
        _fadeOut = GetComponent<FadeOut>();
    }

    public void Update()
    {

        if (Input.GetAxis("Command A") > 0)
            _fadeOut.enabled = true;

        if (_fadeOut.Faded)
            Destroy(gameObject);
    }
}