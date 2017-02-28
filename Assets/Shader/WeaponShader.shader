Shader "Custom/WeaponShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		
	    Tags {"RenderType"="Opaque" "Queue"="Geometry-50"}
		
		
			
         Pass{
			ZWrite off
			ZTest always
	                
			Stencil {
	                Ref 2
	                Comp always
	                Pass replace
	                Fail replace
	                ZFail replace
	            }
           }
           
		
		CGPROGRAM
		#pragma surface surf Lambert
 
		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			float4  c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
		
	} 
	FallBack "Diffuse"
}
