using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
    public float timer;
    public Text timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("F2");
    }
}
