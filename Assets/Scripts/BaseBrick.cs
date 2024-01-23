using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBrick : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEnter (Collider collider) {
        StartCoroutine(WaitAndDie());
    }

    private IEnumerator WaitAndDie() {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
}
