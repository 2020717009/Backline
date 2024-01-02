using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform hedef;
    public float hiz;
    public float durmaMesafesi;
    // Start is called before the first frame update
    void Start()
    {
        hedef = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void EnemyFollow()
    {
        if (Vector2.Distance(transform.position, hedef.position) > durmaMesafesi)
            transform.position = Vector2.MoveTowards(transform.position, hedef.position, hiz * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFollow();
    }
}
