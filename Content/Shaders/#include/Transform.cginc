// smidgens @ github

//==========================================================
// transform.cginc
// -
// Utilities for working with and getting information on the
// GameObject's Transform.
//==========================================================

// retrieves world space position of object
inline float3 GetPosition()
{
	return unity_ObjectToWorld._m30_m31_m32;
}

// retrieves object's scale vector from world matrix
inline float3 GetLossyScale()
{
	return float3(
		length(unity_ObjectToWorld._m00_m10_m20),
		length(unity_ObjectToWorld._m01_m11_m21),
		length(unity_ObjectToWorld._m02_m12_m22)
	);
}

// transform direction from world to local space
inline float3 InverseTransformDirection(float3 normal)
{
	return normalize(mul(unity_WorldToObject , normal));
}