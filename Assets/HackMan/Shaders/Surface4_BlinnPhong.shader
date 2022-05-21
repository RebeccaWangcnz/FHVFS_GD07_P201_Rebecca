Shader "Custom/Shader4_BlinnPhong"
{
	Properties
	{
		_Color("Color",Color)=(1,1,1,1)
		_SpecColor("Specular Color",Color)=(1,1,1,1)
		_SpecularRange("Specular Range",Range(0,1))=0.0
		_SpecularIntensity("Specular Intensity", Range(0,1))=0.0
	}
	SubShader
	{
		Tags{"Queue"="Geometry+1"}
		CGPROGRAM
		//lighting model
		#pragma surface surf BlinnPhong
		struct Input
		{
			//Needs at least one member....
			float3 uv_MainTex;
		};
		//Packed array...
		float4 _Color;
		half _SpecularRange;
		fixed _SpecularIntensity;

		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = _Color.rgb;
			o.Specular=_SpecularRange;
			o.Gloss=_SpecularIntensity;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
