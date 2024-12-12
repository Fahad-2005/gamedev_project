using UnityEngine;

public class bg_script : MonoBehaviour
{
    public float scrollSpeed = -9.87f; // Speed at which the background moves
    public float backgroundWidth = 10.24f; // Width of a single background

    private Transform[] backgrounds; // Array to store both backgrounds

    void Start()
    {
        // Get all child transforms (the two backgrounds)
        backgrounds = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        // Move the parent GameObject to scroll the backgrounds
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Check if any background has moved out of view
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.x <= -backgroundWidth)
            {
                // Move the background to the end of the second background
                float rightmostX = GetRightmostBackgroundPosition();
                bg.position = new Vector3(rightmostX + backgroundWidth, bg.position.y, bg.position.z);
            }
        }
    }

    float GetRightmostBackgroundPosition()
    {
        float rightmostX = float.MinValue;
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.x > rightmostX)
            {
                rightmostX = bg.position.x;
            }
        }
        return rightmostX;
    }
}
