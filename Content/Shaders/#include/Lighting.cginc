// smidgens @ github

//==========================================================
// Lighting.cginc
// -
// Misc lighting shorthands
//==========================================================

// compute reflection vector from vertex normal and view direction
float3 GetWorldReflection(float3 normal, float3 viewDir)
{
	// https://gamedev.stackexchange.com/questions/121597/in-unity-shaders-how-is-in-worldrefl-calculated
	return 2.0 * normal * dot(normal, viewDir) - viewDir;
}