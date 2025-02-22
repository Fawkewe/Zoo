using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public GameObject Banner;
    // Start is called before the first frame update
    void Start()
    {
       Banner.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisonEnter2D(Collision2D collision)
    {
        Banner.SetActive(true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Banner.SetActive(false);
    }
}
