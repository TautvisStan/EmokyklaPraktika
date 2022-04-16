using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesMiddle : MonoBehaviour
{
    public MixturesPanelItem[] Items;
    public SpriteRenderer MiddleImage;
    public void SelectItem(MixturesPanelItem selectedItem)
    {
        foreach(MixturesPanelItem item in Items)
        {
            if (item.isActiveAndEnabled)
            {
                item.Unselect();
            }
        }
        selectedItem.Select();
    }
}
