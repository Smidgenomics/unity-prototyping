// xmas

//==========================================================
// SpaceUVs.shader
// -
// Uses object's transform to derive texture UVs 
//==========================================================

// Heavily modified from ideas learned from following sources:
// https://www.youtube.com/watch?v=s79Zu0F8fuY
// https://discussions.unity.com/t/get-local-position-in-surface-shader/84926/2

// Note:
// Normal mapping might need tweaking, not sure
// https://forum.unity.com/threads/reading-vertex-normals-and-normal-map-within-a-surface-shader.151554/

Shader "Smidgenomics/Space UVs" {

	Properties {

		// > Fields with custom inspector handling (hence [HideInInspector])

		[HideInInspector]
		_MainTex ("Albedo", 2D) = "white" {}

		[Normal]
		[HideInInspector]
		_BumpMap ("Normal", 2D) = "bump" {}

		[MainColor]
		[HideInInspector]
		_Color ("Color", Color) = (1,1,1,1)

		[HideInInspector]
		_BumpScale ("Normal Strength", Float) = 1.0 // bump scale

		// > Fields drawn with defaults

		_Glossiness ("Smoothness", Range(0.0,1.0)) = 0.0
		_Metallic ("Metallic", Range(0.0,1.0)) = 0.0

		_Scale ("Tiling", Float) = 1.0 // uv scale
		_NormalScale ("Normal Tiling", Float) = 1.0 // normal scale multiplier
		[Enum(Smidgenomics.Unity.Prototyping.Editor.ERenderSpace)] // space mode (tiled relative to object or world)
		_Space ("Mode", Float) = 0.0
	}

	CustomEditor "Smidgenomics.Unity.Prototyping.Editor._SpaceUVs"

	SubShader {

		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM

		// utils
		#include "./#include/Transform.cginc"
		#include "./#include/UV.cginc"

		#pragma surface surf Standard fullforwardshadows vertex:vert
		#pragma shader_feature _NORMALMAP

		sampler2D _MainTex;
		sampler2D _BumpMap;

		fixed4 _Color;
		float _Scale;
		float _BumpScale;
		float _NormalScale;
		float _Metallic;
		float _Glossiness;
		float _Space;

		struct Input
		{
			float3 viewDir;
			float3 worldNormal;
			float3 worldPos;
			float3 localPos;
			INTERNAL_DATA
		};

		//=================================================
		//============= SHADER FUNCTIONS ==================
		//=================================================

		// vert fn needed to grab position of vertex in local space
		void vert (inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input,o);
			o.localPos = v.vertex.xyz;
		}

		void surf (Input IN, inout SurfaceOutputStandard o)
		{
			// required when writing to normal, otherwise tiling gets all screwy
			float3 worldNormal = WorldNormalVector (IN, float3(0, 0, 1));

			// default to world space
			float3 normal = worldNormal;
			float3 pos = IN.worldPos;

			if(_Space == 0.0) // use object space?
			{
				normal = InverseTransformDirection(worldNormal);
				pos = IN.localPos * GetLossyScale();
			}

			float2 uv = VertexToUV(normal, pos);
			o.Smoothness = _Glossiness;
			o.Metallic = _Metallic;
			o.Albedo = tex2D(_MainTex, uv * _Scale) * _Color;
			o.Normal = UnpackNormalWithScale (tex2D (_BumpMap, uv * _Scale * _NormalScale), _BumpScale);
		}

		ENDCG
	}

	//Fallback "VertexLit"
	Fallback "Diffuse"
}
