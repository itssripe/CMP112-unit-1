using UnityEngine;
using TMPro;

public class Destroy_Player : MonoBehaviour
{
    public TMP_Text scoretext;
    public GameObject winUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateScore()
    {
        scoretext.text = "You Lose!";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            UpdateScore();
            winUI.SetActive(true);

        }
    }
}
