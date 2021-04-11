using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
	public float levelLength;
	public Transform bottomDark;
	public Transform bottomLight;
	public Transform circle;
	private float randomY_circle;
	private float randomX_circle;
	private float randomY_bottom;
	private float randomY_top;

	void Start()
    {
		CreateWalls();
		CreateCircles();
	}

    void CreateWalls()
	{
		// Creating the bottom walls
		for (int i = 0; i < levelLength; i++)
		{
			randomY_bottom = Random.Range(-14.5f, -9.5f);
			Instantiate(bottomDark, new Vector3(i * 4.5f, randomY_bottom, 0), Quaternion.identity, transform);  // 2.25 4.5 6.75

		}

		// Creating the bottom walls
		for (int i = 1; i < levelLength; i++)
		{
			if (i == 1)
			{
				randomY_bottom = Random.Range(-14.5f, -9.5f);
				Instantiate(bottomLight, new Vector3(i * 2.25f, randomY_bottom, 0), Quaternion.identity, transform); // 2.25 6.75 11.25 15.75 20.25 24.75 -- 4.5 fark
			}
			else
			{
				randomY_bottom = Random.Range(-14.5f, -9.5f);
				Instantiate(bottomLight, new Vector3(i * 4.5f - 2.25f, randomY_bottom, 0), Quaternion.identity, transform); // 2.25 6.75 11.25 15.75 20.25 24.75 -- 4.5 fark

			}
		}


		// Creating the upper walls
		for (int i = 0; i < levelLength; i++)
		{
			randomY_top = Random.Range(23, 26.1f);
			Instantiate(bottomDark, new Vector3(i * 4.5f, randomY_top, 0), Quaternion.identity, transform);  // 2.25 4.5 6.75

		}

		// Creating the upper walls
		for (int i = 1; i < levelLength; i++)
		{
			if (i == 1)
			{
				randomY_top = Random.Range(23, 26.1f);
				Instantiate(bottomLight, new Vector3(i * 2.25f, randomY_top, 0), Quaternion.identity, transform); // 2.25 6.75 11.25 15.75 20.25 24.75 -- 4.5 fark
			}
			else
			{
				randomY_top = Random.Range(23, 26.1f);
				Instantiate(bottomLight, new Vector3(i * 4.5f - 2.25f, randomY_top, 0), Quaternion.identity, transform); // 2.25 6.75 11.25 15.75 20.25 24.75 -- 4.5 fark

			}
		}
	}

	void CreateCircles()
	{
		for (int i = 1; i < levelLength; i++)
		{
			randomX_circle = Random.Range(25, 35);
			randomY_circle = Random.Range(4.7f, 5.7f);
			Instantiate(circle, new Vector3(i * randomX_circle, randomY_circle, 0), Quaternion.LookRotation(Vector3.left), transform);  // 2.25 4.5 6.75

		}
	}

}
