using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centralize : MonoBehaviour
{
    private void Start()
    {
        transform.position = transform.parent.position;
    }

    void Update()
    {
        transform.position += (transform.parent.position - transform.position) * 5 * Time.deltaTime;
    }
}
