using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float loopSpace;
    [SerializeField] private float mouseGain;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Input.mousePosition * mouseGain;

        Debug.Log(newPos);
        float z = gameObject.transform.position.z;
        gameObject.transform.position = new Vector3(newPos.x % loopSpace, newPos.y, z);
    }
}
