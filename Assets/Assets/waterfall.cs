using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfall : MonoBehaviour
{
    public float scroll_speed_x = 0.5f;
    public float scroll_speed_y = 0.5f;
    MeshRenderer mr;

    Vector2 saved;

    // Start is called before the first frame update
    void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        saved = mr.sharedMaterial.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Time.time * scroll_speed_x;
        float y = Time.time * scroll_speed_y;

        Vector2 offset = new Vector2(x,y);
        mr.sharedMaterial.SetTextureOffset("_MainTex", saved + offset);
    }
}
