using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum GameState
    { 
        Started, Finished
    }

    private static GameManager _instance;
    public static GameManager Instance {  get { return _instance; } }

    [SerializeField]
    public Checkpoint[] checkpoints;

    [SerializeField]
    public Participant participants; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_instance != null)
        { 
            
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
