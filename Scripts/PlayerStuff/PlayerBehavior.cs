using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerBehavior : MonoBehaviour
{
    public static PlayerBehavior Instance; 

    public int Health;

    public TMP_Text HealthText;

    public GameObject Projectile;
    public GameObject Projectile1;
    public GameObject Projectile2;
    public GameObject Projectile3;
    public GameObject Projectile4;
    public GameObject Projectile5;
    public GameObject Projectile6;

    public Transform ShotSpawn; 
    private void Awake()
    {
        Instance = this;
    }
    public void IncreasedHealth(int HealthValue)
    {
        Health += HealthValue;
        HealthText.text = $"HP: {Health}"; 
    }
    public void DecreasedHealth(int HealthValue)
    {
        Health -= HealthValue;
        HealthText.text = $"HP: {Health}";
    }
    private void FixedUpdate()
    {
        if(Health >= 100)
        {
            Health = 100;
            HealthText.text = $"HP: {Health}";
        }
    }
    private void Update()
    {
        
    }
    public void Stab()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //damage code
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            DecreasedHealth(10); 
        }
    }







    public void ShootDMR()
    {
        Rigidbody RB = Instantiate(Projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

        RB.AddForce(transform.forward * 32f, ForceMode.Impulse);
    }
    public void ShootShotgun()
    {
        Rigidbody RB = Instantiate(Projectile1, ShotSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();
        Rigidbody RB1 = Instantiate(Projectile1, ShotSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();
        Rigidbody RB2 = Instantiate(Projectile1, ShotSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();
        Rigidbody RB3 = Instantiate(Projectile1, ShotSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();
        RB.AddForce(transform.forward * 50f, ForceMode.Impulse);

        Destroy(RB, 2);
        Destroy(RB1, 2);
        Destroy(RB2, 2);
        Destroy(RB3, 2);
    }
    public void ShootPistol()
    {
        Rigidbody RB = Instantiate(Projectile2, ShotSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();

        RB.AddForce(transform.forward * 50f, ForceMode.Impulse);

        Destroy(RB, 2);
    }
    public void ShootLMG()
    {
        Rigidbody RB = Instantiate(Projectile3, ShotSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();

        RB.AddForce(transform.forward * 50f, ForceMode.Impulse);

        Destroy(RB, 2);
    }
    public void ShootRayGun()
    {
        Rigidbody RB = Instantiate(Projectile4, ShotSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();

        RB.AddForce(transform.forward * 50f, ForceMode.Impulse);

        Destroy(RB, 2);
    }
    public void ShootNukeGun()
    {
        Rigidbody RB = Instantiate(Projectile5, ShotSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();

        RB.AddForce(transform.forward * 50f, ForceMode.Impulse);

        Destroy(RB, 2);
    }

}
