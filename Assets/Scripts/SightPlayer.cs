using UnityEngine;
using UnityEngine.InputSystem;

public class SightPlayer
{
    private Vector2 _sideGaze;
    private Vector2 _baseSide = Vector2.down;
    public SightPlayer()
    {
        _sideGaze = _baseSide;
    }
    public Vector2 SideGaze
    {
        get
        {
            return _sideGaze;
        }

        set
        {
            if (value != null)
            {
                _sideGaze = value;
            }
        }
    }
}
