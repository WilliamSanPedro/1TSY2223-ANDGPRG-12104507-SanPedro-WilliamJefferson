using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform nozzle;
    public Transform nozzle2;
    public Transform nozzle3;
    public Transform nozzle4;
    public Transform nozzle5;

    private int currentMode = 1; // Initial mode is 1

    void Update()
    {
        // Switch modes when 1, 2, 3, or 4 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentMode = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentMode = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentMode = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentMode = 4;
        }

        // Shoot when spacebar is pressed based on the current mode
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentMode)
            {
                case 1:
                    InstantiateBullet(nozzle.rotation);
                    break;
                case 2:
                    InstantiateBullet(nozzle3.rotation);
                    InstantiateBullet(nozzle2.rotation);
                    break;
                case 3:
                    InstantiateBullet(nozzle3.rotation);
                    InstantiateBullet(nozzle2.rotation);
                    InstantiateBullet(nozzle.rotation);
                    break;
                case 4:
                    InstantiateBullet(nozzle4.rotation);
                    InstantiateBullet(nozzle3.rotation);
                    InstantiateBullet(nozzle2.rotation);
                    InstantiateBullet(nozzle.rotation);
                    break;
            }
        }
    }

    void InstantiateBullet(Quaternion rotation)
    {
        GameObject bullet = Instantiate(bulletPrefab, nozzle.position, rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bullet.GetComponent<BulletMovement>().speed;
        Destroy(bullet, 5f);
    }
}
