using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sushiController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(40.4f,3.15f,0);
        StartCoroutine("destroy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.1f, 0, 0);
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(9);
        Destroy(this);
        Debug.Log("sushi消えるよ");
    }
}
