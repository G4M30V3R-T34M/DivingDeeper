using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        GameObject[] obj = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
        if (obj.Length > 1) {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
