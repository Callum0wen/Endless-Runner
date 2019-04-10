using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject bike;
	public GameObject score;
	public FixedJoint man;
	public GameObject gameOverUI;

	public float gameOverUIDelay = 1f;
	public bool gameOver
	{
		get;
		set;
	}

	private void Start()
	{
		gameOver = false;
	}

	public void EndGame()
	{
		if (!gameOver)
		{
			gameOver = true;
			bike.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			man.breakForce = 1;
			bike.GetComponent<BikeController>().enabled = false;
			score.GetComponent<Score>().enabled = false;

			Invoke("EndScreen", gameOverUIDelay);
		}
	}

	public void EndScreen()
	{
		gameOverUI.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(1);
	}

	public void Menu ()
	{
		SceneManager.LoadScene(0);
	}
}
