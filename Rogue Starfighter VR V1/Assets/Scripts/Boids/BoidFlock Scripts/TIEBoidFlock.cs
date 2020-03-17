public class TIEBoidFlock : BoidFlock 
{
    public static TIEBoidFlock Instance;

    private void Awake()
    {
        /*base.Awake()*/;
        Instance = this;
    }
}
