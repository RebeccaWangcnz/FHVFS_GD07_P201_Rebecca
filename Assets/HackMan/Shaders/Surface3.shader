Shader "Custom/Shader3_normal"
{
	Properties
	{
		_MainTex("Texture",2D)="white"{}
		_NormalTex("Normal Texture",2D)="bump"{}
		_NormalIntensity("Normal Intensity", Range(0,5))=1
	}
	SubShader
	{
		CGPROGRAM
		//lighting model
		#pragma surface surf Lambert
		struct Input
		{
			//Needs at least one member....
			float2 uv_MainTex;
			float2 uv_NormalTex;
		};
		//Packed array...
		sampler2D _MainTex;
		sampler2D _NormalTex;
		half _NormalIntensity;

		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = tex2D(_MainTex,IN.uv_MainTex).rgb;
			o.Normal=UnpackNormal(tex2D(_NormalTex,IN.uv_NormalTex));
			o.Normal*= float3(_NormalIntensity,_NormalIntensity,1);//change direction
		}
		ENDCG
	}
	FallBack "Diffuse"
}
