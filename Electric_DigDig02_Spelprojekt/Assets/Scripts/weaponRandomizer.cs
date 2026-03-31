using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponRandomizer : MonoBehaviour
{

    public GameObject[] weapons; // list of all the weapons
    public Transform weaponSpawner; // Where the weapon spawns
    public float respawnDelay = 5f;

    public GameObject currentWeapon;

    void Start()
    {
        SpawnRandomWeapon(); 
    }


    void SpawnRandomWeapon()
    {
        int randomIndex = Random.Range(0, weapons.Length);

        currentWeapon = Instantiate(
            weapons[randomIndex],
            weaponSpawner.position,
            weaponSpawner.rotation
            );

        // attach back to spawner
        //currentWeapon.GetComponent<weaponPickUp>().spawner = this;
    }

    public void WeaponPickedUp()
    {
        StartCoroutine(Respawn());
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnRandomWeapon();
    }
}
