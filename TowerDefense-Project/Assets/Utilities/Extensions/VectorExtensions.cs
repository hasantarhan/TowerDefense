using UnityEngine;

namespace Hasan.Extensions
{
    public static class VectorExtensions
    {
        public static int GetRandomIntByVector2(this Vector2 vector) => Random.Range((int)vector.x, (int)vector.y);
        public static float GetRandomFloatByVector2(this Vector2 vector) => Random.Range(vector.x, vector.y);

        public static Vector2 Vector3ToVector2(this Vector3 v)
        {
            return new Vector2(v.x, v.z);
        }

        public static Vector3 WithX(this Vector3 v, float x)
        {
            return new Vector3(x, v.y, v.z);
        }

        public static Vector3 WithY(this Vector3 v, float y)
        {
            return new Vector3(v.x, y, v.z);
        }
        public static Vector3 AddY(this Vector3 v, float y)
        {
            return new Vector3(v.x, v.y + y, v.z);
        }
        public static Vector3 AddX(this Vector3 v, float y)
        {
            return new Vector3(v.x + y, v.y, v.z);
        }
        public static Vector3 AddZ(this Vector3 v, float y)
        {
            return new Vector3(v.x, v.y, v.z + y);
        }
        public static Vector3 WithZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }

        public static Vector2 WithX(this Vector2 v, float x)
        {
            return new Vector2(x, v.y);
        }

        public static Vector2 WithY(this Vector2 v, float y)
        {
            return new Vector2(v.x, y);
        }

        public static Vector3 WithZ(this Vector2 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }

        public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 point, bool isNormalized = false)
        {
            if (!isNormalized) axisDirection.Normalize();
            float d = Vector3.Dot(point, axisDirection);
            return axisDirection * d;
        }

        public static Vector3 GetDirection(this Vector3 right, Vector3 left)
        {
            return (left - right).normalized;
        }

        public static Vector3 NearestPointOnLine(
            this Vector3 lineDirection, Vector3 point, Vector3 pointOnLine, bool isNormalized = false)
        {
            if (!isNormalized) lineDirection.Normalize();
            float d = Vector3.Dot(point - pointOnLine, lineDirection);
            return pointOnLine + lineDirection * d;
        }

        public static Quaternion Pow(this Quaternion input, float power)
        {
            float inputMagnitude = input.Magnitude();
            var nHat = new Vector3(input.x, input.y, input.z).normalized;
            var vectorBit = new Quaternion(nHat.x, nHat.y, nHat.z, 0)
                .ScalarMultiply(power * Mathf.Acos(input.w / inputMagnitude))
                .Exp();
            return vectorBit.ScalarMultiply(Mathf.Pow(inputMagnitude, power));
        }

        public static Quaternion Exp(this Quaternion input)
        {
            float inputA = input.w;
            var inputV = new Vector3(input.x, input.y, input.z);
            float outputA = Mathf.Exp(inputA) * Mathf.Cos(inputV.magnitude);
            var outputV = Mathf.Exp(inputA) * (inputV.normalized * Mathf.Sin(inputV.magnitude));
            return new Quaternion(outputV.x, outputV.y, outputV.z, outputA);
        }
        public static Vector2 ToVector2(this float value)
        {
            return new Vector2(value, value);
        }
        public static float Magnitude(this Quaternion input)
        {
            return Mathf.Sqrt(input.x * input.x + input.y * input.y + input.z * input.z + input.w * input.w);
        }

        public static Quaternion ScalarMultiply(this Quaternion input, float scalar)
        {
            return new Quaternion(input.x * scalar, input.y * scalar, input.z * scalar, input.w * scalar);
        }
    }
}