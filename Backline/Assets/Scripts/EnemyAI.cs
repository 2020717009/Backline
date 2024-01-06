using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform hedef;
    public float hiz;
    public float durmaMesafesi;
    public int baslangicSaglik = 10; // Baþlangýç saðlýk deðeri
    public int saldiriGucu = 2; // Düþman saldýrý gücü

    private int currentSaglik; // Mevcut saðlýk deðeri

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
        // Düþmanýn hareketi veya diðer dinamik davranýþlar burada güncellenebilir
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ateþ") // Ates tag'ini kullandým, siz kendi oyununuzun kurallarýna göre ayarlayabilirsiniz.
        {
            Vur();
        }
    }

    void Vur()
    {
        currentSaglik--;

        Debug.Log("Düþmanýn kalan saðlýk deðeri: " + currentSaglik);

        if (currentSaglik <= 0)
        {
            DusmanOldu();
        }
    }

    void DusmanOldu()
    {
        Debug.Log("Düþman öldü!");
        Destroy(gameObject);
    }
}
