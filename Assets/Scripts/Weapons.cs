using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public OVRInput.RawButton shootButton;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private float bulletSpeed = 1000;
    private float currentCooldown = 0f;
    [SerializeField] private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(OVRInput.Get(shootButton))
        {
            if(currentCooldown <= 0){
                Shoot();
            }
        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 180, 0)));
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bullet, 2);
        currentCooldown = cooldown;
    }
}
