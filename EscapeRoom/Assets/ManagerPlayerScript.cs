using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPlayerScript : MonoBehaviour {

    public const int MaxHealth = 100;
    public int health = MaxHealth;
    public Text healthText;

    public GameObject bulletPrefab;

    public GameObject ammo;
    private AmmoScript ammoScript;

    // Use this for initialization
    void Start () {
        ammoScript = ammo.GetComponent<AmmoScript>();
    }

    private void OnCollisionEnter(Collision col)
    {
        var hit = col.gameObject;
        if (hit != null)
        {
            health -= 20;
            healthText.text = health.ToString() + " / " + MaxHealth.ToString();
            if (health <= 0)
            {
                PlayerPrefs.SetString("state", "Game Over");
                Application.LoadLevel(4);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButtonDown(0) && ammoScript.isAmmoTaken)
        {
            CmdFire();
        }
	}

    private void CmdFire()
    {
        var bullet = Instantiate(bulletPrefab, transform.position + 3 * transform.forward + bulletPrefab.transform.position, bulletPrefab.transform.rotation * transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * 4;
        Destroy(bullet, 2);
    }
}
