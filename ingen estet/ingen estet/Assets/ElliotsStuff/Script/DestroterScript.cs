using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroterScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IsFloor")
            Destroy(other.gameObject);
    }
}
