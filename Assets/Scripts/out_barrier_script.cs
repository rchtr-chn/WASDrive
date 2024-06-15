using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class out_barrier_script : MonoBehaviour
{
    private BoxCollider barrier;
    // Start is called before the first frame update
    void Start()
    {
        barrier = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "player-tail")
        {
            barrier.enabled = false;
        }
    }
}
