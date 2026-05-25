using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;


public class CardSystem : MonoBehaviour
{
    [SerializeField] private int maxHandsize;

    [SerializeField] private CardList cardList;

    [SerializeField] private SplineContainer splineContainer;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject cardPrefab;

    public GameObject dropArea;

    [SerializeField] public List<GameObject> cards = new();

    public static CardSystem instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SpawnCardByIndex(int index) {
        cardPrefab = cardList.cardList[index];
    }

    public void DrawCard() {
        if (cards.Count >= maxHandsize)
            return;
        GameObject g = Instantiate(cardPrefab, spawnPoint.position, spawnPoint.rotation);
        cards.Add(g);
        UpdateCardPositions();
    }

    public void DestroyAllCard() {
        foreach (GameObject clone in cards) {
            Destroy(clone);
        }
        cards.Clear();
    }

    private void UpdateCardPositions()
    {
        if (cards.Count == 0)
            return;
        float cardSpacing = 1f / maxHandsize;
        float firstCardPosition = 0.5f - (cards.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;

        for (int i = 0; i < cards.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);
            cards[i].transform.DOMove(splinePosition + transform.position + 0.01f * Vector3.back, 0.25f);
            cards[i].transform.DORotate(rotation.eulerAngles, 0.25f);
        }
    }
}
