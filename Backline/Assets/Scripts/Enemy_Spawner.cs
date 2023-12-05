using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer sr;
    public float respawnTime = 5f;
    void Start()
    {
        StartCoroutine(enemyWave());
    }

    private void spawn()
    {
        Instantiate(sr, new Vector2(-6.82f, 5.5f), Quaternion.identity);
    }

    IEnumerator enemyWave()
    {
        while (true)
        {
            spawn();
            yield return new WaitForSeconds(respawnTime);
        }
    }
}
