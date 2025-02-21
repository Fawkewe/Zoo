using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class Animal
{
   public int hunger;
   public int saturation;
   //public bool CanEat;
}
public class PolarBear : Animal
{
}
public class Tiger : Animal
{

}
public class Camel : Animal
{

}
public class Dolphin : Animal
{
}
public class Animals : MonoBehaviour
{
    float speed = 1.5f;
    Vector3 direction = Vector3.left;
    Vector3 Movement;

    Animal PolarBear = new PolarBear();
    Animal Tiger = new Tiger();
    Animal Camel = new Camel();
    Animal Dolphin = new Dolphin();
    Animal animal = null;

    // Start is called before the first frame update
    void Start()
    {
        PolarBear.hunger = 100;
        PolarBear.saturation = 0;

        Tiger.hunger = 80;
        Tiger.saturation = 0;

        Camel.hunger = 50;
        Camel.saturation = 0;

        Dolphin.hunger = 75;
        Dolphin.saturation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Movement = direction * speed * Time.deltaTime;
        transform.position += Movement;
        
        if (animal.hunger <= 0)
        {
           
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;
    }
}
