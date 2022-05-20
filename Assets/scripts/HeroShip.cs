using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HeroShip : MonoBehaviour
{
    [Header("Spaceship")] 
   [SerializeField] float MoveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] int spaceshipHealth = 100;
    
    [Header("Laser")]
    [SerializeField] GameObject RedLaser;
    [SerializeField] float projectileSpeed = 25f;
    [SerializeField] float firingPeriod = 0.1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    Coroutine firingCoroutine;
    
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        MoveBoundaries();

    }

    private void MoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-padding;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Fire();

    }
    public void OnTriggerEnter2D(Collider2D Other)
    {
        DamageDealer damageDealer = Other.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer)
        {
            return;
        }
        ProcessHits(damageDealer);
    }

    private void ProcessHits(DamageDealer damageDealer)
    {
        spaceshipHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (spaceshipHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        FindObjectOfType<level>().LoadGameover();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

    public int PlayerLife()
    {
        return spaceshipHealth;
    }

   
    


    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {

          firingCoroutine= StartCoroutine( FireCOntinuously());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }
    IEnumerator FireCOntinuously()
    {
        while (true)
        {
            GameObject Laser = Instantiate(RedLaser, transform.position, Quaternion.identity) as GameObject;
            Laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(firingPeriod);
        }
       
    }
    private void move()
    {
       
        var DeltaX = Input.GetAxis("Horizontal")* Time.deltaTime* MoveSpeed;
        var DeltaY = Input.GetAxis("Vertical")*Time.deltaTime*MoveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + DeltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + DeltaY, yMin, yMax);
         transform.position = new Vector2(newXPos, newYPos);
       
    }
}
