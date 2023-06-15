/*
* Tencent is pleased to support the open source community by making Puerts available.
* Copyright (C) 2020 THL A29 Limited, a Tencent company.  All rights reserved.
* Puerts is licensed under the BSD 3-Clause License, except for the third-party components listed in the file 'LICENSE' which may be subject to their corresponding license terms. 
* This file is subject to the terms and conditions defined in file 'LICENSE', which is part of this source code package.
*/
#define ENABLE_CJS_AUTO_RELOAD
#if UNITY_2018_1_OR_NEWER
using System.IO;
#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif
using UnityEngine;
 
namespace Puerts.TSLoader
{

    [ScriptedImporter(1, "mts")]
    public class MTSImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            TypescriptAsset subAsset = ScriptableObject.CreateInstance<TypescriptAsset>();
            ctx.AddObjectToAsset("typescript", subAsset);

            ctx.SetMainObject(subAsset);
#if ENABLE_CJS_AUTO_RELOAD
             Puerts.JsEnv.ClearAllModuleCaches();
#endif
        }
    }
    [ScriptedImporter(1, "ts")]
    public class TSImporter : MTSImporter {}
}

#endif