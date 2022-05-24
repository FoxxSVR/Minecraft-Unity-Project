using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occlusion : MonoBehaviour
{
    Renderer rend;
    public float display;

    private void OnEnable()
    {
        rend = gameObject.GetComponent<Renderer>();
        display = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (display > 0)
        {
            display -= Time.deltaTime;
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }
    }
    public void HitOcclude(float time)
    {
        display = time;
        rend.enabled = true;
    }
}
