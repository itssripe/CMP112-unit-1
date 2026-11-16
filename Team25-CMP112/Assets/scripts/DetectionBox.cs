using UnityEngine;

public class DetectionBox : MonoBehaviour
{
    private Collider2D detector; //Gets the collision box of the PlayerDetectorBox
    public Collider2D Detector //Makes it so detector can be used in other scripts
    {
        get { return detector; }
        set { detector = value; }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        detector = GetComponent<Collider2D>(); //Gets transform of 2D box collider of PlayerDecetorBox before every frame
    }

    // Update is called once per frame
    void Update()
    {

    }
}
