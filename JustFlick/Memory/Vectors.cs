using System;

namespace 봉순봇
{
    public class Vector2
    {

        public float x;
        public float y;

        public Vector2() { }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float Distance(Vector2 vector)
        {
            float dx = vector.x - x;
            float dy = vector.y - y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }


        public float XDistance(Vector2 vector)
        {
            float dx = vector.x - x;
            return (float)Math.Sqrt(dx * dx);
        }

        public float YDistance(Vector2 vector)
        {
            float dy = vector.y - y;
            return (float)Math.Sqrt(dy * dy);
        }

        public float Length()
        {
            return (float)Math.Sqrt((double)(this.x * this.x + this.y * this.y));
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Math.Round(x, 2), Math.Round(y, 2));
        }
    }

    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3() { }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(byte[] array)
        {
            if (array == null || array.Length != 12)
            {
                this.x = float.NaN;
                this.y = float.NaN;
                this.z = float.NaN;
                return;
            }
            this.x = BitConverter.ToSingle(array, 0);
            this.y = BitConverter.ToSingle(array, 4);
            this.z = BitConverter.ToSingle(array, 8);
        }

        public float Length()
        {
            return (float)Math.Sqrt((double)(this.x * this.x + this.y * this.y + this.z * this.z));
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x - right.x, left.y - right.y, left.z - right.z);
        }

        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x * right.x, left.y * right.y, left.z * right.z);
        }

        public static Vector3 operator *(Vector3 left, float right)
        {
            return new Vector3(left.x * right, left.y * right, left.z * right);
        }

        public static Vector3 operator *(Vector3 left, int right)
        {
            return new Vector3(left.x * (float)right, left.y * (float)right, left.z * (float)right);
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        public static Vector3 operator +(Vector3 left, float right)
        {
            return new Vector3(left.x + right, left.y + right, left.z + right);
        }

        public static Vector3 operator +(Vector3 left, int right)
        {
            return new Vector3(left.x + (float)right, left.y + (float)right, left.z + (float)right);
        }

        public float Distance(Vector3 vector)
        {
            float dx = vector.x - x;
            float dy = vector.y - y;
            float dz = vector.z - z;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Math.Round(x, 2), Math.Round(y, 2), Math.Round(z, 2));
        }
    }
}
