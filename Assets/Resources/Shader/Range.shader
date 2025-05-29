// ʾ����RangeHint.shader
Shader "Custom/RangeHint" {
    Properties {
        _MainTex ("Tecxture", 2D) = "white" {}
        _Color ("MainColor", Color) = (1,0,0,0.3)   // RGBA
        _WaveSpeed ("WaveSpeed", Range(0,5)) = 2
        _WaveWidth ("WaveWidth", Range(0,1)) = 0.1
        _Mtime ("MTime", Range(0,5)) = 1.5
    }

    SubShader {
        Tags { 
            "Queue"="Transparent"   // ��Ⱦ������Ϊ͸��
            "RenderType"="Transparent"
        }
        Blend SrcAlpha OneMinusSrcAlpha  // ���ģʽ��͸�����ӣ�

        Pass {
    ZWrite Off      // �ر����д��
    ZTest LEqual    // ����Ĭ����Ȳ���
    Blend SrcAlpha OneMinusSrcAlpha // ��׼͸�����ģʽ
            CGPROGRAM
            #pragma vertex vert   // ������ɫ������
            #pragma fragment frag // ƬԪ��ɫ������

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _Color;
            float _WaveSpeed;
            float _WaveWidth;
            float _Mtime;
            // ������ɫ��
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // ����ת��
                o.uv = v.uv;
                return o;
            }

            // ƬԪ��ɫ���������߼���
            fixed4 frag (v2f i) : SV_Target {
    // ������η�Χ������Ϊ0.5,0.5������Ϊ0.3��
    float2 center = float2(0.5, 0.5);
    float halfWidth = 0.3;
    float halfHeight = 0.2;
    
    // ����UV�Ƿ��ھ�����
    float inRect = (abs(i.uv.x - center.x) < halfWidth) && 
                   (abs(i.uv.y - center.y) < halfHeight);
    fixed4 col = _Color;
    float Mtime=_Mtime;
    col.a*=(1-4.5*abs(i.uv.y-center.y));
    col.a*=(step(1,(1-i.uv.x)+_Time.y/Mtime));
    col.a *= inRect; // ��������ʾ���ⲿ͸��
    return col;
}
            ENDCG
        }
    }
}