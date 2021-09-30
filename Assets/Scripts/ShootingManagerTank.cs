using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingManagerTank : MonoBehaviour
{
    [Header("Bullet Prefabs")]
    public GameObject bulletPrefab;

    [Header("Tank Fire Points")]
    public Transform firePoint;

    [Header("Bullet Attributes")]
    public float bulletSpeed;
    public int timeToBulletDestruction;

    [Header("Ammo Counts")]
    public int startingAmmoCount = 5;
    private int ammoCount;

    [Header("Ammo Refill")]
    [SerializeField] private float timeTillAmmoRefill;
    [SerializeField] private float currentAmmoRefillTime;

    [Header("AmmoLabels")]
    public TextMeshProUGUI ammoLabel;
    public string ammoString;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = startingAmmoCount;
    }

    // Update is called once per frame
    void Update()
    {
        AmmoReload();
    }

    public void Shoot()
    {

        if (ammoCount > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            Destroy(bullet, timeToBulletDestruction);
            ammoCount--;

            UpdateAmmoUI();
        }

    }

    void AmmoReload()
    {
        currentAmmoRefillTime += Time.deltaTime;

        if (currentAmmoRefillTime >= timeTillAmmoRefill)
        {
            ammoCount = startingAmmoCount;
            UpdateAmmoUI();
            currentAmmoRefillTime = 0;
        }
    }

    void UpdateAmmoUI()
    {
        ammoString = "";

        if(ammoCount > 0)
        {
            for (int i = 0; i < ammoCount; i++)
            {
                ammoString = ammoString + "•";
                ammoLabel.text = ammoString;
            }
        } else
        {
            ammoLabel.text = "";
        }
        
    }
}
