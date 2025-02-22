using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class Animal
{
    public abstract void UniqueBehaviour();
   public int hunger;
   public int saturation;
   public bool CanEat;
   public float speed;
   public bool BehaviourExecuted;
}
public class PolarBear : Animal
{
    public override void UniqueBehaviour()
    {
        BehaviourExecuted = true;
    }
}
public class Tiger : Animal
{
    public override void UniqueBehaviour()
    {
        BehaviourExecuted = true;
    }
}
public class Camel : Animal
{
    public override void UniqueBehaviour()
    {
        BehaviourExecuted = true;
    }
}
public class Dolphin : Animal
{
    public override void UniqueBehaviour()
    {
        BehaviourExecuted = true;
    }
}
public class Animals : MonoBehaviour
{
 
    Vector3 direction = Vector3.left;
    Vector3 Movement;

    Animal PolarBear = new PolarBear();
    Animal Tiger = new Tiger();
    Animal Camel = new Camel();
    Animal Dolphin = new Dolphin();
    Animal animal = null;
    public int animaltype;
    // public GameObject spit;
    public AudioClip DolphinSound;

    // Start is called before the first frame update
    void Start()
    {
        PolarBear.hunger = 100;
        PolarBear.saturation = 0;
        PolarBear.CanEat = true;
        PolarBear.speed = 1.5f;
        PolarBear.BehaviourExecuted = false;

        Tiger.hunger = 80;
        Tiger.saturation = 0;
        Tiger.CanEat = true;
        Tiger.speed = 2.0f;
        Tiger.BehaviourExecuted = false;

        Camel.hunger = 50;
        Camel.saturation = 0;
        Camel.CanEat = true;
        Camel.speed = 1.0f;
        Camel.BehaviourExecuted = false;
        //Camel.shooter = gameObject;


        Dolphin.hunger = 75;
        Dolphin.saturation = 0;
        Dolphin.CanEat = true;
        Dolphin.speed = 3.0f;
        Dolphin.BehaviourExecuted = false;

    }

    // Update is called once per frame
    void Update()
    {

        switch (animaltype)
        {
            case 0: 
                animal = PolarBear; 
                break;
            case 1:
                animal = Tiger;
                break;
            case 2:
                animal = Camel;
                break;
            case 3:
                animal = Dolphin;
                break;
        }
        Vector3 Movement = direction * animal.speed * Time.deltaTime;
        transform.position += Movement;
        if (animal.hunger <= 0)
        {
            Debug.Log("Animal is full");
            animal.CanEat = false;

        }
        if (animal.BehaviourExecuted == true)
        {
            switch (animaltype)
            {
                case 0:
                
                break;
                case 1:

                break;
                case 2:

                break;
                case 3:
                    sonar();
                break;

            }
        } 
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;
    }

    private void OnFeed()
    {
        switch (animaltype)
        {
            case 0: //pbear
                animal.UniqueBehaviour();
                break;
            case 1: //tiger
                animal.UniqueBehaviour();
                break;
            case 2: //camel
                animal.UniqueBehaviour();
                break;
            case 3: //dolphin
                animal.UniqueBehaviour();
                break;
        }
    }
    public void sonar()
    {
        AudioSource.PlayClipAtPoint(DolphinSound, transform.position, 1f);
    }
}
//AudioSource.PlayClipAtPoint(DolphinSound, transform.position, 1f);
//GameObject spit = GameObject.Instantiate(Spit);
//spit.transform.position = shooter.transform.position + direction * 0.75f;
//spit.GetComponent<Rigidbody2D>().linearVelocity = direction * speed * 2;

