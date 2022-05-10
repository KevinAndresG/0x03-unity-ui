using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public float speed;
	private int score;
	public int health;
	// Start is called before the first frame update
	void Start()
	{
		speed = 800f;
		score = 0;
		health = 5;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetKey("d"))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			score++;
			Debug.Log($"Score:{score}");
			other.gameObject.SetActive(false);
		}
		else if (other.tag == "Trap")
		{
			health--;
			Debug.Log($"Health:{health}");

		}
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene("maze");
			Start();
		}
		if (other.tag == "Goal" && score < 30)
		{
			Debug.Log($"Coins Left {30 - score}");
		}
		else if (other.tag == "Goal" && score == 30)
		{
			Debug.Log("You win!");
		}
	}
}
