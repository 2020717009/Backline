using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform hedef;
    public float hiz;
    public float durmaMesafesi;
    public int baslangicSaglik = 10; // Ba�lang�� sa�l�k de�eri
    public int saldiriGucu = 2; // D��man sald�r� g�c�

    private int currentSaglik; // Mevcut sa�l�k de�eri

    // Start is called before the first frame update
    void Start()
    {
        hedef = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentSaglik = baslangicSaglik;
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
        // D��man�n hareketi veya di�er dinamik davran��lar burada g�ncellenebilir
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ate�") // Ates tag'ini kulland�m, siz kendi oyununuzun kurallar�na g�re ayarlayabilirsiniz.
        {
            Vur();
        }
    }

    void Vur()
    {
        currentSaglik--;

        Debug.Log("D��man�n kalan sa�l�k de�eri: " + currentSaglik);

        if (currentSaglik <= 0)
        {
            DusmanOldu();
        }
    }

    void DusmanOldu()
    {
        Debug.Log("D��man �ld�!");
        Destroy(gameObject);
    }
}
