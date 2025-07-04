Shader "Custom/UnlitTextureWithColor"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}  // 貼圖
        _Color ("Color Tint", Color) = (1,1,1,1) // 顏色屬性
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        Pass
        {
            Lighting Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color; // 控制顏色
           
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 texColor = tex2D(_MainTex, i.uv);
                return texColor * _Color; // 讓顏色影響貼圖
            }
            ENDCG
        }
    }
}
