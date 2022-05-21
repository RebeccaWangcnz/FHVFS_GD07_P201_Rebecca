Shader "Custom/Shader2_texture"
{
	Properties
	{
		_Color("Color",Color)=(1,1,1,1)
		_MainTex("Texture",2D)="white"{}
		_TexRange("Texture Range", Range(0,5))=0.5
	}
	SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert
		struct Input
		{
			//Needs at least one member....
			float2 uv_MainTex;

		};
		//Packed array...
		fixed4 _Color;//name need to be same
		sampler2D _MainTex;
		float _TexRange;

		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = (tex2D(_MainTex,IN.uv_MainTex)*_TexRange*_Color).rgb;
		}
		ENDCG
	}
}
