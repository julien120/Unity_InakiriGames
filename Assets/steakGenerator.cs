using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steakGenerator : MonoBehaviour
{
    public GameObject steak;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 360 == 0)
        {
            //objはGameObject型でpublic宣言
            Instantiate(steak);
        }
    }
}
