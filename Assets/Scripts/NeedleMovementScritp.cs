using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovementScritp : MonoBehaviour
{
    [SerializeField]
    private GameObject needleBody;
    private bool canFireNeedle;
    private bool touchedTheCircle;
    private float forceY = 5f;
    [SerializeField]
    private Rigidbody2D myBody;

    /// <summary>Awake is called  when the script instance is begin loaded</summary>
    void Awake()
    {
        Initialize();
        FireTheNeedle();
    }

    void Initialize()
    {
        needleBody.SetActive(false);
        myBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (canFireNeedle)
        {
            myBody.velocity = new Vector2(0, forceY);
        }
    }

    public void FireTheNeedle()
    {
        needleBody.SetActive(true);
        myBody.simulated = true;
        canFireNeedle = true;
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        if(touchedTheCircle){
            return;
        }
        if (target.tag == "Circle")
        {
            canFireNeedle = false;
            touchedTheCircle = true;
            myBody.simulated = false;
        }
    }
}
