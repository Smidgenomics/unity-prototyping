// https://discussions.unity.com/t/models-using-transparent-shader-are-overlapping-themselves/226093/2

// debug shader for rendering gizmos on top of everything else
// useful for debug visualization
Shader "Smidgenomics/Debug Gizmo"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Main Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags {
			"RenderType"="Transparent"
			"Queue"="Transparent"
		}
		ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha
		Cull back 
		
		
		// backface stuff
		// hmm...how exactly does this stencil shit work...
		Stencil {
			Ref 10
			ReadMask 10
			Comp NotEqual
			Pass Replace
		}

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;

			};

			fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = ComputeScreenPos(o.vertex);
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				float2 uv = i.uv * _MainTex_ST.xy + _MainTex_ST.zw;
				return tex2D(_MainTex, uv) * _Color;
			}
			ENDCG
		}
	}

	Fallback "Diffuse"
}

