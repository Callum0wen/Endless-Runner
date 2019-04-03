using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject bike;
	public GameObject score;
	public FixedJoint man;
	public GameObject gameOverUI;

	public float gameOverUIDelay = 5f;
	public bool gameOver = false;

	private void Start()
	{
		gameOver = false;
	}

	public void EndGame()
	{
		Debug.Log("Run EndGame()");
		gameOver = true;
		bike.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		man.breakForce = 1;
		bike.GetComponent<BikeController>().enabled = false;
		score.GetComponent<Score>().enabled = false;

		Invoke("EndScreen", gameOverUIDelay);
	}

	public void EndScreen()
	{
		gameOverUI.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu ()
	{
		SceneManager.LoadScene(0);
	}
}
