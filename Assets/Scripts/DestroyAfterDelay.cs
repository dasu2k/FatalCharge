using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    // Start is called before the first frame update

    

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime == 4)
            Destroy(gameObject);
    }
}
