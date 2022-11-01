using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject explosion;
    public float power = 200f, radius = 20f;

    private void OnCollisionEnter(Collision collision) 
    {
          Debug.Log("Попал");


        foreach (ContactPoint missileHit in collision.contacts)
        {
            Vector3 hitPoint = missileHit.point;
            gameObject.GetComponent<Rigidbody>().AddExplosionForce(power, new Vector3(hitPoint.x, hitPoint.y, hitPoint.z), radius, 0.0f); 
            Instantiate(explosion, new Vector3(hitPoint.x, hitPoint.y, hitPoint.z), Quaternion.identity); 
            Destroy(gameObject);
            
        }

    }
}   

