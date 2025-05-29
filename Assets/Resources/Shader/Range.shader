// 示例：RangeHint.shader
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
            "Queue"="Transparent"   // 渲染队列设为透明
            "RenderType"="Transparent"
        }
        Blend SrcAlpha OneMinusSrcAlpha  // 混合模式（透明叠加）

        Pass {
    ZWrite Off      // 关闭深度写入
    ZTest LEqual    // 保持默认深度测试
    Blend SrcAlpha OneMinusSrcAlpha // 标准透明混合模式
            CGPROGRAM
            #pragma vertex vert   // 顶点着色器函数
            #pragma fragment frag // 片元着色器函数

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
            // 顶点着色器
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // 坐标转换
                o.uv = v.uv;
                return o;
            }

            // 片元着色器（核心逻辑）
            fixed4 frag (v2f i) : SV_Target {
    // 定义矩形范围（中心为0.5,0.5，半宽高为0.3）
    float2 center = float2(0.5, 0.5);
    float halfWidth = 0.3;
    float halfHeight = 0.2;
    
    // 计算UV是否在矩形内
    float inRect = (abs(i.uv.x - center.x) < halfWidth) && 
                   (abs(i.uv.y - center.y) < halfHeight);
    fixed4 col = _Color;
    float Mtime=_Mtime;
    col.a*=(1-4.5*abs(i.uv.y-center.y));
    col.a*=(step(1,(1-i.uv.x)+_Time.y/Mtime));
    col.a *= inRect; // 矩形内显示，外部透明
    return col;
}
            ENDCG
        }
    }
}