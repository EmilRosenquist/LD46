using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipHandler : MonoBehaviour
{
    public void SetTooltipSource(IToolTipable TooltipSource)
    {
        EventTrigger trigger = GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { TooltipSource.ShowToolTip(gameObject); });
        trigger.triggers.Add(entry);

        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener((eventData) => { TooltipSource.HideToolTip(gameObject); });
        trigger.triggers.Add(exit);
    }

    public void SetItemCraftable(ICraftClick craftMenu)
    {
        EventTrigger trigger = GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { craftMenu.CraftItem(gameObject); });
        trigger.triggers.Add(entry);
    }

}
