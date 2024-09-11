using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppliePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBasket; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            tBasketGO.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
