using UnityEngine;

[RequireComponent(typeof(FadeOut))]
public class StartToBegin : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetAxis("Start") > 0)
            GetComponent<FadeOut>().enabled = true;
    }
}