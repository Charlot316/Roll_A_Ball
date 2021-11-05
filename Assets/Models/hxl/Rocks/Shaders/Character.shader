Shader "YoulongShaders/Character" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_PartialColor("Partial Color", Color) = (1,1,1,1)
	_EmiColor ("Emission Color", Color) = (1,1,1,1)
	_EmiScale ("Emission scale", Range(0,1.0)) = 0.2
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
	_MainTex ("Base (RGB) TransGloss (A)", 2D) = "white" {}
	_Cutoff ("Alpha cutoff", Range(0,0.0196)) = 0.0196
}

SubShader {
	Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType" = "Opaque"}
	LOD 400
	
CGPROGRAM
#pragma surface surf BlinnPhong alphatest:_Cutoff

sampler2D _MainTex;
fixed4 _Color;
fixed4 _PartialColor;
fixed4 _EmiColor;
half _EmiScale;
half _Shininess;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	
	float partialScale = (tex.a * 255 - 10) / 254;
	partialScale = clamp(partialScale, 0, 1);
	
	o.Albedo.rgb = tex.rgb * _Color.rgb * (1 - partialScale) + tex.rgb * _Color.rgb * _PartialColor.rgb * partialScale;
	o.Gloss = 1;//tex.a;
	o.Alpha = tex.a;
	o.Specular = _Shininess;
	o.Emission = _EmiColor.rgb * tex.rgb * _EmiScale;
}
ENDCG
}

FallBack "Transparent/Cutout/VertexLit"
}
