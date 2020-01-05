using UnityEngine;
using UnityEngine.UI;

public class FPScounter : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public Text _fpsText;
    public float _hudRefreshRate = 1f;

    private float _timer;

    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = fps + "FPS: ";
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}