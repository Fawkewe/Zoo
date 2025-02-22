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
   public bool CanEat;
   public float speed;
   

  public float CurrentAir;
  public float AirMinimum;
  public float AirSubtract;

  public float Temperature;
  public float TempartureIncrease;
    public float DeathTemperature;

    public float drowseyness;
    public float stamina;

    public abstract void Suffocation();
 
}
public class PolarBear : Animal
{
  public override void Suffocation()
    {
        Debug.Log("Polar Bear has died");
    }
}
public class Tiger : Animal
{
    public override void Suffocation()
    {
        Debug.Log("Tiger has fallen asleep");
    }
}
public class Camel : Animal
{
    public override void Suffocation()
    {
        Debug.Log("Camel has died");
    }
}
public class Dolphin : Animal
{
    public override void Suffocation()
    {
       Debug.Log("Dolphin has died");
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
        PolarBear.CurrentAir = 100;
        PolarBear.AirMinimum = 0;
        PolarBear.AirSubtract -= Time.deltaTime;
        PolarBear.Temperature = -25.0f;
        PolarBear.TempartureIncrease += Time.deltaTime;
        PolarBear.DeathTemperature = 0.0f;



        Tiger.hunger = 80;
        Tiger.saturation = 0;
        Tiger.CanEat = true;
        Tiger.speed = 2.0f;
        Tiger.CurrentAir = 100;
        Tiger.AirMinimum = 0;
        Tiger.AirSubtract -= Time.deltaTime;
        Tiger.drowseyness -= Time.deltaTime;
        Tiger.stamina = 30.0f;




        Camel.hunger = 50;
        Camel.saturation = 0;
        Camel.CanEat = true;
        Camel.speed = 1.0f;
        Camel.CurrentAir = 100;
        Camel.AirMinimum = 0;
        Camel.AirSubtract -= Time.deltaTime;
        Camel.Temperature = 40.0f;
        Camel.TempartureIncrease -= Time.deltaTime;
        Camel.DeathTemperature = 0.0f;

        //Camel.shooter = gameObject;


        Dolphin.hunger = 75;
        Dolphin.saturation = 0;
        Dolphin.CanEat = true;
        Dolphin.speed = 3.0f;
        Dolphin.CurrentAir = 10f;
        Dolphin.AirMinimum = 0;
        Dolphin.AirSubtract += Time.deltaTime;


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Dolphin.CurrentAir);
        //Debug.Log(PolarBear.Temperature);
        //Debug.Log(Camel.Temperature);
        Debug.Log(Tiger.stamina);
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
        animal.CurrentAir -= animal.AirSubtract;
        animal.Temperature += animal.TempartureIncrease;
        animal.stamina += animal.drowseyness;
        if (Dolphin.CurrentAir <= Dolphin.AirMinimum)
        {
            Destroy(gameObject);
            Dolphin.Suffocation();
        }
        if (PolarBear.Temperature >= PolarBear.DeathTemperature)
        {
            Destroy(gameObject);
            PolarBear.Suffocation();    
        }

        if (Camel.Temperature <= Camel.DeathTemperature)
        {
            Destroy(gameObject);
            Camel.Suffocation();
        }
        if (Tiger.stamina <= 0)
        {
            Tiger.speed = 0f;
            Tiger.Suffocation();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction *= -1;
    }

}


