 
Shader "Transparent/Diffuse" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
}
 
SubShader {
    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
    Cull Front
    LOD 200
 
CGPROGRAM
#pragma surface surf Lambert alpha
 
sampler2D _MainTex;
fixed4 _Color;
 
struct Input {
    float2 uv_MainTex;
};

 void vert (inout appdata_full v, out Input o) {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            v.normal = -v.normal;
}
              
void surf (Input IN, inout SurfaceOutput o) {
	
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
    o.Albedo = c.rgb;
    o.Alpha = c.a;
}
ENDCG
}
Fallback "Transparent/VertexLit"
}
 