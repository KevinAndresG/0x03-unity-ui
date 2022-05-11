using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public float speed;
	private int score;
	public int health;
	public Text scoreText;
	public Text healthText;
	public Image winLoseBG;
	public Text winLoseText;
	public PlayerController playerControll;
	// Start is called before the first frame update
	void Start()
	{
		speed = 1000f;
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
			SetScoreText();
			other.gameObject.SetActive(false);
		}
		else if (other.tag == "Trap")
		{
			health--;
			SetHealthText();
		}
		if (other.tag == "Goal" && score < 3)
		{
			Debug.Log($"Coins Left {30 - score}");
		}
		if (other.tag == "Goal" && score >= 3)
		{
			winLoseBG.gameObject.SetActive(true);
			winLoseBG.color = Color.green;
			winLoseText.text = "You Win!";
			winLoseText.color = Color.black;
			playerControll.enabled = false;
			StartCoroutine(LoadScene(3));
		}
		if (health == 0)
		{
			winLoseBG.gameObject.SetActive(true);
			winLoseBG.color = Color.red;
			winLoseText.text = "Game Over!";
			winLoseText.color = Color.white;
			playerControll.enabled = false;
			StartCoroutine(LoadScene(3));
			Start();
		}
	}
	void SetScoreText()
	{
		scoreText.text = $"Score: {score}";
	}
	void SetHealthText()
	{
		healthText.text = $"Health: {health}";
	}
	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
