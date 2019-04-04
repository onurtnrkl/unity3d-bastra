using UnityEngine;

public class PlayerBaseView : MonoBehaviour
{
    public ScoreView ScoreView { get; private set; }
    public HandView HandView { get; protected set; }

    protected virtual void Awake()
    {
        ScoreView = GetComponentInChildren<ScoreView>();
    }
}
