using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {

	private bool shooting = false;
	private int direction = 0;
	public float bulletSpeed = 5000f;
	public GameObject bullet;
	Transform player;
	bool shootable = true; //currently able to shoot

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("character").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (shooting) { //if true, enemy has aggro'd and shooting at player
			if (shootable) {
				/*GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
				bulletInstance.transform.Rotate (Vector3.forward * 90);
				bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(direction*bulletSpeed, 0);
				lastShot = Time.time;
				shooting = false;*/
				shootable = false;
				Invoke ("shootOn", 1.0f);
				shootBullet ();
			}
		}
	}

	void shootOn() 
	{
		shootable = true;
	}

	GameObject shootBullet() //90 for straight forward
	{
		//Quaternion rotation = Quaternion.LookRotation(player.position);
		Vector3 playerPos = player.transform.position;
		Quaternion rotToPlayer = Quaternion.FromToRotation(Vector3.up, playerPos - transform.position);
		GameObject bulletInstance = Instantiate(bullet, transform.position, rotToPlayer) as GameObject;
		bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.up * bulletSpeed);
		return bulletInstance;
	}

	public void isShooting(bool x, int y){
		shooting = x;
		direction = y;
	}
}
