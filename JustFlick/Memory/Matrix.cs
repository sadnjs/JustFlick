using System;

namespace 봉순봇
{
    public class Matrix   // 4x4 행렬
    {
        public float m11, m12, m13, m14; //00, 01, 02, 03
        public float m21, m22, m23, m24; //04, 05, 06, 07
        public float m31, m32, m33, m34; //08, 09, 10, 11
        public float m41, m42, m43, m44; //12, 13, 14, 15

        public bool WorldToScreen(Vector3 worldPos, int width, int height, out Vector2 screenPos)
        {
            try
            {
                float screenX = (m11 * worldPos.x) + (m21 * worldPos.y) + (m31 * worldPos.z) + m41;
                float screenY = (m12 * worldPos.x) + (m22 * worldPos.y) + (m32 * worldPos.z) + m42;
                float screenW = (m14 * worldPos.x) + (m24 * worldPos.y) + (m34 * worldPos.z) + m44;

                float camX = width / 2f;
                float camY = height / 2f;

                float x = camX + (camX * screenX / screenW);
                float y = camY - (camY * screenY / screenW);
                screenPos = new Vector2(x, y);

                return (screenW > 0.001f);
            }
            catch
            {
                screenPos = new Vector2(0, 0);
                return false;
            }
        }

        public override string ToString()
        {
            return String.Format(
                "{0,8}{1,8}{2,8}{3,8}\n" +
                "{4,8}{5,8}{6,8}{7,8}\n" +
                "{8,8}{9,8}{10,8}{11,8}\n" +
                "{12,8}{13,8}{14,8}{15,8}",
                Math.Round(m11, 2), Math.Round(m12, 2), Math.Round(m13, 2), Math.Round(m14, 2),
                Math.Round(m21, 2), Math.Round(m22, 2), Math.Round(m23, 2), Math.Round(m24, 2),
                Math.Round(m31, 2), Math.Round(m32, 2), Math.Round(m33, 2), Math.Round(m34, 2),
                Math.Round(m41, 2), Math.Round(m42, 2), Math.Round(m43, 2), Math.Round(m44, 2));
        }
    }
}