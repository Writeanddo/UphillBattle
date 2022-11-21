using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardAction : Card
{
    public ActionSO action;

    // ========= Visual Componenets =========
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image art;

    public override void SetUp()
    {
        cost.text = action.cost.ToString();
        title.text = action.title;
        description.text = action.description;

        art.sprite = action.art;
        art.rectTransform.localPosition = action.cardArtOffset;
        var size = new Vector3(action.cardArtSize, action.cardArtSize, action.cardArtSize);
        art.rectTransform.localScale = size;
    }

    private void Awake()
    {
        if (action) SetUp();
    }

    public override void Play()
    {
        // Test if can be played
        if (playerManager.TryPlayActionCard(action))
        {
            Debug.Log("Played card: " + action.title);
            playerManager.CardPlayed();
            this.transform.parent.GetComponent<HandSlot>().Discard(false);
        }
        else
        {
            Debug.Log("Card could not be played");
            playerManager.CardPlayed();
        }
    }
}