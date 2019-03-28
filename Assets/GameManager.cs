using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject bike;
	public GameObject score;
	public GameObject gameOverUI;

	public float gameOverUIDelay = 5f;

    public void EndGame()
	{
		bike.GetComponent<BikeController>().enabled = false;
		score.GetComponent<Score>().enabled = false;

		Invoke("EndScreen", gameOverUIDelay);
	}

	public void EndScreen()
	{
		gameOverUI.SetActive(true);
	}

	private void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
