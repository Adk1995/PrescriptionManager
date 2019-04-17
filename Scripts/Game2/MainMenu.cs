using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Player player;

	public Text scoreLabel;

    public GameObject AudioGameObject;

    AudioSource clip;
	private void Awake () {
		Application.targetFrameRate = 1000;
        clip = AudioGameObject.GetComponent<AudioSource>();
	}

	public void StartGame (int mode) {
		player.StartGame(mode);
		gameObject.SetActive(false);
		Cursor.visible = false;
        clip.Play();
        
	}

	public void EndGame (float distanceTraveled) {
		scoreLabel.text = ((int)(distanceTraveled * 10f)).ToString();
		gameObject.SetActive(true);
		Cursor.visible = true;
        clip.Stop();
    }
}