using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJCMinecraft : MonoBehaviour
{
    static private JJCMinecraft _S;

    static private eGameState _GAME_STATE;

    public delegate void CallbackDelegate(); // Set up a generic delegate type.
    static public CallbackDelegate GAME_STATE_CHANGE_DELEGATE;
    public delegate void CallbackDelegateV3(Vector3 v); // Set up a Vector3 delegate type.

    [System.Flags]
    public enum eGameState
    {
        // Decimal      // Binary
        none = 0,       // 00000000
        mainMenu = 1,   // 00000001
        preLevel = 2,   // 00000010
        level = 4,      // 00000100
        postLevel = 8,  // 00001000
        gameOver = 16,  // 00010000
        all = 0xFFFFFFF // 11111111111111111111111111111111
    }

    [Header("インスペクターで指定")]
    [Tooltip("ゲーム定義を指定するためのオブジェクト.")]
    public JJC_Minecraft_SO _jjcMinecraftSO;

    [Header("パラメータ")]
    [SerializeField]
    protected eGameState _gameState;

    // 特に外には出さないもの.
    BlockMaker _blockMaker;

    private void Awake()
    {
        S = this;
        _blockMaker = GameObject.Find("WorldManager").GetComponent<BlockMaker>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ---------------- Static Section ---------------- //

    static private JJCMinecraft S
    {
        get
        {
            if (_S == null)
            {
                Debug.LogError("JJCMinecraft:S getter - Attempt to get value of S before it has been set.");
                return null;
            }
            return _S;
        }
        set
        {
            if (_S != null)
            {
                Debug.LogError("JJCMinecraft:S setter - Attempt to set S when it has already been set.");
            }
            _S = value;
        }
    }

    static public JJC_Minecraft_SO jjcMinecraftSO
    {
        get
        {
            if (S != null)
            {
                return S._jjcMinecraftSO;
            }
            return null;
        }
    }

    static public BlockMaker blockMaker
    {
        get
        {
            if (S != null)
            {
                return S._blockMaker;
            }
            return null;
        }
    }

    static public eGameState GAME_STATE
    {
        get
        {
            return _GAME_STATE;
        }
        set
        {
            if (value != _GAME_STATE)
            {
                _GAME_STATE = value;
                // Need to update all of the handlers
                // Any time you use a delegate, you run the risk of it not having any handlers
                //  assigned to it. In that case, it is null and will throw a null reference
                //  exception if you try to call it. So *any* time you call a delegate, you 
                //  should check beforehand to make sure it's not null.
                if (GAME_STATE_CHANGE_DELEGATE != null)
                {
                    GAME_STATE_CHANGE_DELEGATE();
                }
            }
        }
    }
}
