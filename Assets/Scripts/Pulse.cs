using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class Pulse : MonoBehaviour
{
    public float MaxScale = 1.5f;

    private float _duration = 1f; // in seconds
    private GameObject _pulse;
    private Image _pulseImage;

    public float Frequency { private get; set; }

    public IEnumerator Start()
    {
        _pulse = transform.GetChild(0).gameObject;
        _pulseImage = _pulse.GetComponent<Image>();
        _duration = 1 / Frequency * 0.5f;

        while (true)
        {
            yield return StartCoroutine(PulseOnce());
            yield return new WaitForSeconds(_duration);
        }
    }

    private IEnumerator PulseOnce()
    {
        var startTime = Time.time;
        var color = _pulseImage.color;

        while (Time.time - startTime <= _duration)
        {
            var t = (Time.time - startTime) / _duration;
            var scale = Mathf.Lerp(1, MaxScale, t);
            color.a = Mathf.Lerp(1, 0, t);
            _pulse.transform.localScale = new Vector3(scale, scale, 1);
            _pulseImage.color = color;
            yield return null;
        }

        _pulse.transform.localScale = Vector3.one;
        color.a = 1;
        _pulseImage.color = color;
    }
}