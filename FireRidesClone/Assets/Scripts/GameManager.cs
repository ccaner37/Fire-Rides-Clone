using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Text scoreText;
	public int score;


	private static GameManager instance = null;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject("GameManager").AddComponent<GameManager>();
			}

			return instance;
		}
	}

	private void OnEnable()
	{
		instance = this;
	}

	private void LateUpdate()
	{
		scoreText.text = score.ToString();
	}

}
