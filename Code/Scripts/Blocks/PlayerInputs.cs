using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInputs : MonoBehaviour
{
    private int _maxRange = 9;
    private Camera _cam;
    public GameObject[] block;
    private int _num;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GameObject.FindWithTag("Player").GetComponentInChildren<Camera>();
        _num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _maxRange))
            {
                Vector3 spawnpos = Vector3.zero;
                float xdif = hit.point.x - hit.transform.position.x;
                float ydif = hit.point.y - hit.transform.position.y;
                float zdif = hit.point.z - hit.transform.position.z;
                if (Mathf.Abs(ydif) == 0.5f) spawnpos = hit.transform.position + (Vector3.up * ydif) * 2;
                else if (Mathf.Abs(xdif) == 0.5f) spawnpos = hit.transform.position + (Vector3.right * xdif) * 2;
                else if (Mathf.Abs(zdif) == 0.5f) spawnpos = hit.transform.position + (Vector3.forward * zdif) * 2;
                Instantiate(block[_num], spawnpos, Quaternion.identity, GameObject.FindWithTag("Terrain").transform);
            }


        }
        if (Input.mouseScrollDelta.y > 0)
        {
                _num++;
            if (_num > 2)
                _num = 0;
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
                _num--;
            if (_num < 0)
                _num = 2;
        }


    }
 
}
