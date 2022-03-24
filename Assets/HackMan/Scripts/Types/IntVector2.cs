  using System;
 using UnityEngine
    // Start is called before the first frame update
    //struct : a  value type
    [Serializable]
    public struct IntVector2
    {
        public int x;
        public int y;
        public static IntVector2 zero => new IntVector2(0, 0);
        public IntVector2(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
    public static IntVector2 operator +(IntVector2 v1, IntVector2 v2)
    {
        return new IntVector2(v1.x + v2.x, v1.y + v2.y);
    }
    public static IntVector2 operator -(IntVector2 v)
    {
        return new IntVector2(-v.x, -v.y);
    }
    public static bool operator == (IntVector2 v1, IntVector2 v2)
    {
        return (v1.x == v2.x&& v1.y == v2.y);
    }
    public static bool operator !=(IntVector2 v1, IntVector2 v2)
    {
        return (v1.x != v2.x||v1.y != v2.y);
    }
    public  bool Equals(IntVector2 other)
    {
        return x == other.x && y == other.y;
    }
}

