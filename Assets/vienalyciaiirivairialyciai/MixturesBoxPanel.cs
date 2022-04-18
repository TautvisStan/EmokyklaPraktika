using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesBoxPanel : MonoBehaviour
{
    public MixturesPanelItem[] Items;
    public void PutItems(MixturesBoxElement[] elements, int count, string side)
    {
        for (int i = 0; i < count; i++)
        {
            Items[i].gameObject.SetActive(true);
            Items[i].InsertItem(elements[i], side);
        }
    }
}
