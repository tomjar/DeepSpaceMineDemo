using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private int random;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		random = 0;
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition;


				switch(random)
				{
					case 0:
					{
						spawnPosition = new Vector3 (Random.Range ((-spawnValues.x)-5, -spawnValues.x), Random.Range((-spawnValues.y)-5, -spawnValues.y), Random.Range((-spawnValues.z)-5, -spawnValues.z));
						random++;
						break;
					}
					case 1:
					{
						spawnPosition = new Vector3 (Random.Range (spawnValues.x, (spawnValues.x)+5), Random.Range(spawnValues.y, (spawnValues.y)+5), Random.Range(spawnValues.z, (spawnValues.z)+5));
						random++;
						break;
					}
					case 2:
					{
						spawnPosition = new Vector3 (Random.Range (spawnValues.x, (spawnValues.x)+5), Random.Range((-spawnValues.y)-5, -spawnValues.y), Random.Range((-spawnValues.z)-5, -spawnValues.z));
						random++;
						break;
					}
					case 3:
					{
						random++;
						spawnPosition = new Vector3 (Random.Range ((-spawnValues.x)-5, -spawnValues.x), Random.Range(spawnValues.y, (spawnValues.y)+5), Random.Range(spawnValues.z, (spawnValues.z)+5));
						break;
					}
					case 4:
					{
						spawnPosition = new Vector3 (Random.Range ((-spawnValues.x)-5, -spawnValues.x), Random.Range((-spawnValues.y)-5, -spawnValues.y), Random.Range(spawnValues.z, (spawnValues.z)+5));
						random++;
						break;
					}
					case 5:
					{
						spawnPosition = new Vector3 (Random.Range ((-spawnValues.x)-5, -spawnValues.x), Random.Range(spawnValues.y, (spawnValues.y)+5), Random.Range((-spawnValues.z)-5, -spawnValues.z));
						random++;
						break;
					}
					case 6:
					{
						spawnPosition = new Vector3 (Random.Range (spawnValues.x, (spawnValues.x)+5), Random.Range(spawnValues.y, (spawnValues.y)+5), Random.Range((-spawnValues.z)-5, -spawnValues.z));
						random++;
						break;
					}
					default:
					{
					spawnPosition = new Vector3 (Random.Range (spawnValues.x, (spawnValues.x)+5), Random.Range((-spawnValues.y)-5, -spawnValues.y), Random.Range(spawnValues.z, (spawnValues.z)+5));
						random = 0;
						break;
					}
				}
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}