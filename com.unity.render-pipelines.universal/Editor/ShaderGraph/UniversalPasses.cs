﻿using UnityEditor.ShaderGraph;

namespace UnityEditor.Rendering.Universal.ShaderGraph
{
    static class UniversalPasses
    {
        static class UniversalStructCollections
        {
            public static StructCollection Default = new StructCollection
            {
                { Structs.Attributes },
                { UniversalStructs.Varyings },
                { Structs.SurfaceDescriptionInputs },
                { Structs.VertexDescriptionInputs },
            };
        }

        public static PassDescriptor Forward = new PassDescriptor
        {
            // Definition
            displayName = "Universal Forward",
            referenceName = "SHADERPASS_FORWARD",
            lightMode = "UniversalForward",
            useInPreview = true,

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.LitForward,

            // Fields
            structs = UniversalStructCollections.Default,
            requiredFields = UniversalRequiredFields.PBRForward,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.Default,
            pragmas = UniversalPragmas.Forward,
            keywords = UniversalKeywords.PBRForward,
            includes = UniversalIncludes.Forward,
        };

        public static PassDescriptor DepthOnly = new PassDescriptor()
        {
            // Definition
            displayName = "DepthOnly",
            referenceName = "SHADERPASS_DEPTHONLY",
            lightMode = "DepthOnly",
            useInPreview = true,

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.LitAlphaOnly,

            // Fields
            structs = UniversalStructCollections.Default,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.DepthOnly,
            pragmas = UniversalPragmas.Instanced,
            includes = UniversalIncludes.DepthOnly,
        };

        public static PassDescriptor ShadowCaster = new PassDescriptor()
        {
            // Definition
            displayName = "ShadowCaster",
            referenceName = "SHADERPASS_SHADOWCASTER",
            lightMode = "ShadowCaster",

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.LitAlphaOnly,

            // Fields
            structs = UniversalStructCollections.Default,
            requiredFields = UniversalRequiredFields.PBRShadowCaster,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.ShadowCasterMeta,
            pragmas = UniversalPragmas.Instanced,
            includes = UniversalIncludes.ShadowCaster,
        };

        public static PassDescriptor Meta = new PassDescriptor()
        {
            // Definition
            displayName = "Meta",
            referenceName = "SHADERPASS_META",
            lightMode = "Meta",

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.LitMeta,

            // Fields
            structs = UniversalStructCollections.Default,
            requiredFields = UniversalRequiredFields.PBRMeta,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.ShadowCasterMeta,
            pragmas = UniversalPragmas.Default,
            keywords = UniversalKeywords.PBRMeta,
            includes = UniversalIncludes.Meta,
        };

        public static PassDescriptor _2D = new PassDescriptor()
        {
            // Definition
            referenceName = "SHADERPASS_2D",
            lightMode = "Universal2D",

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.Unlit,

            // Fields
            structs = UniversalStructCollections.Default,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.Default,
            pragmas = UniversalPragmas.Instanced,
            includes = UniversalIncludes.PBR2D,
        };

        public static PassDescriptor Unlit = new PassDescriptor
        {
            // Definition
            displayName = "Pass",
            referenceName = "SHADERPASS_UNLIT",
            useInPreview = true,

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.Unlit,

            // Fields
            structs = UniversalStructCollections.Default,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.Default,
            pragmas = UniversalPragmas.Forward,
            keywords = UniversalKeywords.Unlit,
            includes = UniversalIncludes.Unlit,
        };

        public static PassDescriptor SpriteLit = new PassDescriptor
        {
            // Definition
            displayName = "Sprite Lit",
            referenceName = "SHADERPASS_SPRITELIT",
            lightMode = "Universal2D",
            useInPreview = true,

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.SpriteLit,

            // Fields
            structs = UniversalStructCollections.Default,
            requiredFields = UniversalRequiredFields.SpriteLit,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.Default,
            pragmas = UniversalPragmas.Default,
            keywords = UniversalKeywords.SpriteLit,
            includes = UniversalIncludes.SpriteLit,
        };

        public static PassDescriptor SpriteNormal = new PassDescriptor
        {
            // Definition
            displayName = "Sprite Normal",
            referenceName = "SHADERPASS_SPRITENORMAL",
            lightMode = "NormalsRendering",
            useInPreview = true,

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.SpriteNormal,

            // Fields
            structs = UniversalStructCollections.Default,
            requiredFields = UniversalRequiredFields.SpriteNormal,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.Default,
            pragmas = UniversalPragmas.Default,
            includes = UniversalIncludes.SpriteNormal,
        };

        public static PassDescriptor SpriteForward = new PassDescriptor
        {
            // Definition
            displayName = "Sprite Forward",
            referenceName = "SHADERPASS_SPRITEFORWARD",
            lightMode = "UniversalForward",
            useInPreview = true,

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.SpriteNormal,

            // Fields
            structs = UniversalStructCollections.Default,
            requiredFields = UniversalRequiredFields.SpriteForward,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.Default,
            pragmas = UniversalPragmas.Default,
            keywords = UniversalKeywords.ETCExternalAlpha,
            includes = UniversalIncludes.SpriteForward,
        };

        public static PassDescriptor SpriteUnlit = new PassDescriptor
        {
            // Definition
            referenceName = "SHADERPASS_SPRITEUNLIT",
            useInPreview = true,

            // Block Mask
            vertexBlocks = UniversalBlockMasks.Vertex.Default,
            pixelBlocks = UniversalBlockMasks.Pixel.SpriteUnlit,

            // Fields
            structs = UniversalStructCollections.Default,
            requiredFields = UniversalRequiredFields.SpriteUnlit,
            fieldDependencies = UniversalFieldDependencies.UniversalDefault,

            // Conditional State
            renderStates = UniversalRenderStates.Default,
            pragmas = UniversalPragmas.Default,
            keywords = UniversalKeywords.ETCExternalAlpha,
            includes = UniversalIncludes.SpriteUnlit,
        };
    }
}
