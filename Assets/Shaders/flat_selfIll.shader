  Shader "snail/ScreenPos_selfIllu" {
    Properties {
      _SelfIllumination ("Self Illumination", Range(0.0,3.0)) = 1.0
      _DetailTextureScale("Texture Scale", Range(1.0, 10.0)) = 1.0
      _MainTex ("Texture", 2D) = "white" {}
      _Detail ("Detail", 2D) = "gray" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float4 screenPos;
      };
      sampler2D _MainTex;
      sampler2D _Detail;
      uniform fixed _SelfIllumination;
      uniform fixed _DetailTextureScale;
      
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          float2 screenUV = IN.screenPos.xy / (IN.screenPos.w *_DetailTextureScale) ;
          screenUV *= float2(8,6);
          o.Albedo *= tex2D (_Detail, screenUV).rgb *_SelfIllumination;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }
