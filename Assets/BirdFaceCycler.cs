using UnityEngine;
using UnityEngine.UI;

public class BirdFaceCycler : MonoBehaviour
{
    public Sprite[] birdFaces;        // List of bird face sprites
    public float cycleInterval = 1f;  // Time between each change
    private Image imageComponent;
    private int currentIndex = 0;

    void Start()
    {
        imageComponent = GetComponent<Image>();
        if (birdFaces.Length > 0)
        {
            imageComponent.sprite = birdFaces[0];
            InvokeRepeating(nameof(CycleFace), cycleInterval, cycleInterval);
        }
    }

    void CycleFace()
    {
        currentIndex = (currentIndex + 1) % birdFaces.Length;
        imageComponent.sprite = birdFaces[currentIndex];
    }
}
