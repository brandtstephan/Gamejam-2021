using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{

    public GameObject shootPoint;
    public GameObject projectile;
    private float cooldown = 3;
    private float startTimeCooldown = 1;
    public int amountOfShots;
    private List<GameObject> listOfProjectiles;
    // Update is called once per frame
    private void Start()
    {
        listOfProjectiles = new List<GameObject>();
    }
    void Update()
    {
        HandleCharacterShooting();
    }
    private void HandleCharacterShooting()
    {
        if (Input.GetMouseButtonDown(0) && listOfProjectiles.Count < 1)
        {
            Vector3 mousePosition = GetMousePosition();
            listOfProjectiles.Add(Instantiate(projectile, shootPoint.transform.position, transform.rotation));
        }
    }
    Vector3 GetMousePosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }
}
