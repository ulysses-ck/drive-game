using TMPro;
using UnityEngine;

public class CarHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedText;

    private Rigidbody rb;
    private const float MS_TO_KMH = 3.6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpeedDisplay();
    }

    void UpdateSpeedDisplay ()
    {
        if(rb != null && speedText != null)
        {
            float speed_ms = rb.linearVelocity.magnitude;
            int displaySpeed = Mathf.RoundToInt(speed_ms * MS_TO_KMH);

            speedText.text = displaySpeed.ToString() + "km/h";
        }
    }
}
