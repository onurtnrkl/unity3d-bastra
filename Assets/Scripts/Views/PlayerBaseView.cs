using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseView : MonoBehaviour
{
    public Text ScoreText { get; private set; }
    public HandView HandView { get; protected set; }

    protected virtual void Awake()
    {
        ScoreText = GetComponentsInChildren<Text>()[1];
    }
}
