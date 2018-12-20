using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManajer : MonoBehaviour {
    [Header("Stars Sprite")]
    public Sprite Star_0;
    public Sprite Star_1;
    public Sprite Star_2;
    public Sprite Star_3;
    [Header("Stars Image Game Object")]
    public List<Image> StarsImage = new List<Image>();

    private void Start()
    {
        for (int i = 0; i < StarsImage.Count; i++)
        {
            switch (PlayerPrefs.GetInt("Level_" + i))
            {
                case 0:
                    StarsImage[i].sprite = Star_0;
                    break;
                case 1:
                    StarsImage[i].sprite = Star_1;
                    break;
                case 2:
                    StarsImage[i].sprite = Star_2;
                    break;
                case 3:
                    StarsImage[i].sprite = Star_3;
                    break;
                    // The default Value
                default:
                    StarsImage[i].sprite = Star_0;
                    break;
            }

        }
    }


}
