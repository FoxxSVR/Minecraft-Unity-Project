using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionScript : MonoBehaviour
{
    public int RayAmount = 1500;
    public int RayDistance = 300;
    public float stay = 2;
    public Camera cam;
    public Vector2[] rPoints;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponentInChildren<Camera>();
        rPoints = new Vector2[RayAmount];
        GetPoints();
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }
    void GetPoints()
    {
        float x = 0;
        float y = 0;

        for (int i = 0; i < RayAmount; i++)
        {
            if (x > 1)
            {
                x = 0;
                y += 1 / Mathf.Sqrt(RayAmount);
            }
            rPoints[i] = new Vector2(x, y);
            x += 1 / Mathf.Sqrt(RayAmount);
        }
    }
    void CastRay()
    {
        for (int i = 0; i < RayAmount; i++)
        {
            Ray ray;
            RaycastHit hit;
            Occlusion ocl;
            ray = cam.ViewportPointToRay(new Vector3(rPoints[i].x, rPoints[i].y, 0));
            if (Physics.Raycast(ray, out hit, RayDistance))
            {
                if (ocl = hit.transform.GetComponent<Occlusion>())
                    ocl.HitOcclude(stay);
            }
        }
    }
}
