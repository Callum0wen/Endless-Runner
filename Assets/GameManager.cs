using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject bike;
	public GameObject score;

	public float restartDelay = 5f;

    public void EndGame()
	{
		bike.GetComponent<BikeController>().enabled = false;
		score.GetComponent<Score>().enabled = false;
		Debug.Log("Game Over");
		Invoke("Restart", restartDelay);
	}

	private void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
