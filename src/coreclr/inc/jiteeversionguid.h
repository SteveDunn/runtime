// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

//////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE
//
// #JITEEVersionIdentifier
//
// This GUID represents the version of the JIT/EE interface. Any time the interface between the JIT and
// the EE changes (by adding or removing methods to any interface shared between them), this GUID should
// be changed. This is the identifier verified by ICorJitCompiler::getVersionIdentifier().
//
// You can use "uuidgen.exe -s" to generate this value.
//
// Note that this file is parsed by some tools, namely superpmi.py, so make sure the first line is exactly
// of the form:
//
//   constexpr GUID JITEEVersionIdentifier = { /* 1776ab48-edfa-49be-a11f-ec216b28174c */
//
// (without the leading slashes or spaces).
//
// See docs/project/updating-jitinterface.md for details
//
// **** NOTE TO INTEGRATORS:
//
// If there is a merge conflict here, because the version changed in two different places, you must
// create a **NEW** GUID, not simply choose one or the other!
//
// NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE NOTE
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//

#ifndef GUID_DEFINED
typedef struct _GUID {
    uint32_t   Data1;    // NOTE: diff from Win32, for LP64
    uint16_t   Data2;
    uint16_t   Data3;
    uint8_t    Data4[ 8 ];
} GUID;
typedef const GUID *LPCGUID;
#define GUID_DEFINED
#endif // !GUID_DEFINED

constexpr GUID JITEEVersionIdentifier = { /* 2335da47-1d6c-4844-96b6-025558a525ba */
    0x2335da47,
    0x1d6c,
    0x4844,
    {0x96, 0xb6, 0x02, 0x55, 0x58, 0xa5, 0x25, 0xba}
  };

//////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// END JITEEVersionIdentifier
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////
