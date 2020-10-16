using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sushiController : MonoBehaviour
{

    private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(40.4f,1f,0);
        StartCoroutine("destroy");
        particle = this.GetComponent<ParticleSystem>();

        particle.Stop();


    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.1f, 0, 0);
    }

 

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(8);
        Destroy(this);
        Debug.Log("sushi消えるよ");
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("hit"))
        {
            particle.Play();
            StartCoroutine("hit");
        }

        if (coll.gameObject.CompareTag("hitDestroy"))
        {
            Destroy(gameObject);
            Debug.Log("画面外に出たので消滅");
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("hitDestroy"))
        {
            Destroy(gameObject);
            Debug.Log("画面外に出たので消滅");
        }
    }

    IEnumerator hit()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
