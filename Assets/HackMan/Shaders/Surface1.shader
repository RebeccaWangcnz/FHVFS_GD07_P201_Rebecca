Shader "Custom/Shader1"
{
	Properties
	{
		_Color("Color",Color)=(1,1,1,1)
	}
	SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert
		struct Input
		{
			//Needs at least one member....
			float uv_MainTex;

		};
		//Packed array...
		fixed4 _Color;//name need to be same

		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = _Color.rgb;
		}
		ENDCG
	}
}
