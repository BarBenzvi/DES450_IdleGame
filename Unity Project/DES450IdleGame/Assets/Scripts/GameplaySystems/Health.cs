using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public BigNumber StartHealth = new BigNumber(1, 2);
    BigNumber currHealth = null;

    /*
    / If this prefab is set, it's expected to have:
    / - a TextMeshPro component in children
    / - a BarScaler component in children
    / - A FollowNonCanvasObject component on the prefab
    */
    public GameObject HealthbarObj = null;

    BarScaler bs = null;
    TextMeshProUGUI t = null;
    GameObject hb = null;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = new BigNumber(StartHealth);
        if (HealthbarObj)
        {
            GameObject hbo = Instantiate(HealthbarObj, GameObject.Find("Canvas").transform);
            bs = hbo.GetComponentInChildren<BarScaler>();
            t = hbo.GetComponentInChildren<TextMeshProUGUI>();
            hbo.GetComponent<FollowNonCanvasObject>().SetFollowTransform(transform);
            hb = hbo;
        }
    }

    void Update()
    {
        if (bs)
        {
            bs.SetScale((currHealth / StartHealth).GetMultiplier(), 1.0f);
        }
        if (t)
        {
            t.text = currHealth.ToString();
        }
    }

    public void UpdateStartHealth(BigNumber newHealth)
    {
        StartHealth = newHealth;
        currHealth = new BigNumber(StartHealth);
    }


    public void ApplyDamage(BigNumber damage)
    {
        if (damage != null)
        {
            currHealth -= damage;

            if (currHealth == BigNumber.Zero())
            {
                gameObject.SendMessage("ReachedZeroHealth", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    // Returns the 
    public GameObject GetHealthbar()
    {
        return hb;
    }
}
