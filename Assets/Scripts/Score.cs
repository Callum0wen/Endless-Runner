using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	public Transform player;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI finalScore;

    // Update is called once per frame
    void Update()
    {
		scoreText.text = player.position.z.ToString("0");
		finalScore.text = player.position.z.ToString("0");

	}
}
