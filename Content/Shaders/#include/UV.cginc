// smidgens @ github

//==========================================================
// UV.cginc
// -
// Utilities for UV operations like triplanar shit, moved
// here for reuse in case we'd want multiple variants
//==========================================================

// compute uvs based on vertex normal and object position
float2 VertexToUV(float3 normal, float3 pos)
{
	if(abs(normal.x) > 0.5){ return pos.yz; } // side
	else if(abs(normal.z) > 0.5){ return pos.xy; } // front
	return pos.xz; // top
}