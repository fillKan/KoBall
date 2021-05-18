using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    GameObject YOUC;
    // Start is called before the first frame update
    void Start()
    {
        YOUC = GameObject.Find("youcant");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        YOUC.transform.Translate(0, 120, 0);
        StartCoroutine("WaitTime");
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3f);
        YOUC.transform.Translate(0, -120, 0);
    }
}
