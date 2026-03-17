using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickUp : MonoBehaviour
{
    public GameObject weapon;        // vapnet i scenen
    public Transform weaponHolder;   // spelarens hand

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupWeapon();
        }
    }

    void PickupWeapon()
    {
        // Spara världstransform
        Vector3 worldPos = weapon.transform.position;
        Quaternion worldRot = weapon.transform.rotation;
        Vector3 worldScale = weapon.transform.lossyScale;

        // Sätt parent MEN behåll world transform
        weapon.transform.SetParent(weaponHolder, true);

        // Återställ position/rotation relativt handen
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;

        // ?? Viktigaste delen: fixa skalan så den ser likadan ut
        Vector3 parentScale = weaponHolder.lossyScale;

        weapon.transform.localScale = new Vector3(
            worldScale.x / parentScale.x,
            worldScale.y / parentScale.y,
            worldScale.z / parentScale.z
        );

        // Ta bort trigger-kuben (pickupen)
        Destroy(gameObject);
    }
}
