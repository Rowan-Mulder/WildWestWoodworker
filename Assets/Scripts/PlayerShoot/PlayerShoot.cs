﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShoot : MonoBehaviour
{
    #pragma warning disable IDE0051 // Removes warning for 'unused' methods (like Awake() and Update())

    public Transform playerCamera;
    public int ammunition = 100;
    public float shootingDistance = 1000;
    //public int decalLimit = 50;
    public bool readyToFire = true;
    public ParticleSystem muzzleFlashPistolCamera;
    public ParticleSystem muzzleFlashPistolLocal;
    public ParticleSystem muzzleFlashPistolGlobal;
    public GameObject gunDecal;
    public LayerMask canShootAt;
    public LayerMask enemies;
    public float hearingDistanceShooting = 10f;

    public PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    public PlayerLook playerLook;

    void LateUpdate()
    {
        if (Input.GetAxis("Fire1") > 0.5) {
            if (playerLook.aimingWeapon && ammunition > 0 && readyToFire)
                Shoot();
        }

        if (Input.GetAxis("Fire1") == 0)
            readyToFire = true;
    }

    private void Shoot()
    {
        readyToFire = false;

        muzzleFlashPistolCamera.Play();
        muzzleFlashPistolLocal.Play();
        muzzleFlashPistolGlobal.Play();

        ammunition--;

        //Shoots from playerCamera, change to weaponMuzzle for VR/third-person
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, shootingDistance, canShootAt)) {
            if (LayerMask.LayerToName(hit.collider.gameObject.layer) == "Target") {
                enemyHealth = (EnemyHealth)hit.collider.gameObject.GetComponent("EnemyHealth");
                enemyHealth.Damage(1);
            } else {
                GameObject particle = Instantiate(gunDecal, hit.point, Quaternion.LookRotation(hit.normal));
                particle.SetActive(true);
                Destroy(particle, 60f);
            }
        }

        // STARTED WORKING ON SHOOTING NOISE
        //     enemies will be informed from the source of the gunfire
        RaycastHit[] hits = Physics.SphereCastAll(playerCamera.position, hearingDistanceShooting, playerCamera.forward, 0f, enemies, QueryTriggerInteraction.UseGlobal);
        foreach (RaycastHit hitz in hits)
        {
            // Onderstaande is een enemy. Zorg ervoor dat deze enemy nu de speler zal achtervolgen.
            //hitz.transform.gameObject
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCamera.position + playerCamera.forward, hearingDistanceShooting);
    }
}
